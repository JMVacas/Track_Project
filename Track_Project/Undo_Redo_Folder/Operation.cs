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
        public virtual void GetOperationPoints(List<Point> list_point)
        {

        }
        public virtual void ModifyOperationPoints(Point[] points)
        {

        }
        public virtual void SetOperationPoint(Point point, int index)
        {

        }
    }

}
