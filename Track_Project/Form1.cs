using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Track_Project
{
   public enum Ultima_Operacion
    {
        Add_Line,
        Add_Point,
        Add_Curve
    };

    public partial class Form1 : Form
    {
        const int Infinite_X = 214748360; const int Infinite_Y = 214748360;
        const int Min_Divide_Points=5, Max_Divide_Points=2000;
        private List<Point> Map_Points = new List<Point>();
        private Point Origen = new Point(385, 208), Punto_Arrastre=new Point ();
        private Point Punto_Seleccionado_1 = new Point(), Punto_Seleccionado_2 = new Point(), Punto_Cero = new Point(), Mouse_Position = new Point();
        private bool Preview_Linea, View_Equal_Point;
        private int Index_x, Index_y, Posicion_x, Posicion_y;
        private List <Tracks> tracks = new List<Tracks>();
        private Tracks _track = new Tracks();
        public Color Line_Color = Color.DarkRed;
        private readonly SolidBrush[] Tracks_Color = new SolidBrush[]{ new SolidBrush(Color.Brown), new SolidBrush(Color.Aqua), new SolidBrush(Color.DarkGreen), new SolidBrush(Color.DarkMagenta), new SolidBrush(Color.DarkTurquoise), new SolidBrush(Color.DarkOrange), new SolidBrush(Color.FloralWhite) , new SolidBrush(Color.ForestGreen) , new SolidBrush(Color.Gold) };
        Double Zoom = 5;
        public static Bitmap Map;
        List<List<Point>> Segment_Curve = new List<List<Point>>();
        private List<Ultima_Operacion> ultima_operacion = new List<Ultima_Operacion>();
        public Form1()
        {
            InitializeComponent();
        }
        


        /*
         * Funcion de pintado de pantalla
         */
        private void Paleta_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode =  System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Graphics g = e.Graphics;
            _track.SetGraphics(ref g);
            Pen pen = new Pen(Line_Color, 2);
        SolidBrush brush = new SolidBrush(Color.Red);
            g.ScaleTransform((float)Zoom, (float)Zoom);
            g.TranslateTransform(Posicion_x, Posicion_y);
            Picasso picasso = new Picasso(g);
            if (Map!=null)
                g.DrawImage(Map, 0, 0, Paleta.Width, Paleta.Height);
            if(tracks.Count>0)
            {
                for (int i =0; i< viewToolStripMenuItem.DropDownItems.Count; i++)
                {
                   if( ((ToolStripMenuItem)viewToolStripMenuItem.DropDownItems[i]).Checked)
                    {
                        tracks[i].Draw_tracks();
                    }
                }
            }
            ///Paint Grid
            picasso.Draw_Grill(ref Origen, Zoom, Paleta.Height, Paleta.Width);
                ///Pintar Lineas
            _track.Draw_All_Lines(ref pen, ref Mouse_Button, ref Line_Button, ref Preview_Linea, ref Mouse_Position);
                
                ///Pintar Puntos
                brush.Color = Color.Green;
                _track.Draw_Line_Points(ref brush);
            brush.Color = Color.Black;
            _track.Pintar_Puntos(ref brush, ref Map_Points, 1);
            brush.Color = Color.Blue;                
            _track.Draw_Points(ref brush);
                if(Punto_Seleccionado_2!=Punto_Cero && Punto_Seleccionado_1!=Punto_Cero && _track.GetLineCount()>0)
                {
                    _track.Calculate_Curve(ref Punto_Seleccionado_1, ref Punto_Seleccionado_2, pen);
                    ultima_operacion.Add(Ultima_Operacion.Add_Curve);
                }
            _track.DrawCurves(pen);
            brush.Color = Color.Red;
            _track.FillCircle(brush, Origen);
            if(View_Equal_Point)
            picasso.DrawRectangle(new Pen(Color.SandyBrown, 1.5f),  Mouse_Position, ref g);
            if(Segment_Curve.Count>0)
            {
                pen.Color = Color.Blue;
                foreach (List<Point> Curve_ in Segment_Curve)
                {
                    g.DrawLines(pen, Curve_.ToArray());
                }
            }
        }

        private void Paleta_Click(object sender, EventArgs e)
        {
            if (Select_Origin_Button.Checked)
            {
                Picasso picasso = new Picasso();
                Cursor = new Cursor(Cursor.Current.Handle);
                Point point = Paleta.PointToClient(Cursor.Position);
                Origen=_track.Apply_Transformation(point, Zoom,Zoom * Posicion_x, Zoom * Posicion_y);  //Funcion para que de las cordenadas relativas al programa y no a la pantalal
                Paleta.Invalidate();
                Paleta.Update();
            }
            else if (!Mouse_Button.Checked && Line_Button.Checked)
            {
                _track.Add_Point(Mouse_Position);
                Paleta.Invalidate();
                Paleta.Update();
            }
            else if (Curve_Button.Checked)
            {
                _track.Select_Curve_Points(ref Punto_Seleccionado_1, ref Punto_Seleccionado_2, ref Paleta,ref Punto_Cero,  1/Zoom, ref Posicion_x, ref Posicion_y);
            }
            else
            {
                Punto_Seleccionado_2 = Punto_Cero;
                Punto_Seleccionado_1 = Punto_Cero;
                if (!Curve_Button.Checked && !Line_Button.Checked)
                {
                    _track.Select_Curve_Points(ref Punto_Arrastre, ref Punto_Seleccionado_1, ref Paleta, ref Punto_Cero, 1/Zoom, ref Posicion_x, ref Posicion_y);
                    _track.Get_Point_Index(ref Punto_Arrastre, ref Index_x, ref Index_y);
                }
            }
        }

        private void Paleta_MouseMove(object sender, MouseEventArgs e)
        {
            /// Mostrar Texto
            Mouse_Position = Paleta.PointToClient(Cursor.Position);
            Mouse_Position=_track.Apply_Transformation(Mouse_Position, 1 / Zoom, Posicion_x * Zoom, Posicion_y * Zoom);
            _track.CalculatePointAngle(ref Mouse_Position);
            View_Equal_Point=_track.Select_Points(ref Mouse_Position, 11);
            string Texto = "";
            Texto += "X: ";
            Texto += Mouse_Position.X - Origen.X;
            Texto += " Y: ";
            Texto += Mouse_Position.Y - Origen.Y;
            Posicion_Cursor.Text = Texto;
            /// Preview Linea
            Preview_Linea = true;
            Paleta.Invalidate();
            Paleta.Update();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 'w' || e.KeyValue == 'W' || e.KeyValue == 9650)
            {
                //if (Posicion_y > 0)
                    Posicion_y=Posicion_y-5;
            }
            else if (e.KeyValue == 'a' || e.KeyValue == 'A' || e.KeyValue == 9668)
            {
                //if (Posicion_x > 0)
                    Posicion_x=Posicion_x-5;
            }
            else if (e.KeyValue == 's' || e.KeyValue == 'S' || e.KeyValue == 9660)
            {
                //if (Posicion_y < 400)
                    Posicion_y=Posicion_y+5;
            }
            else if ((e.KeyValue == 'd' || e.KeyValue == 'D' || e.KeyValue == 9658)&& !e.Control)
            {
                //if (Posicion_x < 800)
                    Posicion_x=Posicion_x+5;
            }
            else if(e.Control && (e.KeyValue=='d' || e.KeyValue =='D'))
            {
                toolStripButton1_Click_1(null, new EventArgs());
            }
            else if(e.Control && (e.KeyValue=='z' || e.KeyValue=='Z'))
            {
                _track.Delete_Last_Operation();
            }
            else if(e.Control && (e.KeyValue == 'y' || e.KeyValue == 'Y'))
            {
                _track.Redo();
            }
            Paleta.Invalidate();
            Paleta.Update();
        }
        private void cargarMapaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 forma = new Form3();
            forma.Show();
        }

        private void cargarTrayectoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Explorador explorador = new Explorador(Paleta.Height, Origen);
            explorador.Abrir_Explorador();
            if (explorador.Lineas != null || explorador.Curvas != null)
            {
                ultima_operacion.Clear();
                toolStripButton1_Click_1(sender, e);
                if (explorador.Lineas != null)
                    _track.SetLines(explorador.Lineas);
                if (explorador.Curvas != null)
                    _track.SetCurves(explorador.Curvas);
            }
        }

        private void Exportar_Trayectoria_Menu1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_track.GetLineCount()> 0 || tracks.Count>0)
                {
                    ComboBoxDialog comboBoxDialog = new ComboBoxDialog(ref tracks);
                    comboBoxDialog.ShowDialog();
                    Tracks Selected_track = comboBoxDialog.Selected_track;
                    comboBoxDialog.Close();
                    if (Selected_track != null)
                    {
                        Explorador explorador = new Explorador(Selected_track.GetPoints(), Selected_track.GetLines(), Selected_track.GetCurves(), Selected_track.GetName(),Paleta.Height, Origen);
                        explorador.Guardar_Explorador();
                    }
                }
                else
                {
                    MessageBox.Show("No hay sufientes puntos");
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Error, Null reference exception");
                toolStripButton1_Click_1(sender, e);
            }
        }

        private void Select_Origin_Button_Click(object sender, EventArgs e)
        {
            foreach (ToolStripButton item in ((ToolStripButton)sender).GetCurrentParent().Items)
            {
                if (item == sender) item.Checked = true;
                if ((item != null) && (item != sender))
                {
                    item.Checked = false;
                }
            }
        }
        //Delete Everything
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            _track.Delete_All();
            Paleta.Invalidate();
            Paleta.Update();
        }

        private void Delete_Last_Click(object sender, EventArgs e)
        {
            _track.Delete_Last_Operation();
            Paleta.Invalidate();
            Paleta.Update();
        }

        private void Mathematical_Edition_Click(object sender, EventArgs e)
        {
            List<List<Point>> Lines = new List<List<Point>>();
            List<List<Point>> Curves = new List<List<Point>>();
            //Lines.AddRange(_track.GetLines());
            //Curves.AddRange(_track.GetCurves());
            Form2 forma_siguiente = new Form2( ref _track,  ref tracks, Origen, ref Paleta);
            forma_siguiente.Show();
            forma_siguiente.Activate();
        }

        private void Add_Track_Click(object sender, EventArgs e)
        {
            string _Name = Microsoft.VisualBasic.Interaction.InputBox("Introduce el nombre que le quiere dar a su track", "Añadir nombre", "Track");
            if (_Name != "")
            {
                try
                {
                    _track.SetColor(CheckColors());
                }
                catch (IndexOutOfRangeException)
                {
                    _track.SetColor(new SolidBrush(Color.Red));
                    MessageBox.Show("Ha llegado al limite de tracks, por favor elimine un track");
                }
                CheckNames(ref _Name);
                _track.SetName(_Name);
                MessageBox.Show(this, _track.GetName() + " has been added", "track added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tracks.Add(new Tracks(_track.GetLines(), _track.GetCurves(), _track.GetColor(), _track.GetName()));
                viewToolStripMenuItem.DropDownItems.Add(_track.GetName(), null, Tracks_View_OnClickHandler);
                deleteTrackToolStripMenuItem.DropDownItems.Add(_track.GetName(), null, Tracks_Delete_OnClickHandler);

                for (int i = 0; i < viewToolStripMenuItem.DropDownItems.Count; i++)
                {
                    ((ToolStripMenuItem)viewToolStripMenuItem.DropDownItems[i]).CheckOnClick = true;
                }
                toolStripButton1_Click_1(null, new EventArgs());
                Track_Edit_Select.Items.Clear();
                foreach (Tracks track in tracks)
                    Track_Edit_Select.Items.Add(track.GetName());
            }
        }

        private void exportarMapaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Explorador explorador = new Explorador();
            explorador.Guardar_Explorador(ref Map);
        }

        private void Track_Caption_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Track_Caption.Text = "";
            Font font = new Font(FontFamily.Families.First(s => s.Name.Contains("Adobe")), 24f, FontStyle.Bold);
            int j = new int();
            for (int i = 0; i < viewToolStripMenuItem.DropDownItems.Count; i++)
            {
                if (((ToolStripMenuItem)viewToolStripMenuItem.DropDownItems[i]).Checked)
                {
                    
                    g.DrawString(tracks[i].GetName() + "\n", font , tracks[i].GetColor(), 0, j*24);
                    j++;
                }
            }
        }
        private void Track_Edit_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Track_Edit_Select.SelectedItem.ToString() != "Track actual")
            {
                _track.Delete_All();
                _track.Add_Lines(tracks[Track_Edit_Select.SelectedIndex].GetLines());
                _track.Add_Curves(tracks[Track_Edit_Select.SelectedIndex].GetCurves());
                Line_Color = tracks[Track_Edit_Select.SelectedIndex].GetColor().Color;
                _track.SetName("Track actual");
                Paleta.Invalidate();
                Paleta.Update();
            }
        }

        private void Save_Changes_Click(object sender, EventArgs e)
        {
            try
            {
                tracks[Track_Edit_Select.SelectedIndex].Delete_All();
                tracks[Track_Edit_Select.SelectedIndex].Add_Lines(_track.GetLines());
                tracks[Track_Edit_Select.SelectedIndex].Add_Curves(_track.GetCurves());
                toolStripButton1_Click_1(null, new EventArgs());
                Paleta.Invalidate();
                Paleta.Update();
            }
            catch(ArgumentOutOfRangeException)
            {
            }
        }

        private void Color_Select_Click(object sender, EventArgs e)
        {

            if (colorDialog1.ShowDialog()==DialogResult.OK)
            {
                Line_Color = colorDialog1.Color;
                Paleta.Invalidate();
                Paleta.Update();
            }
        }

        private void Line_Button_Click(object sender, EventArgs e)
        {
            foreach (ToolStripButton item in ((ToolStripButton)sender).GetCurrentParent().Items)
            {
                if (item == sender) item.Checked = true;
                if ((item != null) && (item != sender))
                {
                    item.Checked = false;
                }
            }
        }

        private void Curve_Button_Click(object sender, EventArgs e)
        {
            foreach (ToolStripButton item in ((ToolStripButton)sender).GetCurrentParent().Items)
            {
                if (item == sender) item.Checked = true;
                if ((item != null) && (item != sender))
                {
                    item.Checked = false;
                }
            }
        }

        private void Mouse_Button_Click(object sender, EventArgs e)
        {
            foreach (ToolStripButton item in ((ToolStripButton)sender).GetCurrentParent().Items)
            {
                if (item == sender) item.Checked = true;
                if ((item != null) && (item != sender))
                {
                    item.Checked = false;
                }
            }
            if (_track.GetPointsCount() > 1 && !Line_Button.Checked)
            {
                _track.Add_Line();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ChangeOriginDiaog changeOriginDiaog = new ChangeOriginDiaog(Origen);
            changeOriginDiaog.ShowDialog();
            Origen = changeOriginDiaog.Origin;
            changeOriginDiaog.Close();
            Paleta.Invalidate();
            Paleta.Update();
        }

        private void codesysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tracks.Count > 0)
            {
                ComboBoxDialog comboBoxDialog = new ComboBoxDialog(ref tracks);
                if (comboBoxDialog.ShowDialog() == DialogResult.OK)
                {
                    Tracks Selected = comboBoxDialog.Selected_track;
                    comboBoxDialog.Close();
                    Segment_Curve.Clear();
                    int Number = GetDivideSegmentNumber();
                    AddSegmentPoints(ref Selected, Number);
                    ConstantsAndTypes.TypesOfTrack type = new ConstantsAndTypes.TypesOfTrack();
                    int index = new int();
                    bool type_of_object = new bool();
                    List<List<Point>> Open_Points = new List<List<Point>>();
                    List<Point> Export_Points = new List<Point>();
                    type = CheckContinuity.Check(Selected.GetLines(), ref Segment_Curve, ref index, ref type_of_object, ref Open_Points);
                    switch (type)
                    {
                        case ConstantsAndTypes.TypesOfTrack.ClosedTrack:
                            MessageBox.Show(this, "Is a close track", "Closed track", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Export_Points.AddRange(CodesysPoints(ref Selected));
                            Explorador.Guardar_Explorador(ref Export_Points, Origen);
                            break;
                        case ConstantsAndTypes.TypesOfTrack.SemiClosedTrack:
                            MessageBox.Show(this, "Is a semiclosed track", "Closed track", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (Open_Points.Count == 2)
                            {
                                CodesysPoints(ref Selected, ref Open_Points);
                                Export_Points.AddRange(CodesysPoints(ref Selected, ref Open_Points));
                                Explorador.Guardar_Explorador(ref Export_Points, Origen);
                            }

                            break;
                        case ConstantsAndTypes.TypesOfTrack.OpenTracK:
                            MessageBox.Show(this, "Is an Open Track", "Closed track", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                    }
                }               
            }
            else
                MessageBox.Show(this, "There isn't saved tracks in the program, please save a track", "No tracks", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Zoom = trackBar1.Value;
            Zoom = -0.4 * Zoom + 5.8;
            Paleta.Invalidate();
            Paleta.Update();
        }

        private void Paleta_MouseUp(object sender, MouseEventArgs e)
        {
            Punto_Arrastre = new Point();
        }

        private void Paleta_MouseLeave(object sender, EventArgs e)
        {
            Posicion_Cursor.ResetText();
            Preview_Linea = false;
            Paleta.Invalidate();
            Paleta.Update();
        }
        private void Tracks_View_OnClickHandler(object sender, EventArgs e)
        {
            // var result = MessageBox.Show(this, "Doing this action will delete all the active work\n Do you want to continue", "Warning", MessageBoxButtons.OKCancel);
            Track_Caption.Invalidate();
            Track_Caption.Update();
        }
        private void Tracks_Delete_OnClickHandler(object sender, EventArgs e)
        {
            tracks.RemoveAt(tracks.FindIndex(track => track.GetName()==sender.ToString()));
            tracks.OrderBy(x => x.GetName());
            Track_Edit_Select.Items.Clear();
            viewToolStripMenuItem.DropDownItems.Clear();
            deleteTrackToolStripMenuItem.DropDownItems.Clear();
            foreach (Tracks track in tracks)
            {
                Track_Edit_Select.Items.Add(track.GetName());
                viewToolStripMenuItem.DropDownItems.Add(track.GetName(), null, Tracks_View_OnClickHandler);
                deleteTrackToolStripMenuItem.DropDownItems.Add(track.GetName(), null, Tracks_Delete_OnClickHandler);
            }
            for (int i = 0; i < viewToolStripMenuItem.DropDownItems.Count; i++)
            {
                ((ToolStripMenuItem)viewToolStripMenuItem.DropDownItems[i]).CheckOnClick = true;
            }
            Track_Caption.Refresh();
        }
        private void CheckNames(ref string _Name)
        {
            string[] buffer_names = new string[tracks.Count];
            int i = new int();
            foreach (Tracks track in tracks)
            {
                buffer_names[i] = track.GetName();
                i++;
            }
            CheckNamesIterator(ref _Name, ref buffer_names);
        }
        private void CheckNamesIterator(ref string _Name, ref string []buffer_names)
        {
            if (buffer_names.Any(_Name.Equals) && _Name.Contains("("))
            {
                string[] Buffer_Name = _Name.Split('(');
                try
                {
                    int Number = Convert.ToInt16(Regex.Match(Buffer_Name[1], @"\d+").Value);
                    Buffer_Name[0] += "(" + (Number + 1).ToString() + ")";
                    _Name = Buffer_Name[0];
                }
                catch(FormatException)
                {

                }
                CheckNamesIterator(ref _Name, ref buffer_names);

            }
            else if (buffer_names.Any(_Name.Equals))
            {
                _Name += "(1)";
                CheckNamesIterator(ref _Name, ref buffer_names);
            }
        }
        private SolidBrush CheckColors()
        {
            SolidBrush color = new SolidBrush(Tracks_Color[0].Color);
            SolidBrush[] colors = new SolidBrush[tracks.Count];
            for(int i=0; i<tracks.Count; i++)
            {
                colors[i] = tracks[i].GetColor();
            }
            bool Exit = new bool();
            if (colors.Any(c => c.Color==color.Color))
            {
                for (int i = 0; i < Tracks_Color.Count() && Exit==false ; i++)
                {
                    if(!colors.Any(c=> c.Color==Tracks_Color[i].Color))
                    {
                        color = Tracks_Color[i];
                        Exit = true;
                    }

                }
            }
            return color;
        }
      /*  private List<Point> CodesysPoints(int index, bool type_of_object)
        {
            List<Point> First_Object = new List<Point>();
            if (type_of_object==false)
            {

            }
            else
            {

            }
        }*/
        private List<Point> CodesysPoints(ref Tracks Selected)
        {
            List<Point> Array_Points = new List<Point>();
            List<Point> First_Object = new List<Point>();
            List<Point> Actual_Object = new List<Point>();
            List<Point> Last_Object = new List<Point>();
            List<Point> Next_Object = new List<Point>();
            First_Object.AddRange(Selected.GetLines()[0]);
            Actual_Object.AddRange(Selected.GetLines()[0]);
            Last_Object.AddRange(Selected.GetLines()[0]);
            Array_Points.AddRange(Selected.GetLines()[0]);
            do
            {
                if(Next_Object.Count>0)
                    Array_Points.AddRange(Next_Object);
                Next_Object.Clear();
                try
                {
                    Next_Object.AddRange(CheckContinuity.PointNextObject(Selected.GetLines(), ref Segment_Curve, Actual_Object[Actual_Object.Count - 1], Actual_Object[0], ConstantsAndTypes.TypesOfTrack.ClosedTrack));
                }
                catch (ArgumentOutOfRangeException)
                {
                    Next_Object.Clear();
                }
                if (Next_Object.SequenceEqual(Last_Object) || Next_Object.Count==0)
                {
                    Next_Object.Clear();
                    Next_Object.AddRange(CheckContinuity.PointNextObject(Selected.GetLines(), ref Segment_Curve, Actual_Object[0], Actual_Object[Actual_Object.Count - 1], ConstantsAndTypes.TypesOfTrack.SemiClosedTrack));

                }
                Last_Object.Clear();
                Last_Object.AddRange(Actual_Object);
                Actual_Object.Clear();
                Actual_Object.AddRange(Next_Object);
            }
            while (!Actual_Object.SequenceEqual(First_Object));
            Array_Points.AddRange(Next_Object);
            Array_Points=Array_Points.Distinct().ToList();
            Array_Points.Add(First_Object[First_Object.Count - 1]);
            Segment_Curve.Clear();
            Segment_Curve.Add(Array_Points);
            return Array_Points;
        }
        private List<Point> CodesysPoints(ref Tracks Selected, ref List<List<Point>> Open_Points)
        {
            string[] Objects = { "Array_Points", "First_Object", "Actual_Object", "Last_Object", "Next_Object", "Finish_Object"};
            Dictionary<ConstantsAndTypes.Using_Points, List<Point>> Important_Points = new Dictionary<ConstantsAndTypes.Using_Points, List<Point>>();
            Important_Points.Add(ConstantsAndTypes.Using_Points.Array_Points, new List<Point>());
            Important_Points.Add(ConstantsAndTypes.Using_Points.Actual_Object, new List<Point>());
            Important_Points.Add(ConstantsAndTypes.Using_Points.Finish_Object, new List<Point>());
            Important_Points.Add(ConstantsAndTypes.Using_Points.First_Object, new List<Point>());
            Important_Points.Add(ConstantsAndTypes.Using_Points.Last_Object, new List<Point>());
            Important_Points.Add(ConstantsAndTypes.Using_Points.Next_Object, new List<Point>());
            Important_Points[ConstantsAndTypes.Using_Points.Array_Points].AddRange(Open_Points[0]);
            Important_Points[ConstantsAndTypes.Using_Points.Finish_Object].AddRange(Open_Points[1]);
            Important_Points[ConstantsAndTypes.Using_Points.Actual_Object].AddRange(Open_Points[0]);
            Important_Points[ConstantsAndTypes.Using_Points.Last_Object].AddRange(Open_Points[0]);
            Important_Points[ConstantsAndTypes.Using_Points.First_Object].AddRange(Open_Points[0]);
            do
            {
                if (Important_Points[ConstantsAndTypes.Using_Points.Next_Object].Count > 0)
                    Important_Points[ConstantsAndTypes.Using_Points.Array_Points].AddRange(Important_Points[ConstantsAndTypes.Using_Points.Next_Object]);
                Important_Points[ConstantsAndTypes.Using_Points.Next_Object].Clear();
                try
                {
                    Important_Points[ConstantsAndTypes.Using_Points.Next_Object].AddRange(CheckContinuity.PointNextObject(Selected.GetLines(), ref Segment_Curve, Important_Points[ConstantsAndTypes.Using_Points.Actual_Object][Important_Points[ConstantsAndTypes.Using_Points.Actual_Object].Count - 1], Important_Points[ConstantsAndTypes.Using_Points.Actual_Object][0], ConstantsAndTypes.TypesOfTrack.ClosedTrack));
                }
                catch(ArgumentOutOfRangeException)
                {
                    Important_Points[ConstantsAndTypes.Using_Points.Next_Object].Clear();
                }
                if (Important_Points[ConstantsAndTypes.Using_Points.Next_Object].SequenceEqual(Important_Points[ConstantsAndTypes.Using_Points.Last_Object]) || Important_Points[ConstantsAndTypes.Using_Points.Next_Object].Count<=0)
                {
                    Important_Points[ConstantsAndTypes.Using_Points.Next_Object].Clear();
                    try
                    {
                        Important_Points[ConstantsAndTypes.Using_Points.Next_Object].AddRange(CheckContinuity.PointNextObject(Selected.GetLines(), ref Segment_Curve, Important_Points[ConstantsAndTypes.Using_Points.Actual_Object][0], Important_Points[ConstantsAndTypes.Using_Points.Actual_Object][Important_Points[ConstantsAndTypes.Using_Points.Actual_Object].Count - 1], ConstantsAndTypes.TypesOfTrack.ClosedTrack));
                    }
                    catch(ArgumentOutOfRangeException)
                    {
                        Important_Points[ConstantsAndTypes.Using_Points.Next_Object].Clear();
                        Important_Points[ConstantsAndTypes.Using_Points.Next_Object].AddRange(CheckContinuity.PointNextObject(Selected.GetLines(), ref Segment_Curve, Important_Points[ConstantsAndTypes.Using_Points.Actual_Object][Important_Points[ConstantsAndTypes.Using_Points.Actual_Object].Count - 1], Important_Points[ConstantsAndTypes.Using_Points.Actual_Object][0], ConstantsAndTypes.TypesOfTrack.ClosedTrack));
                    }
                }
                Important_Points[ConstantsAndTypes.Using_Points.Last_Object].Clear();
                Important_Points[ConstantsAndTypes.Using_Points.Last_Object].AddRange(Important_Points[ConstantsAndTypes.Using_Points.Actual_Object]);
                Important_Points[ConstantsAndTypes.Using_Points.Actual_Object].Clear();
                Important_Points[ConstantsAndTypes.Using_Points.Actual_Object].AddRange(Important_Points[ConstantsAndTypes.Using_Points.Next_Object]);
            }
            while (!Important_Points[ConstantsAndTypes.Using_Points.Actual_Object].SequenceEqual(Important_Points[ConstantsAndTypes.Using_Points.Finish_Object]));
            Important_Points[ConstantsAndTypes.Using_Points.Array_Points].AddRange(Important_Points[ConstantsAndTypes.Using_Points.Finish_Object]);
            Important_Points[ConstantsAndTypes.Using_Points.Array_Points] = Important_Points[ConstantsAndTypes.Using_Points.Array_Points].Distinct().ToList();
            Segment_Curve.Clear();
            Segment_Curve.Add(Important_Points[ConstantsAndTypes.Using_Points.Array_Points]);
            return Important_Points[ConstantsAndTypes.Using_Points.Array_Points];
        }
        private int GetDivideSegmentNumber()
        {
            int Number = new int();
            do
            {
                string number_string = Microsoft.VisualBasic.Interaction.InputBox(String.Format("Introduce the numers in which you want to divide the curve [{0}-{1}]", Min_Divide_Points, Max_Divide_Points), "Introduce numbers", "20");
                try
                {
                    Number = Convert.ToInt32(number_string);
                }
                catch (FormatException)
                {
                    Number = -1;
                }
                finally
                {
                    if (Number < 5 || Number > 2000)
                    {
                        MessageBox.Show(this, String.Format("It's not a valid number, please write down a valid number [{0}-{1}]", Min_Divide_Points, Max_Divide_Points), "Number not valid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Number = -1;
                    }
                }

            } while (Number <= -1);
            return Number;
        }
        private void AddSegmentPoints(ref Tracks Selected, int Number)
        {
            if (Selected.GetCurveCount() > 0)
            {
                List<Point> Buffer = new List<Point>();
                for (int i = 0; i < Selected.GetCurveCount(); i++)
                {
                    Buffer.AddRange(Selected.GetCurves()[i]);
                    Segment_Curve.Add(GetBeziersPoints.GetSegments_EcuationMethod(ref Buffer, Number));
                    Buffer.Clear();
                }
            }
        }






    }
}
