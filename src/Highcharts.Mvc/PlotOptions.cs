using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public abstract class PlotOptions
    {
        public static LinePlotOptions Line
        {
            get { return new LinePlotOptions(); }
        }

        public abstract string ToJsonString();
    }
}
