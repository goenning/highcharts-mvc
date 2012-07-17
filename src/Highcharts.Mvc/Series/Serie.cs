using System;

namespace Highcharts.Mvc
{
    public class Serie
    {
        public string Name { get; protected set; }
        public ChartSerieType? Type { get; protected set; }
        public Array Data { get; protected set; }

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
