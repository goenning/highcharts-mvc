using System;

namespace Highcharts.Mvc
{
    public class PieSerie : Serie
    {
        public PieSerie(string name, Array values)
            : base(name, ChartSerieType.Pie, values)
        {

        }
    }
}
