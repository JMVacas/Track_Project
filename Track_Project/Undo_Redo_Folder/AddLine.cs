using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track_Project
{
    public class AddLine:Operation
    {
        private Point _P1 = new Point(), _P2 = new Point();
        public AddLine()
        {

        }
        public AddLine(Point P1, Point P2)
        {
            _P1 = P1;
            _P2 = P2;
        }
        public void AddLine_Operation(Point P1, Point P2)
        {
            _P1 = P1;
            _P2 = P2;
        }
        public bool AddLine_Operation(in Point[] P)
        {
            bool error = new bool();
            try
            {
                _P1 = P[0];
                _P2 = P[1];
            }
            catch (ArgumentOutOfRangeException)
            {
                error = true;
            }
            return error;
        }
        public bool AddLine_Operation(List<Point> P)
        {
            bool error = new bool();
            try
            {
                _P1 = P[0];
                _P2 = P[1];
            }
            catch (ArgumentOutOfRangeException)
            {
                error = true;
            }
            return error;
        }
        public void GetOperationPoints(ref Point P1, ref Point P2)
        {
            P1 = _P1;
            P2 = _P2;
        }
        public override void GetOperationPoints(List<Point> list_point)
        {
            list_point.Add(_P1);
            list_point.Add(_P2);
        }
        public override void SetOperationPoint(Point point, int index)
        {
            if(index<2)
            {
                if (index == 0)
                    _P1 = point;
                if (index == 1)
                    _P2 = point;
            }
        }

    }
}
