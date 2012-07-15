using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc.Models
{
    internal class Tooltip
    {
        public JsonFunction Formatter { get; set; }
        public bool? Shared { get; set; }
        public bool? Crosshairs { get; set; }
    }
}
