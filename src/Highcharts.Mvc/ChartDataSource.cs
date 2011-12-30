using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public abstract class ChartDataSource
    {
        public abstract string ToHtmlString(string chartId);
    }
}
