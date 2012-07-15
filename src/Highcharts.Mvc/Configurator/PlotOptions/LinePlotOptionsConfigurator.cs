using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highcharts.Mvc.Models;
using Highcharts.Mvc.Configurator.PlotOptions;

namespace Highcharts.Mvc
{
    public class LinePlotOptionsConfigurator : CommonPlotOptionsConfigurator<LinePlotOptionsConfigurator>
    {
        private readonly LinePlotOptions linePlotOptions;
        internal LinePlotOptionsConfigurator(LinePlotOptions linePlotOptions)
            : base(linePlotOptions)
        {
            this.linePlotOptions = linePlotOptions;
        }
    }
}
