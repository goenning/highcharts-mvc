using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc.Models
{
    internal class Legend
    {
        public Legend()
        {
            this.Position = new FullPosition();
        }

        public bool? Floating { get; set; }
        public bool? Enabled { get; set; }
        public bool? Reversed { get; set; }
        public bool? Shadow { get; set; }
        
        [MergeProperties]
        public FullPosition Position { get; private set; }
        public string BorderColor { get; set; }
        public int? BorderRadius { get; set; }
        public int? BorderWidth { get; set; }
        public string BackgroundColor { get; set; }
        public int? ItemWidth { get; set; }
        public int? LineHeight { get; set; }
        public int? Margin { get; set; }
        public int? SymbolPadding { get; set; }
        public int? SymbolWidth { get; set; }
        public int? Width { get; set; }
        public LegendLayout? Layout { get; set; }
        public JsonFunction LabelFormatter { get; set; }
    }
}
