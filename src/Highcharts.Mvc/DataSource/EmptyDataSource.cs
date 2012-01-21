using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
