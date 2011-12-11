using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public class EmptyDataSource : DataSource
    {
        public override string ToHtmlString(string chartId)
        {
            return string.Empty;
        }
    }
}
