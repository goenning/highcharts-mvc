using System.Web.Mvc;

namespace Highcharts.Mvc
{
    public static class HighchartsHtmlHelper
    {
        public static HighchartsChart Highchart(this HtmlHelper htmlHelper, string id)
        {
            return new HighchartsChart(id);
        }

        public static HighchartsSetUp HighchartSetUp(this HtmlHelper htmlHelper, string id)
        {
            return new HighchartsSetUp(id);
        }
    }
}
