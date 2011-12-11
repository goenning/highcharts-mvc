using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public class AjaxConfig
    {
        public static AjaxDataSource LoadFrom(string url)
        {
            return new AjaxDataSource(url);
        }
    }
}
