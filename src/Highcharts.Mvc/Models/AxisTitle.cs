using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc.Models
{
    internal class AxisTitle
    {
        public string Text { get; set; }
        public int? Rotation { get; set; }
        public AxisTitleAlignment? Align { get; set; }
        public int? Offset { get; set; }
        public int? Margin { get; set; }
    }
}
