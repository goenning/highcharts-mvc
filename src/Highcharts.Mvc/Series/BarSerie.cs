using System;

namespace Highcharts.Mvc
{
    public class BarSerie : Serie
    {
        public BarSerie(string name, Array values)
            : base(name, ChartSerieType.Bar, values)
        {

        }
    }
}
