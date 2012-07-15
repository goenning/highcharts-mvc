using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc.Test.Json.Models
{
    public class ShapeStyle
    {
        public string Color { get; set; }
        public bool? Border { get; set; }
        public JsonFunction OnLoad { get; set; }
    }
}
