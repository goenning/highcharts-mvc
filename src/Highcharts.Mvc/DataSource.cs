using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public abstract class DataSource
    {
        public abstract string ToHtmlString(string chartId);
    }
}
