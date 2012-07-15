using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc.Models
{
    internal class YAxis
    {
        public YAxis()
        {
            this.Title = new AxisTitle();
        }

        public AxisTitle Title { get; private set; }
    }
}
