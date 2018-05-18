using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track_Project
{
    public class Tracks
    {
        #region Properties
        private float thickness = 1;
        private List<List<Point>> Lines = new List<List<Point>>();
        private List<List<Point>> Curves = new List<List<Point>>();
        private List<Point> points = new List<Point>();
        private SolidBrush Line_Color;
       // private List<Ultima_Operacion> Last_Operation = new List<Ultima_Operacion>();
        private Operations operations = new Operations(); 
        public static Graphics g;
        private string Name;
        #endregion
        #region Constructors
        public Tracks()
        {

        }
        public Tracks(List<List<Point>> _Lines, List<List<Point>> _Curves, SolidBrush _Line_Color, string _Name)
        {
            Lines.AddRange(_Lines);
            Curves.AddRange(_Curves);
            Line_Color = _Line_Color;
            Name = _Name;
        }
        public Tracks(Graphics _g)
        {
            g = _g;
        }
        #endregion
        #region AddFunctions
        /// <summary>
        /// Add a new Line 
        /// </summary>
        public void Add_Line()
        {
            Point[] Buffer = new Point[points.Count];
            Buffer = points.ToArray();
            for (int i = 0; i < Buffer.Length - 1; i++)
            {
                Point[] Concat = new Point[2];
                Concat[0] = Buffer[i];
                Concat[1] = Buffer[i + 1];
                Lines.Add(Concat.ToList());
                AddLine addLine = new AddLine();
                addLine.AddLine_Operation(Concat);
                operations.Make(addLine);
            }
            points.Clear();
        }
        /// <summary>
        /// Add a number of Lines
        /// </summary>
        /// <param name="_Lines"></param>
        public void Add_Lines(List<List<Point>> _Lines)
        {
            Lines.AddRange(_Lines);
        }
        /// <summary>
        /// Add A point, it will apply the zoom and the screen offset
        /// </summary>
        /// <param name="point">point that is gotten by the mouse</param>
        /// <param name="zoom"></param>
        /// <param name="x">X offset</param>
        /// <param name="y">Y offset</param>
        public void Add_Point(Point point, double zoom, double x, double y)
        {
            Point P1 = new Point();
            P1 = Apply_Transformation(point, zoom, x, y);
            points.Add(P1);
        }
        /// <summary>
        /// Add point withot applying the coord transformation
        /// </summary>
        /// <param name="point"></param>
        public void Add_Point(Point point)
        {
            points.Add(point);
        }
        /// <summary>
        /// Add a determinate number of curves
        /// </summary>
        /// <param name="_Curves"></param>
        public void Add_Curves(List<List<Point>> _Curves)
        {
            Curves.AddRange(_Curves);
        }
        #endregion
        #region DrawFunctions
        /// <summary>
        /// Draw the curve
        /// </summary>
        /// <param name="pen"></param>
        public void DrawCurves(Pen pen)
        {
            if (Curves.Count > 0)
            {
                for (int i = 0; i < Curves.Count; i++)
                {
                    g.DrawBeziers(pen, Curves[i].ToArray());
                }
            }
        }
        /// <summary>
        /// Draw the track
        /// </summary>
        public void Draw_tracks()
        {
            Pen pen = new Pen(Line_Color, thickness);
            Draw_Lines(ref pen);
            DrawCurves(pen);
        }
        /// <summary>
        /// Draw the lines
        /// </summary>
        /// <param name="pen"></param>
        public void Draw_Lines(ref Pen pen)
        {
            for (int i = 0; i < Lines.Count; i++)
            {
                List<Point> Buffer = new List<Point>();
                for (int j = 0; j < Lines[i].Capacity; j++)
                {
                    Buffer.Add(Lines[i][j]);
                }
                g.DrawLines(pen, Buffer.ToArray());
            }
        }
        /// <summary>
        /// Draw all the lines and the preview of the line
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="Herramienta_Dibujo"></param>
        /// <param name="Linea"></param>
        /// <param name="Preview_Linea"></param>
        /// <param name="Mouse_Position"></param>
        public void Draw_All_Lines(ref Pen pen, ref System.Windows.Forms.ToolStripButton Herramienta_Dibujo, ref System.Windows.Forms.ToolStripButton Linea, ref bool Preview_Linea, ref Point Mouse_Position)
        {
            try
            {
                if (Lines.Count > 0)
                {
                    Draw_Lines(ref pen);
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
        /// <summary>
        /// Draw the points of the lines
        /// </summary>
        /// <param name="brush"></param>
        public void Draw_Line_Points(ref SolidBrush brush)
        {
            for (int i = 0; i < Lines.Count; i++)
            {
                for (int j = 0; j < Lines[i].Count; j++)
                    FillCircle(brush, Lines[i][j]);
            }
        }
        /// <summary>
        /// Draw the points
        /// </summary>
        /// <param name="brush"></param>
        public void Draw_Points(ref SolidBrush brush)
        {
            for (int i = 0; i < points.Count; i++)
            {
                FillCircle(brush, points[i]);
            }
        }
        /// <summary>
        /// Draw the Map points
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="Map"></param>
        /// <param name="Radius"></param>
        public void Pintar_Puntos(ref SolidBrush brush, ref List<Point> Map, int Radius)
        {
            for (int i = 0; i < Map.Count; i++)
            {
                FillCircle(brush, Map[i], Radius);
            }
        }
        /// <summary>
        /// Draws a circle in the point
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="point"></param>
        /// <param name="radius"></param>
        public void FillCircle(Brush brush, Point point, int radius = 3)
        {
            point.X -= radius;
            point.Y -= radius;
            Rectangle rectangle = new Rectangle(point, new Size(2 * radius, 2 * radius));
            g.FillEllipse(brush, rectangle);
        }
        private void FillCircle(Brush brush, ref Point point, int radius = 3)
        {
            point.X -= radius;
            point.Y -= radius;
            Rectangle rectangle = new Rectangle(point, new Size(2 * radius, 2 * radius));
            g.FillEllipse(brush, rectangle);
        }
        #endregion
        #region CalculusFunctions
        /// <summary>
        /// Calculate the brezier curve & add it to the List
        /// </summary>
        /// <param name="Punto_Seleccionado_1"></param>
        /// <param name="Punto_Seleccionado_2"></param>
        /// <param name="pen"></param>
        public void Calculate_Curve(ref Point Punto_Seleccionado_1, ref Point Punto_Seleccionado_2, Pen pen)
        {
            Point Punto_3 = new Point();
            Point Punto_4 = new Point();
            int j = new int();
            int i = new int();
            bool salida = new bool();
            for (i = 0; i < Lines.Count && !salida; i++)
            {
                j = Get_line_Index(Punto_Seleccionado_1, ref i);
                if (j > -1)
                {
                    salida = true;
                }
            }
            double Longitud = new double();
            Longitud = Distancia(Punto_Seleccionado_1, Punto_Seleccionado_2);
            Punto_3 = Calcular_Punto_Tangente(Punto_Seleccionado_1, i, j, Longitud);
            salida = false;
            j = -1;
            for (i = 0; i < Lines.Count && !salida; i++)
            {
                j = Get_line_Index(Punto_Seleccionado_2, ref i);
                if (j > -1)
                {
                    salida = true;
                }
            }
            Punto_4 = Calcular_Punto_Tangente(Punto_Seleccionado_2, i, j, Longitud);
            Point[] Puntos_Buffer = new Point[4] { Punto_Seleccionado_1, Punto_3, Punto_4, Punto_Seleccionado_2 };
            Curves.Add(Puntos_Buffer.ToList());
            AddBezier addBezier = new AddBezier();
            addBezier.AddBezier_Operation(Puntos_Buffer);
            operations.Make(addBezier);
            Punto_Seleccionado_1 = new Point();
            Punto_Seleccionado_2 = new Point();
        }
        /// <summary>
        /// Calculate the distance between tho points
        /// </summary>
        /// <param name="Punto_1"></param>
        /// <param name="Punto_2"></param>
        /// <returns></returns>
        private double Distancia(Point Punto_1, Point Punto_2)
        {
            return Math.Sqrt(Math.Pow((Punto_1.X - Punto_2.X), 2) + Math.Pow((Punto_1.Y - Punto_2.Y), 2));

        }
        /// <summary>
        /// Calculate the tangent point in order to doing a soft curve.
        /// </summary>
        /// <param name="Punto"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="Longitud"></param>
        /// <returns></returns>
        public Point Calcular_Punto_Tangente(Point Punto, int i, int j, double Longitud)
        {
            Point Punto_tangente = new Point();
            double Angulo = new double();
            double Adaptacion = new double();
            if (j == 0)
            {
                j = j + 2;
            }
            try
            {
                Angulo = Math.Atan((Punto.Y - Lines[i - 1][j - 1].Y) / (Punto.X - Lines[i - 1][j - 1].X));
            }
            catch (DivideByZeroException)
            {
                Angulo = -Math.PI / 2;
            }

            Adaptacion = Longitud / 2;
            if (Punto.X > Lines[i - 1][j - 1].X)
            {
                Punto_tangente.X = Punto.X + (int)Math.Abs((Adaptacion * Math.Cos(Angulo)));
                if (Punto.Y > Lines[i - 1][j - 1].Y)
                    Punto_tangente.Y = Punto.Y + (int)Math.Abs((Adaptacion * Math.Sin(Angulo)));
                else
                    Punto_tangente.Y = Punto.Y - (int)Math.Abs((Adaptacion * Math.Sin(Angulo)));

            }
            else
            {
                Punto_tangente.X = Punto.X - (int)Math.Abs((Adaptacion * Math.Cos(Angulo)));
                if (Punto.Y > Lines[i - 1][j - 1].Y)
                    Punto_tangente.Y = Punto.Y + (int)Math.Abs((Adaptacion * Math.Sin(Angulo)));
                else
                    Punto_tangente.Y = Punto.Y - (int)Math.Abs((Adaptacion * Math.Sin(Angulo)));
            }


            return Punto_tangente;
        }
        /// <summary>
        /// Apply zoom transformation
        /// </summary>
        /// <param name="point"></param>
        /// <param name="zoom"></param>
        private void ZOOM(ref Point point, double zoom)
        {
            point.X = (int)(point.X * zoom);
            point.Y = (int)(point.Y * zoom);
        }
        /// <summary>
        /// Apply coord transformation
        /// </summary>
        /// <param name="point"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void Transform_Coordenadas(ref Point point, double x, double y)
        {
            point.X -= (int)x;
            point.Y -= (int)y;
        }
        /// <summary>
        /// Apply the zoom and coord transformation
        /// </summary>
        /// <param name="point"></param>
        /// <param name="zoom"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Point Apply_Transformation(Point point, double zoom, double x, double y)
        {
            Transform_Coordenadas(ref point, x, y);
            ZOOM(ref point, zoom);
            return point;
        }
        /// <summary>
        /// Make the next point to be perpendicular or horizontal if the angle is next to 0 or 90º
        /// </summary>
        /// <param name="point"></param>
        /// <param name="last_point"></param>
        public void CalculatePointAngle(ref Point point)
        {
            if (points.Count > 0)
            {
                Point last_point = new Point();
                last_point = points[points.Count - 1];
                double Angle = CalculateAngle(ref point, ref last_point);
                if ((Angle < 95 && Angle > 85) || (Angle > -95 && Angle < -85))
                {
                    point.X = last_point.X;
                }
                else if ((Angle < 5 && Angle > -5) || (Angle < 185 && Angle > 175))
                {
                    point.Y = last_point.Y;
                }
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
        #endregion
        #region GetIndexFunctions
        /// <summary>
        /// Get the line index that contains a point(First)
        /// </summary>
        /// <param name="point"></param>
        /// <param name="i"></param>
        /// <param name="radio"></param>
        /// <returns></returns>
        private int Get_line_Index(Point point, ref int i, int radio = 10)
        {
            return Lines[i].FindIndex(x => (x.X > point.X - radio && x.X < point.X + radio) && (x.Y > point.Y - radio && x.Y < point.Y + radio));
        }
        /// <summary>
        /// Get the point index that contains a point(First)
        /// </summary>
        /// <param name="point"></param>
        /// <param name="radio"></param>
        /// <returns></returns>
        private int Get_line_Index(Point point, int radio = 10)
        {
            return points.FindIndex(x => (x.X > point.X - radio && x.X < point.X + radio) && (x.Y > point.Y - radio && x.Y < point.Y + radio));
        }
        public void Get_Point_Index(ref Point Punto_Seleccionado_1, ref int i, ref int y, int radius = 10)
        {
            bool Salir = new bool();
            if (Lines.ToArray().Length > 0)
            {
                for (i = 0; i < Lines.Count && Salir == false; i++)
                {
                    y = Get_line_Index(Punto_Seleccionado_1, ref i, radius);
                    if (y != -1)
                    {
                        Salir = true;
                    }
                }
            }
        }
        
        private bool Exists(Point point, ref int i, int radio = 10)
        {
            return Lines[i].Exists(x => (x.X > point.X - radio && x.X < point.X + radio) && (x.Y > point.Y - radio && x.Y < point.Y + radio));
        }
        private Point Find(Point point, ref int i, int radio = 10)
        {
            return Lines[i].Find(x => (x.X > point.X - radio && x.X < point.X + radio) && (x.Y > point.Y - radio && x.Y < point.Y + radio));
        }
        #endregion
        #region SelectPointsFunctions
        public bool Select_Points(ref Point Mouse, int radius = 10)
        {
            int i = new int();
            int j = new int();
            Get_Point_Index(ref Mouse, ref i, ref j, radius);
            if (j != -1 && Lines.Count > 0)
            {
                Mouse = Lines[i - 1][j];
                return true;
            }
            else
            {
                int k = new int();
                k = Get_line_Index(Mouse, radius);
                if (k != -1 && points.Count > 0)
                {
                    Mouse = points[k];
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void Select_Curve_Points(ref Point Punto_Seleccionado_1, ref Point Punto_Seleccionado_2, ref System.Windows.Forms.PictureBox Paleta, ref Point Punto_Cero, Double Zoom, ref int Posicion_x, ref int Posicion_y)
        {
            if (Lines.Count > 0)
            {
                if (Punto_Seleccionado_1 == Punto_Cero)
                {
                    Point point = Paleta.PointToClient(System.Windows.Forms.Cursor.Position);
                    Transform_Coordenadas(ref point, (1 / Zoom) * Posicion_x, (1 / Zoom) * Posicion_y);
                    ZOOM(ref point, Zoom);
                    for (int i = 0; i < Lines.Count; i++)
                    {
                        if (Exists(point, ref i, 20))
                        {
                            Punto_Seleccionado_1 = Find(point, ref i, 20);
                            //System.Windows.Forms.MessageBox.Show(string.Format("Ha seleccionado el punto_1 {0}, {0} ", Punto_Seleccionado_1.X + Punto_Seleccionado_1.Y));
                        }
                    }
                }
                else if (Punto_Seleccionado_1 != Punto_Cero && Punto_Seleccionado_2 == Punto_Cero)
                {
                    Point point = Paleta.PointToClient(System.Windows.Forms.Cursor.Position);
                    Transform_Coordenadas(ref point, (1 / Zoom) * Posicion_x, (1 / Zoom) * Posicion_y);
                    ZOOM(ref point, Zoom);
                    for (int i = 0; i < Lines.Count; i++)
                    {
                        if (Exists(point, ref i, 20))
                        {
                            if (Find(point, ref i, 20) == Punto_Seleccionado_1)
                            {
                                Punto_Seleccionado_1 = Punto_Cero;
                            }
                            else
                            {
                                Punto_Seleccionado_2 = Find(point, ref i, 20);
                                //System.Windows.Forms.MessageBox.Show(string.Format("Ha seleccionado el punto_2 {0}, {0} ", Punto_Seleccionado_2.X + Punto_Seleccionado_2.Y));
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region DeleteLines
        /// <summary>
        /// Delete all lines
        /// </summary>
        public void Delete_All_Lines()
        {
            if (Lines != null)
                Lines.Clear();
        }
        /// <summary>
        /// Delete all curves
        /// </summary>
        public void Delete_All_Curves()
        {
            if (Curves != null)
                Curves.Clear();
        }
        /// <summary>
        /// Delete all points
        /// </summary>
        public void Delete_All_Points()
        {
            if (points != null)
                points.Clear();
        }
        /// <summary>
        /// Delete all operations
        /// </summary>
        private void Delete_All_Operations()
        {
            if (operations.GetOperations() != null)
                operations.Clear();
        }
        /// <summary>
        /// Delete all elements in the track
        /// </summary>
        public void Delete_All()
        {
            Delete_All_Points();
            Delete_All_Curves();
            Delete_All_Lines();
            Delete_All_Operations();
        }
        /// <summary>
        /// Delete last line
        /// </summary>
        public void Delete_Last_Line()
        {
            Lines.RemoveAt(Lines.Count - 1);
        }
        /// <summary>
        /// Delete last curve
        /// </summary>
        public void Delete_Last_Curve()
        {
            Curves.RemoveAt(Curves.Count - 1);
        }
        /// <summary>
        /// Delete last Point
        /// </summary>
        public void Delete_Last_Point()
        {
            points.RemoveAt(points.ToArray().Length - 1);
        }
        /// <summary>
        /// Delete last operation
        /// </summary>
        public void Delete_Last_Operation()
        {
            if(operations.GetOperations().Count>0)
            {
                AddLine addLine = new AddLine();
                AddBezier addBezier = new AddBezier();
                if (Lines.Count > 0 && operations.GetOperations()[operations._index-1].GetType() ==addLine.GetType())
                {
                    Delete_Last_Line();
                    operations.Undo();
                }
                if (Curves.Count > 0 && operations.GetOperations()[operations._index - 1].GetType() == addBezier.GetType())
                {
                    Delete_Last_Curve();
                    operations.Undo();
                }
            }
        }
        #endregion
        #region RedoFunctions
        /// <summary>
        /// Redo last operation
        /// </summary>
        public void Redo()
        {
            Point[] list_point= operations.Redo();
            if (list_point.Length == 2)
            {
                Lines.Add(list_point.ToList());
            }
            else if (list_point.Length == 4)
            {
                Curves.Add(list_point.ToList());
            }
        }
        #endregion
        #region Set&GetProperties
        #region SetFunctions
        /// <summary>
        /// Set the Name property
        /// </summary>
        /// <param name="_Name"></param>
        public void SetName(string _Name)
        {
            Name = _Name;
        }
        /// <summary>
        /// Set the Color property
        /// </summary>
        /// <param name="_color"></param>
        public void SetColor(SolidBrush _color)
        {
            Line_Color = _color;
        }
        /// <summary>
        /// Set the lines points
        /// </summary>
        /// <param name="_Lines"></param>
        public void SetLines(List<List<Point>> _Lines)
        {
            Delete_All_Lines();
            Lines.AddRange(_Lines);
        }
        /// <summary>
        /// Set the lines points with reference in order to have a better performance
        /// </summary>
        /// <param name="_Lines"></param>
        public void SetLines(ref List<List<Point>> _Lines)
        {
            Delete_All_Lines();
            Lines.AddRange(_Lines);
        }
        /// <summary>
        /// Set the curves points
        /// </summary>
        /// <param name="_Curves"></param>
        public void SetCurves(List<List<Point>> _Curves)
        {
            Delete_All_Curves();
            Curves.AddRange(_Curves);
        }
        /// <summary>
        /// Set the Curves points with reference in order to have a better performance
        /// </summary>
        /// <param name="_Curves"></param>
        public void SetCurves(ref List<List<Point>> _Curves)
        {
            Delete_All_Curves();
            Curves.AddRange(_Curves);
        }
        /// <summary>
        /// Set the graphics property
        /// </summary>
        /// <param name="_g"></param>
        public void SetGraphics(ref Graphics _g)
        {
            g = _g;
        }
        #endregion
        #region GetFunctions
        /// <summary>
        /// Get all the lines points
        /// </summary>
        /// <returns>List<List<Point>></returns>
        public List<List<Point>> GetLines()
        {
            return Lines;
        }
        /// <summary>
        /// Get all the curves points
        /// </summary>
        /// <returns>List<List<Point>></returns>
        public List<List<Point>> GetCurves()
        {
            return Curves;
        }
        /// <summary>
        /// Get the Name property
        /// </summary>
        /// <returns>string</returns>
        public string GetName()
        {
            return Name;
        }
        /// <summary>
        /// Get the points that don´t make a line yet
        /// </summary>
        /// <returns>List<Point></returns>
        public List<Point> GetPoints()
        {
            return points;
        }
        /// <summary>
        /// Get the line color
        /// </summary>
        /// <returns></returns>
        public SolidBrush GetColor()
        {
            return Line_Color;
        }
        /// <summary>
        /// Get the number of lines
        /// </summary>
        /// <returns></returns>
        public int GetLineCount()
        {
            return Lines.Count;
        }
        /// <summary>
        /// Get the number of curves
        /// </summary>
        /// <returns></returns>
        public int GetCurveCount()
        {
            return Curves.Count;
        }
        /// <summary>
        /// Get the number of points
        /// </summary>
        /// <returns></returns>
        public int GetPointsCount()
        {
            return points.Count;
        }
        public Operations GetOperations()
        {
            return operations;
        }
        #endregion
        #endregion
    }
}
