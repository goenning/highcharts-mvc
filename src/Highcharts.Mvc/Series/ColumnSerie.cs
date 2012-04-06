using System;

namespace Highcharts.Mvc
{
    public class ColumnSerie : Serie
    {
        public ColumnSerie(string name, Array values)
            : base(name, ChartSerieType.Column, values)
        {

        }
    }
}
