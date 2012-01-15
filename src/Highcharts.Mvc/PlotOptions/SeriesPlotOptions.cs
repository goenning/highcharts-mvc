using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public class SeriesPlotOptions : PlotOptionsConfiguration<SeriesPlotOptions>
    {
        public SeriesPlotOptions()
            : base("series")
        {
            this.options = this;
        }
    }
}
