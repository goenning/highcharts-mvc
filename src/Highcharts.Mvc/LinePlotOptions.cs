using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public class LinePlotOptions : PlotOptions
    {
        public LinePlotOptions()
            : base("line")
        {

        }

        public LinePlotOptions ShowDataLabels()
        {
            this.Set(new JsonObject("dataLabels",
                new JsonObject("enabled", true)
            ));
            return this;
        }

        public LinePlotOptions DisableMouseTracking()
        {
            this.Set(new JsonObject("enableMouseTracking", false));
            return this;
        }

        public LinePlotOptions HideInLegend()
        {
            this.Set(new JsonObject("showInLegend", false));
            return this;
        }
    }
}

