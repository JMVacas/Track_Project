using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track_Project
{
    public class Tracks: Picasso
    {
        private const float thickness = 1;
        public List<List<Point>> Lines = new List<List<Point>>();
        public List<List<Point>> Curves = new List<List<Point>>();
        public SolidBrush Line_Color;
        public string Name;     
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
        public void Draw_tracks()
        {
            Pen pen = new Pen(Line_Color, thickness);
            Draw_Lines(ref pen);
            DrawCurves(ref Curves, pen);
        }
         private void Draw_Lines(ref Pen pen)
        {  
            try
            {
                if (Lines.Count > 0)
                {
                    Mostrar_Lineas(ref pen, ref Lines);
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                System.Windows.Forms.MessageBox.Show("Error");
            }
        }
    }
}
