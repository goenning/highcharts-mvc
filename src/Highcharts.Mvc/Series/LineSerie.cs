using System;

namespace Highcharts.Mvc
{
    public class LineSerie : Serie
    {
        public LineSerie(string name, Array values)
            : base(name, ChartSerieType.Line, values)
        {

        }
    }
}
