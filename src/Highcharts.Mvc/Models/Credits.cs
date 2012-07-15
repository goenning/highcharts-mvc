using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc.Models
{
    internal class Credits
    {
        public bool? Enabled { get; set; }
        public string Text { get; set; }
        public string Href { get; set; }
        public FullPosition Position { get; set; }
    }
}
