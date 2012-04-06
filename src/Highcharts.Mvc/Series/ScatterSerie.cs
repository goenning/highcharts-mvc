using System;

namespace Highcharts.Mvc
{
    public class ScatterSerie : Serie
    {
        public ScatterSerie(string name, Array values)
            : base(name, ChartSerieType.Scatter, values)
        {

        }
    }
}
