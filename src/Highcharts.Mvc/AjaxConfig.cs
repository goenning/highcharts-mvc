using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Highcharts.Mvc
{
    public class AjaxConfig
    {
        public static AjaxChartDataSource LoadFrom(string url)
        {
            return new AjaxChartDataSource(url);
        }
    }
}
