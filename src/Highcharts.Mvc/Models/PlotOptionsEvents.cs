using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc.Models
{
    internal class PlotOptionsEvents
    {
        public JsonFunction Click { get; set; }
        public JsonFunction CheckboxClick { get; set; }
        public JsonFunction Hide { get; set; }
        public JsonFunction LegendItemClick { get; set; }
        public JsonFunction MouseOver { get; set; }
        public JsonFunction MouseOut { get; set; }
        public JsonFunction Show { get; set; }
    }
}
