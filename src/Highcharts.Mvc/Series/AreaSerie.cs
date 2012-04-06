using System;

namespace Highcharts.Mvc
{
    public class AreaSerie : Serie
    {
        public AreaSerie(string name, Array values)
            : base(name, ChartSerieType.Area, values)
        {

        }
    }
}
