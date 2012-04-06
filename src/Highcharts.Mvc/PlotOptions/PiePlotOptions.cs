using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public class PiePlotOptions : PlotOptionsConfiguration<PiePlotOptions>
    {
        public PiePlotOptions()
            : base("pie")
        {
            this.options = this;
        }
    }
}
