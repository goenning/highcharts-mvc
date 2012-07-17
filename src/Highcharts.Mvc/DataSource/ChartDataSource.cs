using System.Web;
using System.Web.Mvc;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc
{
    public abstract class ChartDataSource
    {
        public virtual IHtmlString ToHtmlString(string chartId)
        {
            return MvcHtmlString.Empty;
        }
    }
}
