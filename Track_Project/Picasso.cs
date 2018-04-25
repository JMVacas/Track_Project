using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track_Project
{
    public class Picasso
    {
        private const int Grid_Division = 40;
        /*La mision de esta funcion es poder seleccionar 2 puntos cuando haces click sobre ellos en una forma Picture_Box
         * @arg1: Variable punto_Seleccionado_1, que se guardara el primer punto que este en la linea y se haga click
         * @arg2: Lo mismo que la primera variable
         * @arg3: Lista que contiene todas las lineas
         * @arg4: La caja que contiene los elementos graficos
         * @arg5: Punto nulo
         * */
        public static Graphics g;
        public Picasso()
        {

        }
         public Picasso (Graphics _g)
        {
            g = _g;
        }
        public void Seleccionar_Punto(ref Point Punto_Seleccionado_1, ref Point Punto_Seleccionado_2, ref List<List<Point>> lineas, ref System.Windows.Forms.PictureBox Paleta, ref Point Punto_Cero,  Double Zoom, ref int Posicion_x, ref int Posicion_y)
        {
            if (Punto_Seleccionado_1 == Punto_Cero)
            {
                Point point = Paleta.PointToClient(System.Windows.Forms.Cursor.Position);
                Transform_Coordenadas(ref point, (1 / Zoom) * Posicion_x, (1 / Zoom) * Posicion_y);
                ZOOM(ref point, Zoom);
                for (int i = 0; i < lineas.ToArray().Length; i++)
                {
                    if (Exists(point, ref lineas, ref i, 20))
                    {
                        Punto_Seleccionado_1 = Find(point, ref lineas, ref i, 20);
                        //System.Windows.Forms.MessageBox.Show(string.Format("Ha seleccionado el punto_1 {0}, {0} ", Punto_Seleccionado_1.X + Punto_Seleccionado_1.Y));
                    }
                }
            }
            else if (Punto_Seleccionado_1 != Punto_Cero && Punto_Seleccionado_2 == Punto_Cero)
            {
                Point point = Paleta.PointToClient(System.Windows.Forms.Cursor.Position);
                Transform_Coordenadas(ref point, (1 / Zoom) * Posicion_x, (1 / Zoom) * Posicion_y);
                ZOOM(ref point, Zoom);
                for (int i = 0; i < lineas.ToArray().Length; i++)
                {
                    if (Exists(point, ref lineas, ref i, 20))
                    {
                        if (Find(point, ref lineas, ref i, 20) == Punto_Seleccionado_1)
                        {
                            Punto_Seleccionado_1 = Punto_Cero;
                        }
                        else
                        {
                            Punto_Seleccionado_2 = Find(point, ref lineas, ref i, 20);                          
                            //System.Windows.Forms.MessageBox.Show(string.Format("Ha seleccionado el punto_2 {0}, {0} ", Punto_Seleccionado_2.X + Punto_Seleccionado_2.Y));
                        }
                    }
                }
            }
        }
        /*
         * Comprueba si existe un punto dentro de un array de puntos
         * @ret: bool
         * @arg1: Punto a comprobar
         * @arg2: Array de lineas
         * @arg3: index del array de lineas
         * @arg4: radio de precision(10 por defecto)
         * */
        public bool Exists(Point point, ref List<List<Point>> lineas, ref int i, int radio = 10)
        {
            return lineas[i].Exists(x => (x.X > point.X - radio && x.X < point.X + radio) && (x.Y > point.Y - radio && x.Y < point.Y + radio));
        }
        /*
         * Retorna el primer punto encontrado dentro de un array de puntos
         * @ret: bool
         * @arg1: Punto a comprobar
         * @arg2: Array de lineas
         * @arg3: index del array de lineas
         * @arg4: radio de precision(10 por defecto)
         * */
        public Point Find(Point point, ref List<List<Point>> lineas, ref int i, int radio = 10)
        {
            return lineas[i].Find(x => (x.X > point.X - radio && x.X < point.X + radio) && (x.Y > point.Y - radio && x.Y < point.Y + radio));
        }
        /*
         * Funcion que muestra los puntos que estan en la linea actual
         * @arg1 Brush de relleno para darle color al punto
         * @arg2 Lista de puntos de la linea actual
         * @arg3 Graficos para dibujar los puntos
         **/
        public void Pintar_Puntos(ref SolidBrush brush, List<Point> points)
        {
            for (int i = 0; i < points.ToArray().Length; i++)
            {
                FillCircle(brush, points[i]);
            }
        }
        public void Pintar_Puntos(ref SolidBrush brush, List<Point> points, int Radius)
        {
            for (int i = 0; i < points.ToArray().Length; i++)
            {
                FillCircle(brush, points[i], Radius);
            }
        }
        /*
         * Esta funcion es capaz de dibujar las lineas y una preview de las lineas
         * @arg1 Lista de lineas
         * @arg2 Estilo de las lineas
         * @arg3 Lista de puntos para la preview
         * @arg4 PictureBox donde se van a pintar los graficos
         * @arg5 RadioButton para comprobar si hay que dibujar la preview
         * @arg6 RadioButton para comprobar si hay que dibujar la preview
         * @arg6 Booleano para comprobar si hay que dibujar la preview 
         * @arg7 Graficos necesarios para dibujar
         * */
        public void Pintar_Lineas(ref List<List<Point>> lineas, ref Pen pen, ref List<Point> points, ref System.Windows.Forms.PictureBox Paleta, ref System.Windows.Forms.ToolStripButton Herramienta_Dibujo, ref System.Windows.Forms.ToolStripButton Linea, ref bool Preview_Linea,  Double Zoom, ref int Posicion_x, ref int Posicion_y, ref Point Mouse_Position)
        {
            try
            {
                if (lineas.Count > 0)
                {
                    Mostrar_Lineas(ref pen, ref lineas);
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                System.Windows.Forms.MessageBox.Show("Error");
            }
            if (points.Count > 1)
            {
                g.DrawLines(pen, points.ToArray());
            }
            ///Pintar Preview
            if (points.Count > 0 && Preview_Linea && !Herramienta_Dibujo.Checked && Linea.Checked)
            {
                Point[] preview = new Point[2];
                preview[0] = points.ToArray()[points.ToArray().Length - 1];
                preview[1] = Mouse_Position;
                g.DrawLines(pen, preview);
            }
        }
        /*
         * @arg1 Estilo de la linea
         * @arg2 Lista de puntos que definen a las lineas
         * @arg3 Graficos para dibujar
         * */
        public void Mostrar_Lineas(ref Pen pen, ref List<List<Point>> lineas)
        {
            for (int i = 0; i < lineas.Count; i++)
            {
                List<Point> Buffer = new List<Point>();
                for (int j = 0; j < lineas[i].Capacity; j++)
                {
                    Buffer.Add(lineas[i][j]);
                }
                g.DrawLines(pen, Buffer.ToArray());
            }
        }
        /*
         * Funcion que se utiliza para  mostrar las curvas ya realizadas
         * @arg1 introduces el pen, que define el estilo de la curva
         * @arg2 Lista de curvas
         * @arg3 componente grafico para dibujar
         * */
        public void Mostrar_Curva(ref Pen pen, ref List<List<Point>> Curvas)
        {
            {
                for (int i = 0; i < Curvas.Count; i++)
                {
                    List<Point> Buffer = new List<Point>();
                    for (int j = 0; j < Curvas[i].Capacity; j++)
                    {
                        Buffer.Add(Curvas[i][j]);
                    }
                    g.DrawCurve(pen, Buffer.ToArray());
                }
            }
        }
        public void Calcular_Curva(ref Pen pen, ref List<List<Point>> lineas, ref Point Punto_Seleccionado_1, ref Point Punto_Seleccionado_2, ref  List<List<Point>> puntos_curva)
        {
            Point Punto_3 = new Point();
            Point Punto_4 = new Point();
            int j= new int();
            int i=new int();
            bool salida = new bool();
            for (i = 0; i < lineas.Count && !salida ; i++)
            {
                j=Get_line_Index(Punto_Seleccionado_1, ref lineas, ref i);
                if(j>-1)
                {
                    salida = true;
                }
            }
            double Longitud = new double();
            Longitud = Distancia(Punto_Seleccionado_1, Punto_Seleccionado_2);
            Punto_3 = Calcular_Punto_Tangente(Punto_Seleccionado_1, ref lineas, i, j, Longitud);
             salida = false;
            j = -1;
            for (i = 0; i < lineas.Count && !salida; i++)
            {
                j = Get_line_Index(Punto_Seleccionado_2, ref lineas, ref i);
                if (j > -1)
                {
                    salida = true;
                }
            }
            Punto_4 =Calcular_Punto_Tangente(Punto_Seleccionado_2, ref lineas, i, j, Longitud);
            //g.DrawBezier(pen, Punto_Seleccionado_1, Punto_3, Punto_4, Punto_Seleccionado_2);
            Point[] Puntos_Buffer = new Point[4] { Punto_Seleccionado_1, Punto_3, Punto_4, Punto_Seleccionado_2 };
            puntos_curva.Add(Puntos_Buffer.ToList());
            Punto_Seleccionado_1 = new Point();
            Punto_Seleccionado_2 = new Point();
        }
        /*
         * Funcion que muestra la preview de la curva a realizar
         * @arg1 Punto1 que define a la curva
         * @arg2 Punto2 que define a la curva
         * @arg3 Punto_Cero
         * @arg4 Graficos para dibujar la curva
         * @arg5 estilo de la curva
         * @arg6 La picture box donde se va a dibujar
         * */
        public void Mostrar_Preview_Curva(ref Point Punto_Seleccionado_1, ref Point Punto_Seleccionado_2, ref Point Punto_Cero, ref Pen pen, ref System.Windows.Forms.PictureBox Paleta)
        {
            if ((Punto_Seleccionado_1 != Punto_Cero) && (Punto_Seleccionado_2 != Punto_Cero))
            {
                Point[] preview = new Point[3];
                preview[0] = Punto_Seleccionado_1;
                preview[1] = Paleta.PointToClient(System.Windows.Forms.Cursor.Position);
                preview[2] = Punto_Seleccionado_2;
                // g.DrawCurve(pen, preview);
                /*RectangleF rectangle= new RectangleF(Math.Min(Punto_Seleccionado_1.X, Punto_Seleccionado_2.X),
                 Math.Min(Punto_Seleccionado_1.Y, Punto_Seleccionado_2.Y),
                 (float)Math.Sqrt(Math.Pow(Punto_Seleccionado_1.X - Punto_Seleccionado_2.X, 2)+ Math.Pow(Punto_Seleccionado_1.Y - Punto_Seleccionado_2.Y, 2)),
                 (float)Math.PI*(float)Math.Sqrt(Math.Pow(Punto_Seleccionado_1.X - Punto_Seleccionado_2.X, 2) + Math.Pow(Punto_Seleccionado_1.Y - Punto_Seleccionado_2.Y, 2)));
                 if(Punto_Seleccionado_1.X>Punto_Seleccionado_2.X)*/
                g.DrawCurve(pen, preview);

            }
        }
        public void Get_Point_Index(ref Point Punto_Seleccionado_1, ref List<List<Point>> lineas, ref int i, ref int y, int radius=10)
        {
            bool Salir = new bool();
            if (lineas.ToArray().Length > 0)
            {
                for (i = 0; i < lineas.Count && Salir == false; i++)
                {
                    y = Get_line_Index(Punto_Seleccionado_1, ref lineas, ref i, radius);
                    if (y != -1)
                    {
                        Salir = true;
                    }
                }
            }
        }
        private int Get_line_Index(Point point, ref List<List<Point>> lineas, ref int i, int radio = 10)
        {
            return lineas[i].FindIndex(x => (x.X > point.X - radio && x.X < point.X + radio) && (x.Y > point.Y - radio && x.Y < point.Y + radio));
        }
        public Point Calcular_Punto_Tangente(Point Punto, ref List<List<Point>> lineas, int i , int j, double Longitud)
        {
            Point Punto_tangente=new Point();
            double Angulo = new double();
            double Adaptacion = new double();
            if(j==0)
            {
                j = j + 2;
            }
            try
            {
                Angulo = Math.Atan((Punto.Y - lineas[i - 1][j - 1].Y) / (Punto.X - lineas[i - 1][j - 1].X));
            }
            catch (DivideByZeroException)
            {
                    Angulo = -Math.PI / 2;
            }

            Adaptacion = Longitud / 2;
            if(Punto.X > lineas[i - 1][j - 1].X)
            {
                Punto_tangente.X = Punto.X + (int)Math.Abs((Adaptacion * Math.Cos(Angulo)));
            if(Punto.Y> lineas[i - 1][j - 1].Y)
                    Punto_tangente.Y = Punto.Y + (int)Math.Abs((Adaptacion * Math.Sin(Angulo)));
            else
                Punto_tangente.Y = Punto.Y - (int)Math.Abs((Adaptacion * Math.Sin(Angulo)));

            }
            else
            {
                Punto_tangente.X = Punto.X - (int)Math.Abs((Adaptacion * Math.Cos(Angulo)));
                if (Punto.Y > lineas[i - 1][j - 1].Y)
                    Punto_tangente.Y = Punto.Y + (int)Math.Abs((Adaptacion * Math.Sin(Angulo)));
                else
                    Punto_tangente.Y = Punto.Y - (int)Math.Abs((Adaptacion * Math.Sin(Angulo)));
            }
                
                
            return Punto_tangente;
        }
        public double Distancia(Point Punto_1, Point Punto_2)
        {
            return Math.Sqrt(Math.Pow((Punto_1.X - Punto_2.X), 2) + Math.Pow((Punto_1.Y - Punto_2.Y), 2));
            
        }
        public void ZOOM(ref Point point, double zoom)
        {
            point.X = (int)(point.X * zoom);
            point.Y = (int)(point.Y * zoom);
        }
        public void Transform_Coordenadas(ref Point point, double x, double y)
        {
            point.X -= (int)x;
            point.Y -= (int)y;
        }
        public void Draw_Grill(ref Point Origen, Double Zoom, int Height, int Width)
        {
            bool First_Line = new bool();
            Pen pen = new Pen(Color.Gray, 0.25f);
            Pen BigBlackPen = new Pen(Color.Black, 1.75f);
            ///Vertical Grid
            Point Tranformation_Point = new Point();
            Point First_Grid_Point = new Point();
            Tranformation_Point.X = -(int)(g.Transform.OffsetX/Zoom);
            Tranformation_Point.Y = -(int)(g.Transform.OffsetY/Zoom);
            for(int i=0; i<Grid_Division && First_Line==false; i++)
            {
                if ((Tranformation_Point.X+i-Origen.X)%Grid_Division ==0)
                {
                    First_Line = true;
                    First_Grid_Point.X = Tranformation_Point.X + i;
                }
            }
            First_Line = false;
            for (int i = 0; i > -Grid_Division && First_Line == false; i++)
            {
                if ((Tranformation_Point.Y + i - Origen.Y) % Grid_Division == 0)
                {
                    First_Line = true;
                    First_Grid_Point.Y = Tranformation_Point.Y + i;
                }
            }
            Point[] Infinite_Points = new Point[2];
            Infinite_Points[0].Y = Tranformation_Point.Y - 50;
            Infinite_Points[1].Y = Tranformation_Point.Y + Height + 10;
            for (int i=0; g.IsVisible(40*i+First_Grid_Point.X, First_Grid_Point.Y); i++)
            {
                Infinite_Points[0].X = Grid_Division * i + First_Grid_Point.X;
                Infinite_Points[1].X= Grid_Division * i + First_Grid_Point.X;
                if(((Infinite_Points[0].X-Origen.X)/Grid_Division)%5 ==0 )
                    g.DrawLines(BigBlackPen, Infinite_Points);
                else
                    g.DrawLines(pen, Infinite_Points);
            }
            Infinite_Points[0].X = Tranformation_Point.X - 50;
            Infinite_Points[1].X = Tranformation_Point.X + Width + 10;
            SolidBrush brush = new SolidBrush(Color.Black);
            FontFamily family = new FontFamily("Times New Roman");
            Font font = new Font(family, 5, FontStyle.Italic);
                for (int i = 0; g.IsVisible(First_Grid_Point.X, First_Grid_Point.Y + Grid_Division * i); i++)
                {
                    Infinite_Points[0].Y = Grid_Division * i + First_Grid_Point.Y;
                    Infinite_Points[1].Y = Grid_Division * i + First_Grid_Point.Y;
                    if (((Infinite_Points[0].Y - Origen.Y) / Grid_Division) % 5 == 0)
                    {
                        g.DrawLines(BigBlackPen, Infinite_Points);             
                    }
                    else
                        g.DrawLines(pen, Infinite_Points);
                }
            //Desplazar a visible
        }
        public void FillCircle(Brush brush, Point point, int radius=3)
        {
            point.X -= radius;
            point.Y -= radius;
            Rectangle rectangle = new Rectangle(point, new Size(2*radius, 2*radius));
            g.FillEllipse(brush, rectangle);

        }
        public void DrawCurves(ref List<List<Point>> Puntos_Curva, Pen pen)
        {
            if (Puntos_Curva.Count > 0)
            {
                for (int i = 0; i < Puntos_Curva.Count; i++)
                {
                    g.DrawBeziers(pen, Puntos_Curva[i].ToArray());
                }
            }
        }
        public bool Seleccionar_Punto(ref List<List<Point>> Lineas, ref Point Mouse, int radius=10)
        {
            int i = new int();
            int j = new int();
            Get_Point_Index(ref Mouse, ref Lineas, ref i, ref j, radius);
            if (j != -1 && Lineas.Count>0)
            {
                Mouse = Lineas[i-1][j];
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// It makes a rectangle that informs that you are close to a point and it will put your next point over the selected point
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="point"></param>
        /// <param name="g"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public void DrawRectangle(Pen pen, Point point, ref Graphics g, int height=8, int width=8)
        {
            point.X -= width / 2;
            point.Y -= height / 2;
            g.DrawRectangle(pen, point.X, point.Y, width, height);
        }
        /// <summary>
        /// Make the next point to be perpendicular or horizontal if the angle is next to 0 or 90º
        /// </summary>
        /// <param name="point"></param>
        /// <param name="last_point"></param>
        public void CalculatePointAngle(ref Point point, Point last_point)
        {
            double Angle = CalculateAngle(ref point, ref last_point);
            if ((Angle < 100 && Angle > 80) || (Angle > -100 && Angle < -80))
            {
                point.X = last_point.X;
            }
            else if ((Angle < 10 && Angle > -10) || (Angle < 190 && Angle > 170) )
            {
                point.Y = last_point.Y;
            }

        }
        /// <summary>
        /// Calculate angle between 2 points
        /// </summary>
        /// <param name="point"></param>
        /// <param name="last_point"></param>
        /// <returns></returns>
        private double CalculateAngle(ref Point point, ref Point last_point)
        {
            return Math.Atan2(last_point.Y - point.Y, last_point.X - point.X) * 180 / Math.PI;
        }
    }
}
    