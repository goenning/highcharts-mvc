using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc.Models
{
    internal class Chart
    {
        public string RenderTo { get; set; }
        public ChartSerieType? Type { get; set; }
        public string BackgroundColor { get; set; }
    }
}
