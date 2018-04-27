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
        protected const int Grid_Division = 40;
        public static Graphics g;
        public Picasso()
        {

        }
         public Picasso (Graphics _g)
        {
            g = _g;
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
    }
}
    