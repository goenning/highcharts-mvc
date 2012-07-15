using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highcharts.Mvc.Models;

namespace Highcharts.Mvc.Configurator.PlotOptions
{
    public class SeriesPlotOptionsConfigurator : CommonPlotOptionsConfigurator<SeriesPlotOptionsConfigurator>
    {
        private readonly SeriesPlotOptions seriesPlotOptions;
        internal SeriesPlotOptionsConfigurator(SeriesPlotOptions seriesPlotOptions)
            : base(seriesPlotOptions)
        {
            this.seriesPlotOptions = seriesPlotOptions;
        }
    }
}
