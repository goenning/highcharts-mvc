using System;

namespace Highcharts.Mvc
{
    public class Serie
    {
        public string Name { get; private set; }
        public ChartSerieType? Type { get; private set; }
        public Array Data { get; private set; }

        public Serie(string name, Array values)
            : this(name, null, values)
        {
        }

        public Serie(string name, ChartSerieType? type, Array data)
        {
            this.Name = name;
            this.Type = type;
            this.Data = data;
        }
    }
}
