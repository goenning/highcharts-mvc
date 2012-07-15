using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highcharts.Mvc.Json;
using Highcharts.Mvc.Models;

namespace Highcharts.Mvc
{
    public class ChartSettingsConfigurator
    {
        private readonly Chart chart;
        internal ChartSettingsConfigurator(Chart chart)
        {
            this.chart = chart;
        }

        public ChartSettingsConfigurator BackgroundColor(string color)
        {
            this.chart.BackgroundColor = color;
            return this;
        }
    }
}
