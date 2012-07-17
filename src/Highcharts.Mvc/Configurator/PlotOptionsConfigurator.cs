using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highcharts.Mvc.Models;

namespace Highcharts.Mvc
{
    public class PlotOptionsConfigurator
    {
        private readonly PlotOptions plotOptions;
        internal PlotOptionsConfigurator(PlotOptions plotOptions)
        {
            this.plotOptions = plotOptions;

            this.Line = new LinePlotOptionsConfigurator(this.plotOptions.Line);
            this.Column = new ColumnPlotOptionsConfigurator(this.plotOptions.Column);
            this.Series = new SeriesPlotOptionsConfigurator(this.plotOptions.Series);
        }

        public LinePlotOptionsConfigurator Line { get; private set; }
        public ColumnPlotOptionsConfigurator Column { get; private set; }
        public SeriesPlotOptionsConfigurator Series { get; private set; }
    }
}
