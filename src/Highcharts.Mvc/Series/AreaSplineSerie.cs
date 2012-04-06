using System;

namespace Highcharts.Mvc
{
    public class AreaSplineSerie : Serie
    {
        public AreaSplineSerie(string name, Array values)
            : base(name, ChartSerieType.AreaSpline, values)
        {

        }
    }
}
