using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc.Models
{
    internal class PlotOptions
    {
        public PlotOptions()
        {
            this.Line = new LinePlotOptions();
            this.Column = new ColumnPlotOptions();
            this.Series = new SeriesPlotOptions();
        }

        public LinePlotOptions Line { get; private set; }
        public ColumnPlotOptions Column { get; private set; }
        public SeriesPlotOptions Series { get; private set; }
    }
}
