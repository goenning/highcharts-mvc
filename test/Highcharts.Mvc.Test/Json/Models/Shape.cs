using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc.Test.Json.Models
{
    public class Shape
    {
        public Shape()
        {
            this.Style = new ShapeStyle();
        }

        public string Name { get; set; }

        [MergeProperties]
        public ShapeStyle Style { get; set; }
    }
}
