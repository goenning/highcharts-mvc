using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Highcharts.Mvc
{
    public class AjaxChartDataSource : ChartDataSource
    {
        public string Url { get; private set; }
        public FormMethod Method { get; private set; }
        private int? milisecondsInterval = null;

        public AjaxChartDataSource(string url)
        {
            this.Url = url;
            this.Method = FormMethod.Post;
        }

        public override string ToHtmlString(string chartId)
        {
            string jsFunctionName = this.Method == FormMethod.Post ? "postChartAjax" : "getChartAjax";

            if (milisecondsInterval.HasValue)
                return string.Format("{0}({1}, '{2}', {3});", jsFunctionName, chartId, this.Url, this.milisecondsInterval.Value);

            return string.Format("{0}({1}, '{2}');", jsFunctionName, chartId, this.Url);
        }

        public AjaxChartDataSource Reload(int miliseconds)
        {
            this.milisecondsInterval = miliseconds;
            return this;
        }

        public AjaxChartDataSource AsGet()
        {
            this.Method = FormMethod.Get;
            return this;
        }
    }
}
