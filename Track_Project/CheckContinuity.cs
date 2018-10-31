using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track_Project
{
    public static class CheckContinuity
    {
        /// <summary>
        /// Classifies the track in 3 categories (Open track, closed track and semiclosed track)
        /// </summary>
        /// <param name="Lines"> Introduce the list of lines</param>
        /// <param name="Curves">Introduce the list of curves</param>
        /// <param name="index">A index which will show the first object in a semi-closed track</param>
        /// <param name="type"></param>
        /// <param name="Open_Points"></param>
        /// <returns>Return the type of the curve</returns>
        public static ConstantsAndTypes.TypesOfTrack Check(List<List<Point>> Lines, ref List<List<Point>> Curves, ref int index, ref bool type, ref List<List<Point>> Open_Points)
        {
            int Number_Of_Objects = Lines.Count + Curves.Count;
            int Number_Of_Connected_Objects = new int();
            int Number_Of_Semiconnected_Objects = new int();
            int Number_Of_Asolated_Objects = new int();
            int Number_Of_Repeat_Start = new int();
            int Number_Of_Repeat_End = new int();
            bool Error = new bool();
            for (int i = 0; i < Lines.Count && Error == false; i++)
            {
                Number_Of_Repeat_Start = PointExistTimes(ref Lines, ref Curves, Lines[i][0]);
                if (Number_Of_Repeat_Start == 1)
                {
                    Number_Of_Repeat_End = PointExistTimes(ref Lines, ref Curves, Lines[i][1]);
                    if (Number_Of_Repeat_End == 1)
                    {
                        Number_Of_Asolated_Objects++;
                    }
                    else if (Number_Of_Repeat_End == 2)
                    {
                        Number_Of_Semiconnected_Objects++;
                        index = i;
                        Open_Points.Add(Lines[i]);
                    }
                    else
                    {
                        Error = true;
                    }

                }
                else if (Number_Of_Repeat_Start == 2)
                {
                    Number_Of_Repeat_End = PointExistTimes(ref Lines, ref Curves, Lines[i][1]);
                    if (Number_Of_Repeat_End == 1)
                    {
                        Number_Of_Semiconnected_Objects++;
                        Open_Points.Add(Lines[i]);
                        index = i;
                    }
                    else if (Number_Of_Repeat_End == 2)
                    {
                        Number_Of_Connected_Objects++;
                    }
                    else
                    {
                        Error = true;
                    }
                }
                else
                {
                    Error = true;
                }
            }
            for (int i = 0; i < Curves.Count && Error == false; i++)
            {
                Number_Of_Repeat_Start = PointExistTimes(ref Lines, ref Curves, Curves[i][0]);
                if (Number_Of_Repeat_Start == 1)
                {
                    Number_Of_Repeat_End = PointExistTimes(ref Lines, ref Curves, Curves[i][Curves[i].Count - 1]);
                    if (Number_Of_Repeat_End == 1)
                    {
                        Number_Of_Asolated_Objects++;
                    }
                    else if (Number_Of_Repeat_End == 2)
                    {
                        Number_Of_Semiconnected_Objects++;
                        Open_Points.Add(Lines[i]);
                        index = i;
                        type = true;
                    }
                    else
                    {
                        Error = true;
                    }

                }
                else if (Number_Of_Repeat_Start == 2)
                {
                    Number_Of_Repeat_End = PointExistTimes(ref Lines, ref Curves, Curves[i][Curves[i].Count - 1]);
                    if (Number_Of_Repeat_End == 1)
                    {
                        Number_Of_Semiconnected_Objects++;
                        index = i;
                        Open_Points.Add(Lines[i]);
                        type = true;
                    }
                    else if (Number_Of_Repeat_End == 2)
                    {
                        Number_Of_Connected_Objects++;
                    }
                    else
                    {
                        Error = true;
                    }
                }
                else
                {
                    Error = true;
                }
            }
            if (Number_Of_Asolated_Objects > 1 || Error == true)
            {
                return ConstantsAndTypes.TypesOfTrack.OpenTracK;
            }
            else if ((Number_Of_Asolated_Objects == 1 && Number_Of_Objects == 1) || Number_Of_Semiconnected_Objects == 2)
            {
                return ConstantsAndTypes.TypesOfTrack.SemiClosedTrack;
            }
            else
            {
                return ConstantsAndTypes.TypesOfTrack.ClosedTrack;
            }

        }
        /// <summary>
        /// Returns the number in which exist a point in the track
        /// </summary>
        /// <param name="Lines"></param>
        /// <param name="Curves"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static int PointExistTimes(ref List<List<Point>> Lines, ref List<List<Point>> Curves, Point point)
        {
            return (Lines.Where(s => s.Exists(k => k == point)).ToList().Count) + (Curves.Where(s => s.Exists(k => k == point)).ToList().Count);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Curves"></param>
        public static void DeleteRepeatPoints(ref List<List<Point>> Curves)
        {
            List<Point> Buffer = new List<Point>();
            for (int i = 0; i < Curves.Count; i++)
            {
                Buffer.AddRange(Curves[i].Distinct().ToList());
                Curves.RemoveAt(i);
                Curves.Insert(i, Buffer);
                Buffer.Clear();
            }
        }
        /// <summary>
        /// Returns the object in which is next to our object
        /// </summary>
        /// <param name="Lines"></param>
        /// <param name="Curves"></param>
        /// <param name="point"></param>
        /// <param name="mirror"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<Point> PointNextObject(List<List<Point>> Lines, ref List<List<Point>> Curves, Point point, Point mirror, ConstantsAndTypes.TypesOfTrack type)
        {
            List<Point> Buffer = new List<Point>();
            if (Lines.Where((s => s.Contains(point) && !s.Contains(mirror))).ToList().Count > 0)
            {
                Buffer = Lines.Where(s => s.Contains(point) && !s.Contains(mirror)).ToList()[0];
                if (Buffer[0] != point)
                    Buffer.Reverse();
            }
            else if (Curves.Where((s => s.Contains(point) && !s.Contains(mirror))).ToList().Count > 0)
            {
                Buffer = Curves.Where(s => s.Contains(point) && !s.Contains(mirror)).ToList()[0];
                if (Buffer[0] != point)
                    Buffer.Reverse();
            }
            return Buffer;

        }
    }
}
