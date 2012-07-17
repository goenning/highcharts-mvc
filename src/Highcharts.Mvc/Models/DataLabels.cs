using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc.Models
{
    internal class DataLabels
    {
        public DataLabels()
        {
            this.Position = new Position();
        }

        public bool? Enabled { get; set; }
        public int? Rotation { get; set; }
        public JsonFunction Formatter { get; set; }
        public string Color { get; set; }
        public Position Position { get; set; }
    }
}
