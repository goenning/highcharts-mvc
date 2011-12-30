using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Highcharts.Mvc
{
    public static class HighchartsHtmlHelper
    {
        public static HighchartsChart Highchart(this HtmlHelper htmlHelper, string id)
        {
            return new HighchartsChart(id);
        }

        public static HighchartsChart<T> Highchart<T>(this HtmlHelper htmlHelper, string id, IEnumerable<T> items)
        {
            return new HighchartsChart<T>(id, items);
        }
    }
}
