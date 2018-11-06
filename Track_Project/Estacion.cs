using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track_Project
{
    public class Estacion
    {
        public Point DefinedPoint;
        public List<int> Tracks_Numbers = new List<int>();
        public List<string> Track_Name = new List<string>();
        public Estacion ()
        {

        }
        public Estacion (Point _DefinedPoint, List<int> _Tracks_Numbers)
        {
            DefinedPoint = _DefinedPoint;
            Tracks_Numbers = _Tracks_Numbers;
        }
        public Estacion ( Point _DefinedPoint)
        {
            DefinedPoint = _DefinedPoint;
        }

        public void AddRelatedTrack (int _Track_name)
        {
            if (!Tracks_Numbers.Exists (s => s == _Track_name))
            {
                Tracks_Numbers.Add(_Track_name);
            }
        }
        public void SetPoint(in Point point)
        {
            DefinedPoint = point;
        }

    }
}
