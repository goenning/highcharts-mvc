using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc.Models
{
    internal class FullPosition
    {
        public int? X {get;set;}
        public int? Y {get;set;}
        public HorizontalAlignment? Align {get;set;}
        public VerticalAlignment? VerticalAlign { get; set; }
    }
}
