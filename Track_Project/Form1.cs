﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
        private List<Point> Map_Points = new List<Point>();
        private Point Origen = new Point(385, 208), Punto_Arrastre=new Point ();
        private Point Punto_Seleccionado_1 = new Point(), Punto_Seleccionado_2 = new Point(), Punto_Cero = new Point(), Mouse_Position = new Point();
        private bool Preview_Linea, View_Equal_Point;
        private int Index_x, Index_y, Posicion_x, Posicion_y;
        private List <Tracks> tracks = new List<Tracks>();
        private Tracks _track = new Tracks();
        public Color Line_Color = Color.DarkRed;
        private readonly SolidBrush[] Tracks_Color = new SolidBrush[]{ new SolidBrush(Color.Brown), new SolidBrush(Color.Aqua), new SolidBrush(Color.DarkGreen), new SolidBrush(Color.DarkMagenta), new SolidBrush(Color.DarkTurquoise), new SolidBrush(Color.DarkOrange) };
        Double Zoom = 5;
        public static Bitmap Map;
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
                /*Picasso picasso = new Picasso();
                Cursor = new Cursor(Cursor.Current.Handle);
                Point point = Paleta.PointToClient(Cursor.Position);
                picasso.Transform_Coordenadas(ref point, Zoom*Posicion_x, Zoom*Posicion_y);//Funcion para que de las cordenadas relativas al programa y no a la pantalal
                picasso.ZOOM(ref point, 1/Zoom);*/
                _track.Add_Point(Mouse_Position);
                Paleta.Invalidate();
                Paleta.Update();
            }
            else if (Curve_Button.Checked)
            {
                _track.Select_Curve_Points(ref Punto_Seleccionado_1, ref Punto_Seleccionado_2, ref Paleta,ref Punto_Cero,  1/Zoom, ref Posicion_x, ref Posicion_y);
                //picasso.Cambiar_Punto(ref Punto_Seleccionado_1);
                

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
            Paleta.Invalidate();
            Paleta.Update();
        }

        private void Borrar_Todo_Menu1_Click(object sender, EventArgs e)
        {
        }

        private void borrarAnteriorToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void cargarMapaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 forma = new Form3();
            forma.Show();
        }

        private void cargarTrayectoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Explorador explorador = new Explorador(Paleta.Height);
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
                if (_track.GetLineCount()> 0)
                {
                    Explorador explorador = new Explorador(_track.GetPoints(), _track.GetLines(), _track.GetCurves(), Paleta.Height);
                    explorador.Guardar_Explorador();
                }
                else
                {
                    MessageBox.Show("No hay sufientes puntos");
                }
            }
            catch (NullReferenceException ex)
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
                Paleta.Invalidate();
                Paleta.Update();
        }

        private void Mathematical_Edition_Click(object sender, EventArgs e)
        {
            List<List<Point>> Lines = new List<List<Point>>();
            List<List<Point>> Curves = new List<List<Point>>();
            Lines.AddRange(_track.GetLines());
            Curves.AddRange(_track.GetCurves());
            Form2 forma_siguiente = new Form2(ref Lines, ref Curves, Origen, ref Paleta);
            _track.SetLines(ref Lines);
            _track.SetCurves(ref Curves);
            Lines.Clear();
            Curves.Clear();
            forma_siguiente.Show();
        }

        private void Add_Track_Click(object sender, EventArgs e)
        {
            _track.SetColor(Tracks_Color[tracks.Count]);
            _track.SetName("Track" + (tracks.Count + 1).ToString());
            MessageBox.Show(this, _track.GetName() + " has been added", "track added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tracks.Add(new Tracks(_track.GetLines(), _track.GetCurves(), _track.GetColor(), _track.GetName()));
            viewToolStripMenuItem.DropDownItems.Add(_track.GetName(), null, Tracks_View_OnClickHandler);
            for (int i = 0; i < viewToolStripMenuItem.DropDownItems.Count; i++)
            {
                ((ToolStripMenuItem)viewToolStripMenuItem.DropDownItems[i]).CheckOnClick = true;
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
                    
                    g.DrawString(tracks[i].GetName() + "\n", font , Tracks_Color[i], 0, j*24);
                    j++;
                }
            }
        }

        private void Color_Select_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                Line_Color = colorDialog1.Color;
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
            Track_Caption.Refresh();
        }

    }
}
