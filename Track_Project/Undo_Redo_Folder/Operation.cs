using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track_Project
{
    public abstract class Operation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list_point"></param>
        public virtual void GetOperationPoints(List<Point> list_point)
        {

        }
        public virtual void ModifyOperationPoints(Point[] points)
        {

        }
        /// <summary>
        /// Modify operation point in a determined index
        /// </summary>
        /// <param name="point"></param>
        /// <param name="index"></param>
        public virtual void SetOperationPoint(Point point, int index)
        {

        }
    }

}
