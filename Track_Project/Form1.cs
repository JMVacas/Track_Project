using System;
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
    enum Ultima_Operacion
    {
        Add_Line,
        Add_Point,
        Add_Curve
    };

    public partial class Form1 : Form
    {
        const int Infinite_X = 214748360; const int Infinite_Y = 214748360;
        private List<List<Point>> lineas = new List<List<Point>>();
        private List<Point> points = new List<Point>();
        private List<Point> Map_Points = new List<Point>();
        private List<List<Point>>Puntos_Curva = new List<List<Point>>();
        private Point Origen = new Point(385, 208), Punto_Arrastre=new Point ();
        private Point Punto_Seleccionado_1 = new Point(), Punto_Seleccionado_2 = new Point(), Punto_Cero = new Point(), Mouse_Position = new Point();
        private bool Preview_Linea, View_Equal_Point;
        private int Index_x, Index_y, Posicion_x, Posicion_y;
        private List <Tracks> tracks = new List<Tracks>();
        public Color Line_Color = Color.DarkRed;
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
            Pen pen = new Pen(Line_Color, 2);
        SolidBrush brush = new SolidBrush(Color.Red);
            g.ScaleTransform((float)Zoom, (float)Zoom);
            g.TranslateTransform(Posicion_x, Posicion_y);
            Picasso picasso = new Picasso(g);
            if (Map!=null)
            g.DrawImage(Map, 0, 0, Paleta.Width, Paleta.Height);
            
            ///Paint Grid
            picasso.Draw_Grill(ref Origen, Zoom, Paleta.Height, Paleta.Width);
                ///Pintar Lineas
                picasso.Pintar_Lineas(ref lineas, ref pen, ref points, ref Paleta, ref Mouse_Button, ref Line_Button, ref Preview_Linea, 1/Zoom, ref Posicion_x, ref Posicion_y, ref Mouse_Position);
                
                ///Pintar Puntos
                brush.Color = Color.Green;
            foreach (List<Point> linea in lineas)
                {
                    picasso.Pintar_Puntos(ref brush, linea);
                }
            brush.Color = Color.Black;
            picasso.Pintar_Puntos(ref brush, Map_Points, 1);
            brush.Color = Color.Blue;                
            picasso.Pintar_Puntos(ref brush, points);
                if(Punto_Seleccionado_2!=Punto_Cero && Punto_Seleccionado_1!=Punto_Cero && lineas.Count>0)
                {
                    picasso.Calcular_Curva(ref pen, ref lineas, ref Punto_Seleccionado_1, ref Punto_Seleccionado_2, ref Puntos_Curva);
                    ultima_operacion.Add(Ultima_Operacion.Add_Curve);
                }
            picasso.DrawCurves(ref Puntos_Curva, pen);
            brush.Color = Color.Red;
            picasso.FillCircle(brush, Origen);
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
                picasso.Transform_Coordenadas(ref point, Zoom * Posicion_x, Zoom * Posicion_y);
                picasso.ZOOM(ref point, 1 / Zoom);//Funcion para que de las cordenadas relativas al programa y no a la pantalal
                Origen = point;
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
                points.Add(Mouse_Position);
                Paleta.Invalidate();
                Paleta.Update();
            }
            else if (Curve_Button.Checked && lineas.Count>0)
            {
                Picasso picasso = new Picasso();
                picasso.Seleccionar_Punto(ref Punto_Seleccionado_1, ref Punto_Seleccionado_2, ref lineas, ref Paleta, ref Punto_Cero,  1/Zoom, ref Posicion_x, ref Posicion_y);
                //picasso.Cambiar_Punto(ref Punto_Seleccionado_1);
                

            }
            else
            {
                Punto_Seleccionado_2 = Punto_Cero;
                Punto_Seleccionado_1 = Punto_Cero;
                if (!Curve_Button.Checked && !Line_Button.Checked)
                {
                    Picasso picasso = new Picasso();
                    picasso.Seleccionar_Punto(ref Punto_Arrastre, ref Punto_Seleccionado_1, ref lineas, ref Paleta, ref Punto_Cero, 1/Zoom, ref Posicion_x, ref Posicion_y);
                    picasso.Get_Point_Index(ref Punto_Arrastre, ref lineas, ref Index_x, ref Index_y);
                }
            }
        }

        private void Paleta_MouseMove(object sender, MouseEventArgs e)
        {
            /// Mostrar Texto
            Mouse_Position = Paleta.PointToClient(Cursor.Position);
            Picasso picasso = new Picasso();
            picasso.Transform_Coordenadas(ref Mouse_Position, Posicion_x*Zoom, Posicion_y*Zoom);
            picasso.ZOOM(ref Mouse_Position, 1 / Zoom);
            if(points.Count>0)
                picasso.CalculatePointAngle(ref Mouse_Position, points[points.Count - 1]);
            View_Equal_Point=picasso.Seleccionar_Punto(ref lineas, ref Mouse_Position, 11);
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

        private void Form1_KeyDown(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'w' || e.KeyChar == 'W' || e.KeyChar == 9650)
            {
                //if (Posicion_y > 0)
                    Posicion_y=Posicion_y-5;
            }
            else if (e.KeyChar == 'a' || e.KeyChar == 'A' || e.KeyChar == 9668)
            {
                //if (Posicion_x > 0)
                    Posicion_x=Posicion_x-5;
            }
            else if (e.KeyChar == 's' || e.KeyChar == 'S' || e.KeyChar == 9660)
            {
                //if (Posicion_y < 400)
                    Posicion_y=Posicion_y+5;
            }
            else if (e.KeyChar == 'd' || e.KeyChar == 'D' || e.KeyChar == 9658)
            {
                //if (Posicion_x < 800)
                    Posicion_x=Posicion_x+5;
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
                    lineas = explorador.Lineas;
                if (explorador.Curvas != null)
                    Puntos_Curva = explorador.Curvas;
            }
        }

        private void Exportar_Trayectoria_Menu1_Click(object sender, EventArgs e)
        {
            try
            {
                if (lineas.Count > 0)
                {
                    Explorador explorador = new Explorador(points, lineas, Puntos_Curva, Paleta.Height);
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
            if (Puntos_Curva != null)
                Puntos_Curva.Clear();
            if (lineas != null)
                lineas.Clear();
            if (points != null)
                points.Clear();         //Borra toda la lista
            Paleta.Invalidate();
            Paleta.Update();
        }

        private void Delete_Last_Click(object sender, EventArgs e)
        {
            if (ultima_operacion.Count > 0)
            {
                if (points.Count > 0 && ultima_operacion[ultima_operacion.Count - 1] == Ultima_Operacion.Add_Point)
                    points.RemoveAt(points.ToArray().Length - 1);
                else if (lineas.Count > 0 && ultima_operacion[ultima_operacion.Count - 1] == Ultima_Operacion.Add_Line)
                    lineas.RemoveAt(lineas.Count - 1);
                else if (Puntos_Curva.Count > 0 && ultima_operacion[ultima_operacion.Count - 1] == Ultima_Operacion.Add_Curve)
                    Puntos_Curva.RemoveAt(Puntos_Curva.Count - 1);
                ultima_operacion.RemoveAt(ultima_operacion.Count - 1);
                Paleta.Invalidate();
                Paleta.Update();
            }
        }

        private void Mathematical_Edition_Click(object sender, EventArgs e)
        {
            Form2 forma_siguiente = new Form2(ref lineas, ref Puntos_Curva, Origen, ref Paleta);
            forma_siguiente.Show();
            Explorador explorador = new Explorador();
        }

        private void exportarMapaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Explorador explorador = new Explorador();
            explorador.Guardar_Explorador(ref Map);
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
            if (points.Count > 1 && !Line_Button.Checked)
            {
                Point[] Buffer = new Point[points.Count];
                Buffer = points.ToArray();
                for (int i = 0; i < Buffer.Length - 1; i++)
                {
                    Point[] Concat = new Point[2];
                    Concat[0] = Buffer[i];
                    Concat[1] = Buffer[i + 1];
                    lineas.Add(Concat.ToList());
                    ultima_operacion.Add(Ultima_Operacion.Add_Line);
                }
                points.Clear();
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

    }
}
