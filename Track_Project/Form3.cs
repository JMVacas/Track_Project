using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Track_Project
{
    public partial class Form3 : Form
    {
        private Bitmap bitmap;
        private List<Point> points = new List<Point>();
        public Form3()
        {
            Explorador explorador = new Explorador();

            explorador.Abrir_Explorador(ref points);
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mapa_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            bitmap = new Bitmap(2*Mapa.Width, 2*Mapa.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            Tracks _tracks = new Tracks(g);
            SolidBrush brush = new SolidBrush(Color.Black);
            _tracks.Pintar_Puntos(ref brush, ref points, 1);
            bitmap.MakeTransparent(Color.White);
            g = e.Graphics;
            g.DrawImage(bitmap,10, 10);
        }

        private void Importar_Click(object sender, EventArgs e)
        {
            Form1.Map = bitmap;
            Hide();
        }

        private void Giro_Mapa_90_Click(object sender, EventArgs e)
        {
            Point buffer = new Point();
            for (int i = 0; i < points.Count; i++)
            {
                buffer.Y = -points[i].X;
                buffer.X = points[i].Y;
                points[i] = buffer;
            }
            Offset_Giro();
        }
        private void Giro_Mapa_180_Click(object sender, EventArgs e)
        {
            Point buffer = new Point();
            Refresh();
            for (int i = 0; i < points.Count; i++)
            {
                buffer.Y = -points[i].Y;
                buffer.X = -points[i].X;
                points[i] = buffer;
            }
            Offset_Giro();
        }
        private void Offset_Giro()
        {
            Point buffer = new Point();
            int Offset_X = Math.Abs(points.OrderBy(point_x => point_x.X).First().X);
            int Offset_Y = Math.Abs(points.OrderBy(point_y => point_y.Y).First().Y);
            for (int i = 0; i < points.Count; i++)
            {
                buffer.X = points[i].X + Offset_X;
                buffer.Y = points[i].Y + Offset_Y;
                points[i] = buffer;
            }
            Refresh();
        }
    }
}
