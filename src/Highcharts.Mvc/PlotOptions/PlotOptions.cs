using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public abstract class PlotOptions : AbstractJsonConfigurator
    {
        public PlotOptions(string name)
            : base(name)
        {
            
        }

        public static LinePlotOptions Line
        {
            get { return new LinePlotOptions(); }
        }

        public static ColumnPlotOptions Column
        {
            get { return new ColumnPlotOptions(); }
        }

        public override string ToString()
        {
            return this.ToJson().ToString();
        }
    }
}
