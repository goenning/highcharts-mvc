using System;
using System.Linq;

namespace Highcharts.Mvc
{
    public class PieSerie : Serie
    {
        public PieSerie(string name, params int[] values)
            : base(name, ChartSerieType.Pie, values)
        {

        }

        public PieSerie(string name, params float[] values)
            : base(name, ChartSerieType.Pie, values)
        {

        }

        public PieSerie(string name, params decimal[] values)
            : base(name, ChartSerieType.Pie, values)
        {

        }

        public PieSerie(string name, params double[] values)
            : base(name, ChartSerieType.Pie, values)
        {

        }

        public PieSerie(string name, params PieData[] values)
            : base(name, ChartSerieType.Pie, null)
        {
            this.Data = values.Select(x => new object[] { x.Name, x.Value }).ToArray();
        }
    }
}
