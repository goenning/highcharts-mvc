using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Highcharts.Mvc
{
    public class AjaxDataSource : DataSource
    {
        public string Url { get; private set; }
        public FormMethod Method { get; private set; }
        private int? milisecondsInterval = null;

        public AjaxDataSource(string url)
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

        public AjaxDataSource Reload(int miliseconds)
        {
            this.milisecondsInterval = miliseconds;
            return this;
        }

        public AjaxDataSource AsGet()
        {
            this.Method = FormMethod.Get;
            return this;
        }
    }
}
