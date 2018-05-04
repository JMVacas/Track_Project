using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Track_Project
{
    public static class GetBeziersPoints
    {
        #region DeCastejauMethod
        ///De Castejau algorithm Based on http://www.cubic.org/docs/bezier.htm please visit this web

        /// <summary>
        /// Get a determined number of Bezier's point using DeCastejau Method
        /// </summary>
        /// <param name="Curve">Defines the curve</param>
        /// <param name="Points_ToGet">Defines the number of points</param>
        /// <returns></returns>
        public static List<Point> GetSegments_DeCastejauMethod(ref List<Point> Curve, int Points_ToGet = 20)
        {
            Point A = new Point();
            Point B = new Point();
            Point C = new Point();
            Point D = new Point();
            Point point = new Point();
            List<Point> Curve_Points = new List<Point>();
            try
            {
                A = Curve[0];
                B = Curve[1];
                C = Curve[2];
                D = Curve[3];
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please, add a valid curve (4 points)", "Error");
            }
            double T = new double();
            for (double i = 0; i < Points_ToGet; ++i)
            {
                T = Math.Round((i / (Points_ToGet - 1)), 6);
                Bezier(ref point, ref A, ref B, ref C, ref D, T);
                Curve_Points.Add(point);
            }
            return Curve_Points;
        }
        /// <summary>
        /// Get a determined number of Bezier's point using DeCastejau Method
        /// </summary>
        /// <param name="A">First Point of the Bezier's curve</param>
        /// <param name="B">Second Point of the Bezier's curve</param>
        /// <param name="C">Third Point of the Bezier's curve</param>
        /// <param name="D">Fourth Point of the Bezier's curve</param>
        /// <param name="Points_ToGet">Defines the number of points</param>
        /// <returns></returns>
        public static List<Point> GetSegments_DeCastejauMethod(Point A, Point B, Point C, Point D, int Points_ToGet = 20)
        {
            Point point = new Point();
            List<Point> Curve_Points = new List<Point>();
            double T = new double();
            for (double i = 0; i < Points_ToGet; ++i)
            {
                T = Math.Round((i / (Points_ToGet - 1)), 6);
                Bezier(ref point, ref A, ref B, ref C, ref D, T);
                Curve_Points.Add(point);
            }
            return Curve_Points;
        }
        /// <summary>
        /// Get a determined number of Bezier's point using DeCastejau Method
        /// </summary>
        /// <param name="Curve">Defines the curve</param>
        /// <param name="Points_ToGet">Defines the number of points</param>
        /// <returns></returns>
        public static List<Point> GetSegments_DeCastejauMethod(ref Point[] Curve, int Points_ToGet = 20)
        {
            Point A = new Point();
            Point B = new Point();
            Point C = new Point();
            Point D = new Point();
            Point point = new Point();
            List<Point> Curve_Points = new List<Point>();
            try
            {
                A = Curve[0];
                B = Curve[1];
                C = Curve[2];
                D = Curve[3];
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please, add a valid curve (4 points)", "Error");
            }
            double T = new double();
            for (double i = 0; i < Points_ToGet; ++i)
            {
                T = Math.Round((i / (Points_ToGet - 1)), 6);
                Bezier(ref point, ref A, ref B, ref C, ref D, T);
                Curve_Points.Add(point);
            }
            return Curve_Points;
        }
        /// <summary>
        /// Interpolation method
        /// </summary>
        /// <param name="Dest">Return Point</param>
        /// <param name="A">First Point</param>
        /// <param name="B">Second Point</param>
        /// <param name="T">Param that goes between 0 and 1</param>
        private static void Lerp(ref Point Dest, ref Point A, ref Point B, double T)
        {
            Dest.X = (int)(A.X + (B.X - A.X) * T);
            Dest.Y = (int)(A.Y + (B.Y - A.Y) * T);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Dest">Return Point</param>
        /// <param name="A">First Point of the Bezier's curve</param>
        /// <param name="B">Second Point of the Bezier's curve</param>
        /// <param name="C">Third Point of the Bezier's curve</param>
        /// <param name="D">Fourth Point of the Bezier's curve</param>
        /// <param name="T">Param that goes between 0 and 1</param>
        private static void Bezier(ref Point Dest, ref Point A, ref Point B, ref Point C, ref Point D, double T)
        {
            Point ab = new Point(), bc = new Point(), cd = new Point(), abbc = new Point(), bccd = new Point();
            Lerp(ref ab, ref A, ref B, T);           // point between a and b 
            Lerp(ref bc, ref B, ref C, T);           // point between b and c 
            Lerp(ref cd, ref C, ref D, T);           // point between c and d 
            Lerp(ref abbc, ref ab, ref bc, T);       // point between ab and bc 
            Lerp(ref bccd, ref bc, ref cd, T);       // point between bc and cd 
            Lerp(ref Dest, ref abbc, ref bccd, T);   // point on the bezier-curve 
        }
        #endregion
        #region EcuationMethod
        ///This region uses the equation method it has less performance than the DeCastejau method but is more precise
        /// <summary>
        /// Get a number of points of a Bezier Curve using the Equation Method
        /// </summary>
        /// <param name="Curve">Defines the curve</param>
        /// <param name="Points_ToGet">Defines the number of points</param>
        /// <returns></returns>
        public static List<Point> GetSegments_EcuationMethod(ref List<Point> Curve, int Points_ToGet = 1000)
        {
            Point A = new Point();
            Point B = new Point();
            Point C = new Point();
            Point D = new Point();
            Point point = new Point();
            List<Point> Curve_Points = new List<Point>();
            try
            {
                A = Curve[0];
                B = Curve[1];
                C = Curve[2];
                D = Curve[3];
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please, add a valid curve (4 points)", "Error");
            }
            double T = new double();
            for (double i = 0; i < Points_ToGet; ++i)
            {
                T = Math.Round((i / (Points_ToGet - 1)), 6);
                Bezier_Equation(ref point, ref A, ref B, ref C, ref D, T);
                Curve_Points.Add(point);
            }
            return Curve_Points;
        }
        /// <summary>
        /// Get a number of points of a Bezier Curve using the Equation Method
        /// </summary>
        /// <param name="Curve"> Array that defines the curve</param>
        /// <param name="Points_ToGet">Defines the number of points</param>
        /// <returns></returns>
        public static List<Point> GetSegments_EcuationMethod(ref Point[] Curve, int Points_ToGet = 1000)
        {
            Point A = new Point();
            Point B = new Point();
            Point C = new Point();
            Point D = new Point();
            Point point = new Point();
            List<Point> Curve_Points = new List<Point>();
            try
            {
                A = Curve[0];
                B = Curve[1];
                C = Curve[2];
                D = Curve[3];
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please, add a valid curve (4 points)", "Error");
            }
            double T = new double();
            for (double i = 0; i < Points_ToGet; ++i)
            {
                T = Math.Round((i / (Points_ToGet - 1)), 6);
                Bezier_Equation(ref point, ref A, ref B, ref C, ref D, T);
                Curve_Points.Add(point);
            }
            return Curve_Points;
        }
        /// <summary>
        /// Get a number of points of a Bezier Curve using the Equation Method
        /// </summary>
        /// <param name="A">First Point of the Bezier's curve</param>
        /// <param name="B">Second Point of the Bezier's curve</param>
        /// <param name="C">Third Point of the Bezier's curve</param>
        /// <param name="D">Fourth Point of the Bezier's curve</param>
        /// <param name="Points_ToGet">Defines the number of points</param>
        /// <returns></returns>
        public static List<Point> GetSegments_EcuationMethod(Point A, Point B, Point C, Point D, int Points_ToGet = 1000)
        {
            Point point = new Point();
            List<Point> Curve_Points = new List<Point>();
            double T = new double();
            for (double i = 0; i < Points_ToGet; ++i)
            {
                T = Math.Round((i / (Points_ToGet - 1)), 6);
                Bezier(ref point, ref A, ref B, ref C, ref D, T);
                Curve_Points.Add(point);
            }
            return Curve_Points;
        }
        /// <summary>
        /// Returns a point using the Bezier's curve equation
        /// </summary>
        /// <param name="Dest"> Point that returns </param>
        /// <param name="A">First Point of the Bezier's curve</param>
        /// <param name="B">Second Point of the Bezier's curve</param>
        /// <param name="C">Third Point of the Bezier's curve</param>
        /// <param name="D">Fourth Point of the Bezier's curve</param>
        /// <param name="T">Param that goes between 0 and 1</param>
        private static void Bezier_Equation(ref Point Dest, ref Point A, ref Point B, ref Point C, ref Point D, double T)
        {
            Dest.X = (int)((Math.Pow((1 - T), 3) * A.X) + (3 * Math.Pow((1 - T), 2) * T * B.X) + (3 * (1 - T) * Math.Pow(T, 2) * C.X) + (Math.Pow(T, 3) * D.X));
            Dest.Y = (int)((Math.Pow((1 - T), 3) * A.Y) + (3 * Math.Pow((1 - T), 2) * T * B.Y) + (3 * (1 - T) * Math.Pow(T, 2) * C.Y) + (Math.Pow(T, 3) * D.Y));
        }
        #endregion
    }
}
