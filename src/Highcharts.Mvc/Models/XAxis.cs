using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc.Models
{
    internal class XAxis
    {
        public XAxis()
        {
            this.Title = new AxisTitle();
        }

        public string[] Categories { get; set; }
        public AxisTitle Title { get; set; }
    }
}
