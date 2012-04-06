using System.Web;
using System.Web.Mvc;

namespace Highcharts.Mvc
{
    public class EmptyDataSource : ChartDataSource
    {
        public override IHtmlString ToHtmlString(string chartId)
        {
            return MvcHtmlString.Empty;
        }
    }
}
