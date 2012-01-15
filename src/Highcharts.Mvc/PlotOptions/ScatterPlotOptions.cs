using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public class ScatterPlotOptions : PlotOptionsConfiguration<ScatterPlotOptions>
    {
        public ScatterPlotOptions()
            : base("scatter")
        {
            this.options = this;
        }
    }
}
