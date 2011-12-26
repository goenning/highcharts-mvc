using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public class LinePlotOptions : PlotOptions
    {
        private bool? showDataLabels;
        private bool? enableMouseTracking;
        private bool? showInLegend;

        public LinePlotOptions ShowDataLabels()
        {
            this.showDataLabels = true;
            return this;
        }

        public LinePlotOptions DisableMouseTracking()
        {
            this.enableMouseTracking = false;
            return this;
        }

        public LinePlotOptions HideInLegend()
        {
            this.showInLegend = false;
            return this;
        }

        public override string ToJsonString()
        {
            StringBuilder js = new StringBuilder();
            List<string> options = new List<string>();


            if (this.showDataLabels.HasValue)
                options.Add("dataLabels: { enabled: true }");

            if (this.enableMouseTracking.HasValue)
                options.Add("enableMouseTracking: false");

            if (this.showInLegend.HasValue)
                options.Add("showInLegend: false");

            js.Append("line: {");
            js.Append(string.Join(",", options));
            js.Append("}");

            return js.ToString();
        }
    }
}
