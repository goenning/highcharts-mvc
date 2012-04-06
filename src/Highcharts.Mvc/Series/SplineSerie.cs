using System;

namespace Highcharts.Mvc
{
    public class SplineSerie : Serie
    {
        public SplineSerie(string name, Array values)
            : base(name, ChartSerieType.Spline, values)
        {

        }
    }
}
