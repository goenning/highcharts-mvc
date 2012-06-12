using System;

namespace Highcharts.Mvc
{
    public class PieSerie : Serie
    {
        public PieSerie(string name, Array values)
            : base(name, ChartSerieType.Pie, values)
        {

        }

        //a % of 100
        public double? Size { get; set; }

        //a % of 100
        public double? InnerSize { get; set; }
    }
}
