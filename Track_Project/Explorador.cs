﻿
using netDxf.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Track_Project
{
    class Explorador
    {
        const int ADOPTSCALEFACTOR = 50;
        public List<System.Drawing.Point> Puntos { get; set; }
        public List<List<System.Drawing.Point>> Lineas { get; set; }
        public List<List<System.Drawing.Point>> Curvas { get; set; }
        public int Height;
        public System.Drawing.Point Origin { get; set; }
        public List<System.Drawing.Point> Map_Points;
        #region Constructors
        public Explorador()
        {

        }
        public Explorador(int _Height)
        {
            Height = _Height;
        }
        public Explorador(List<System.Drawing.Point> _Puntos, List<List<System.Drawing.Point>> _Lineas, List<List<System.Drawing.Point>> _Curvas, int _Height)
        {
            Puntos = _Puntos;
            Lineas = _Lineas;
            Curvas = _Curvas;
            Height = _Height;
        }
        #endregion
        public void Abrir_Explorador()
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "dxf files(*.dxf)|*.dxf|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                ValidateNames = true
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {                         
                            //Contenido=File.ReadAllText(openFileDialog1.FileName);
                            Recibir_Objetos(openFileDialog1.FileName);
                            myStream.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        public void Abrir_Explorador(ref List<System.Drawing.Point> _Map_Points)
        {
            Map_Points = new List<System.Drawing.Point>();
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "dxf files(*.csv)|*.csv|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                ValidateNames = true
            };
            string Contenido = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            Contenido=File.ReadAllText(openFileDialog1.FileName);
                            Leer_csv(ref Contenido);
                            _Map_Points = Map_Points;
                            myStream.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        public void Guardar_Explorador(ref Graphics Graficos)
        {
            FileStream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            Bitmap Contenido = new Bitmap(770, 416, Graficos);
            saveFileDialog1.Filter = "jpg files(*.jpg)|*.jpg|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = (FileStream)saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    //byte[] bytes = Encoding.ASCII.GetBytes(Contenido.);
                    //myStream.Write(bytes, 0, Contenido.Length);
                    //myStream.Close();
                    Contenido.Save(saveFileDialog1.FileName);
                    //Path = saveFileDialog1.FileName;
                   // File.WriteAllText(saveFileDialog1.FileName, Contenido);                   
                }
            }
 
        }
        /*
         * Save all de data into a dxf file.
         * */

        public void Guardar_Explorador()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "dxf files(*.dxf)|*.dxf|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                DefaultExt = ".dxf"
            };
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Save_Items(saveFileDialog1.FileName);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="Path"></param>
        public void Guardar_Explorador(ref Bitmap bitmap)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "jpg files(*.jpg)|*.jpg|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                DefaultExt = ".jpg"
            };
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bitmap.Save(saveFileDialog1.FileName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Contenido"></param>
        /// <param name="points"></param>
        /// <param name="Origen"></param>
        public void Crear_csv(ref string Contenido, System.Drawing.Point[] points, System.Drawing.Point Origen)
        {
            Contenido += "Origen;X;Y\n";
            Contenido += ";";
            Contenido += Origen.X;
            Contenido += ";";
            Contenido += Origen.Y;
            Contenido += "\r\nPuntos\r\n";
            for (int i =0; i<points.Length; i++)
            {
                Contenido += ";";
                Contenido += points[i].X;
                Contenido += ";";
                Contenido += points[i].Y;
                Contenido += "\r\n";
            }
            Contenido += "\r\n";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Contenido"></param>
        public void Leer_csv(ref string Contenido)
        {
            Map_Points = new List<System.Drawing.Point>();
            string[] Points_Vector=Contenido.Split('\r','\n');
            foreach (string point_str in Points_Vector)
            {
                string [] Point_Vector = point_str.Split(',');
                int Pos_X = new int(), Pos_Y = new int();
                try
                {
                    NumberFormatInfo provider = new NumberFormatInfo
                    {
                        NumberDecimalSeparator = "."
                    };
                    Pos_X = (int)(Convert.ToDouble(Point_Vector[0], provider) * ADOPTSCALEFACTOR);
                    Pos_Y = (int)(Convert.ToDouble(Point_Vector[1], provider) * ADOPTSCALEFACTOR);
                }
                catch(FormatException ex)
                {
                    Pos_X = 0;
                    Pos_Y = 0;
                }
                System.Drawing.Point point = new System.Drawing.Point(Pos_X, Pos_Y);
                Map_Points.Add(point);               
            }
            MovePointsToCenter();
        }
        /*
         * Gets the items from a dxf file and its added to local parameters
         * @arg1 its the path which is necesary in order to get the file
         * */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public void Recibir_Objetos(string path)
        {
            //Loads a file from the command line argument
            
            
            
            Puntos = new List<System.Drawing.Point>();
            Lineas = new List<List<System.Drawing.Point>>();
            Curvas = new List<List<System.Drawing.Point>>();
            netDxf.DxfDocument document = netDxf.DxfDocument.Load(path);
            System.Drawing.Point[] Punto = new System.Drawing.Point[2];          
            
            GetLinesFromDoc(ref document);
            GetArcFromDoc(ref document);
            GetSpilineFromDoc(ref document);
        }
        /*
         * Transform the angle in degrees to radians
         * @arg1 Angle in degrees
         * */
        public double ToRadians(double angle)
        {
            return (Math.PI * angle / 180);
        }
        public void Save_Items(string path)
        {
            netDxf.DxfDocument doc = new netDxf.DxfDocument();
            System.Drawing.Point[] Punto = new System.Drawing.Point[2];
            Line line = new Line();
            netDxf.Vector2[] vector_puntos = new netDxf.Vector2[2];
            for (int i=0; i<Lineas.Count; i++)
            {

                Punto[0] = Lineas[i][0];
                Punto[1] = Lineas[i][1];
                vector_puntos[0].X = Punto[0].X;
                vector_puntos[0].Y = -Punto[0].Y+Height;
                vector_puntos[1].X = Punto[1].X;
                vector_puntos[1].Y = -Punto[1].Y+Height;
                line = new Line(vector_puntos[0], vector_puntos[1]);
                doc.AddEntity(line);
            }
            List<SplineVertex> splineVertex = new List<SplineVertex>();
            vector_puntos = new netDxf.Vector2[4];
            for (int i=0; i<Curvas.Count; i++)
            {
                for (int j=0; j<vector_puntos.Length; j++)
                {
                    vector_puntos[j].X = Curvas[i][j].X;
                    vector_puntos[j].Y = -Curvas[i][j].Y+Height;
                    SplineVertex Buffer = new SplineVertex(vector_puntos[j]);
                    splineVertex.Add(Buffer);
                }
                Spline spline = new Spline(splineVertex);
                splineVertex.Clear();
                doc.AddEntity(spline);

            }
            doc.Save(path);
            FileStream fileStream = new FileStream(path, FileMode.Create);
            if (!doc.Save(fileStream, true))
                throw new Exception("Error saving to file stream.");
            doc.Save(fileStream, true);
        }
        public void Prueba()
        {
            Line line = new Line(new netDxf.Vector3(0, 0, 0), new netDxf.Vector3(100, 100, 0));

            netDxf.DxfDocument dxf = new netDxf.DxfDocument();
            dxf.AddEntity(line);
            dxf.Save("test.dxf");

            // saving to memory stream always use the default constructor, a fixed size stream will not work.
            MemoryStream memoryStream = new MemoryStream();
            if (!dxf.Save(memoryStream))
                throw new Exception("Error saving to memory stream.");
            // after the save method we need to rewind the stream to its start position
            memoryStream.Position = 0;

            bool isBinary;
            netDxf.Header.DxfVersion version1 = netDxf.DxfDocument.CheckDxfFileVersion(memoryStream, out isBinary);
            // DxfDocument.CheckDxfFileVersion is a read operation therefore we will need to rewind the stream to its start position
            memoryStream.Position = 0;

            // loading from memory stream
            netDxf.DxfDocument dxf2 = netDxf.DxfDocument.Load(memoryStream);
            // DxfDocument.CheckDxfFileVersion is a read operation therefore we will need to rewind the stream to its start position
            memoryStream.Position = 0;

            netDxf.Header.DxfVersion version2 = netDxf.DxfDocument.CheckDxfFileVersion(memoryStream, out isBinary);

            memoryStream.Close(); // once the stream is not need anymore we need to close the stream

            // saving to file stream
            FileStream fileStream = new FileStream("test fileStream.dxf", FileMode.Create);
            if (!dxf2.Save(fileStream, true))
                throw new Exception("Error saving to file stream.");

            fileStream.Close(); // you will need to close the stream manually to avoid file already open conflicts

            FileStream fileStreamLoad = new FileStream("test fileStream.dxf", FileMode.Open, FileAccess.Read);
            netDxf.DxfDocument dxf3 = netDxf.DxfDocument.Load(fileStreamLoad);
            fileStreamLoad.Close();

            netDxf.DxfDocument dxf4 = netDxf.DxfDocument.Load("test fileStream.dxf");
        }
        #region GetItemsFromDoc
        /*
         * This region in used for simplify GetItems function. There are several funcions that are used for getting the information that is already
         * saved in the DxfDocument and passed to the local variables.
         **/
         /*
          * Get the lines from the document and adds them to the local variable
          * */
        private void GetLinesFromDoc(ref netDxf.DxfDocument document)
        {
            List<Line> lines = new List<Line>();
            System.Drawing.Point[] Punto = new System.Drawing.Point[2];
            lines = document.Lines.ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                Punto[0].X = (int)lines[i].StartPoint.X;
                Punto[0].Y = (int)lines[i].StartPoint.Y * -1 + Height;
                Punto[1].X = (int)lines[i].EndPoint.X;
                Punto[1].Y = (int)lines[i].EndPoint.Y * -1 + Height;
                Lineas.Add(Punto.ToList());
            }
        }
        /*
         * Get the arcs from the document and adds them to the local variable
         * */
        private void GetArcFromDoc(ref netDxf.DxfDocument document)
        {
            List<Arc> arcs = new List<Arc>();
            arcs = document.Arcs.ToList();
            double radio = new double();
            double Angulo_Inicial = new double(), Angulo_Final = new double();
            System.Drawing.Point[]Punto = new System.Drawing.Point[4];
            System.Drawing.Point Centro = new System.Drawing.Point();
            for (int i = 0; i < arcs.Count; i++)
            {
                Centro.X = (int)arcs[i].Center.X;
                Centro.Y = (int)arcs[i].Center.Y * -1 + Height;
                radio = arcs[i].Radius;
                if (arcs[i].StartAngle > Angulo_Final)
                    Angulo_Inicial = arcs[i].StartAngle - 360;
                else
                    Angulo_Inicial = arcs[i].StartAngle;
                Angulo_Final = arcs[i].EndAngle;
                Punto[0].X = Centro.X + (int)(radio * Math.Cos(ToRadians(Angulo_Inicial)));
                Punto[0].Y = Centro.Y - (int)(radio * Math.Sin(ToRadians(Angulo_Inicial)));
                Punto[3].X = Centro.X + (int)(radio * Math.Cos(ToRadians(Angulo_Final)));
                Punto[3].Y = Centro.Y - (int)(radio * Math.Sin(ToRadians(Angulo_Final)));
                Punto[1].X = Centro.X + (int)(radio * Math.Cos(ToRadians(Angulo_Inicial + (Angulo_Final - Angulo_Inicial) / 3)));
                Punto[1].Y = Centro.Y - (int)(radio * Math.Sin(ToRadians(Angulo_Inicial + (Angulo_Final - Angulo_Inicial) / 3)));
                Punto[2].X = Centro.X + (int)(radio * Math.Cos(ToRadians(Angulo_Inicial + 2 * (Angulo_Final - Angulo_Inicial) / 3)));
                Punto[2].Y = Centro.Y - (int)(radio * Math.Sin(ToRadians(Angulo_Inicial + 2 * (Angulo_Final - Angulo_Inicial) / 3)));
                Curvas.Add(Punto.ToList());

            }
        }
        /*
         * Get the spilines from the document and adds them to the local variable
         * */
        private void GetSpilineFromDoc(ref netDxf.DxfDocument document)
        {
            List<Spline> splines = new List<Spline>();
            splines = document.Splines.ToList();
            System.Drawing.Point Punto = new System.Drawing.Point();
            List<SplineVertex> splineVertex = new List<SplineVertex>();
            List<System.Drawing.Point> Puntos_Spiline = new List<System.Drawing.Point>();
            for (int i = 0; i < splines.Count; i++)
            {
                splineVertex = splines[i].ControlPoints.ToList();
                for (int j = 0; j < splineVertex.Count; j++)
                {
                    Punto.X = (int)splineVertex.ToArray()[j].Position.X;
                    Punto.Y = -(int)splineVertex.ToArray()[j].Position.Y + Height;
                    Puntos_Spiline.Add(Punto);
                }
                Curvas.Add(Puntos_Spiline.ToArray().ToList());
                Puntos_Spiline.Clear();
            }
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        private void MovePointsToCenter()
        {
            int Min_X = Map_Points.Min(point => point.X);
            int Min_Y = Map_Points.Min(point => point.Y);
            System.Drawing.Point buffer_point = new System.Drawing.Point();
            for(int i=0; i<Map_Points.Count; i++)
            {
                buffer_point = Map_Points[i];
                buffer_point.X -= Min_X;
                buffer_point.Y -= Min_Y;
                Map_Points[i] = buffer_point;
            }
        }
    }
}
