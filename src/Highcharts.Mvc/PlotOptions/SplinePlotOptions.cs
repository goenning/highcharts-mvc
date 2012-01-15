using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public class SplinePlotOptions : PlotOptionsConfiguration<SplinePlotOptions>
    {
        public SplinePlotOptions()
            : base("spline")
        {
            this.options = this;
        }
    }
}
