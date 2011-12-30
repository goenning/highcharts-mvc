using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public abstract class PlotOptions : JsonObject
    {
        public PlotOptions(string name)
            : base(name)
        {
            
        }

        public static LinePlotOptions Line
        {
            get { return new LinePlotOptions(); }
        }
    }
}
