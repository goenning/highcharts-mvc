using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public class LinePlotOptions : PlotOptionsConfiguration<LinePlotOptions>
    {
        public LinePlotOptions()
            : base("line")
        {
            this.options = this;
        }

        public LinePlotOptions Step()
        {
            return this.Set(new JsonObject("step", true));
        }
    }
}

