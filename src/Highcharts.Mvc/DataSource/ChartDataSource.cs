using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Highcharts.Mvc.Json;
using System.Web.Mvc;

namespace Highcharts.Mvc
{
    public abstract class ChartDataSource
    {
        public virtual IHtmlString ToHtmlString(string chartId)
        {
            return MvcHtmlString.Empty;
        }

        public virtual JsonAttribute AsJsonAttribute()
        {
            return new EmptyJsonAttribute();
        }
    }
}
