using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track_Project
{
    class Add_Curve:Command
    {
        private Tracks tracks;
        public Add_Curve(Tracks _tracks)
        {
            tracks = _tracks;
        }

    }
}
