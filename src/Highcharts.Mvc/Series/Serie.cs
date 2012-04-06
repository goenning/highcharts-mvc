using System;

namespace Highcharts.Mvc
{
    public class Serie
    {
        public string Name { get; private set; }
        public ChartSerieType Type { get; private set; }
        public Array Values { get; private set; }

        public Serie(string name, Array values)
            : this(name, ChartSerieType.Default, values)
        {
        }

        public Serie(string name, ChartSerieType type, Array values)
        {
            this.Name = name;
            this.Type = type;
            this.Values = values;
        }
    }
}
