﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track_Project
{
    public class AddBezier
    {
        private Point _P1 = new Point(), _P2 = new Point(), _P3 = new Point(), _P4 = new Point();
        AddBezier()
        {

        }
        AddBezier(Point P1, Point P2, Point P3, Point P4)
        {
            _P1 = P1;
            _P2 = P2;
            _P3 = P3;
            _P4 = P4;
        }
        public void AddBezier_Operation(Point P1, Point P2, Point P3, Point P4)
        {
            _P1 = P1;
            _P2 = P2;
            _P3 = P3;
            _P4 = P4;
        }
        public bool AddBezier_Operation(Point[] P)
        {
            bool error = new bool();
            try
            {
                _P1 = P[1];
                _P2 = P[2];
                _P2 = P[3];
                _P2 = P[4];
            }
            catch (ArgumentOutOfRangeException)
            {
                error = true;
            }
            return error;
        }
        public bool AddBezier_Operation(List<Point> P)
        {
            bool error = new bool();
            try
            {
                _P1 = P[1];
                _P2 = P[2];
                _P2 = P[3];
                _P2 = P[4];
            }
            catch (ArgumentOutOfRangeException)
            {
                error = true;
            }
            return error;
        }
        public void GetOperationPoints(ref Point P1, ref Point P2, ref Point P3, ref Point P4)
        {
            P1 = _P1;
            P2 = _P2;
            P3 = _P3;
            P4 = _P4;
        }

    }
}
