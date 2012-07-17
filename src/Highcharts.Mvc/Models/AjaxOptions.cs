using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc.Models
{
    internal class AjaxOptions
    {
        public AjaxOptions()
        {
            this.Animation = new Animation();
        }

        public string Url { get; set; }
        public string ChartId { get; set; }
        public int? Interval { get; set; }
        public string Method { get; set; }
        public Animation Animation { get; set; }
    }
}
