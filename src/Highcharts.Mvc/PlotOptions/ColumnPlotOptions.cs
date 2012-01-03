using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public class ColumnPlotOptions : PlotOptions
    {
        public ColumnPlotOptions()
            : base("column")
        {

        }

        public ColumnPlotOptions ShowDataLabels()
        {
            this.Set(new JsonObject("dataLabels",
                new JsonObject("enabled", true)
            ));
            return this;
        }

        public ColumnPlotOptions DisableMouseTracking()
        {
            this.Set(new JsonObject("enableMouseTracking", false));
            return this;
        }

        public ColumnPlotOptions HideInLegend()
        {
            this.Set(new JsonObject("showInLegend", false));
            return this;
        }
    }
}
