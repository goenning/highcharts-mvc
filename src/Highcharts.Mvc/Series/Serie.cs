using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public class Serie
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public Array Values { get; private set; }

        public Serie(string name, Array values)
             : this(name, null, values)
        {
        }

        public Serie(string name, string type, Array values)
        {
            this.Name = name;
            this.Type = type;
            this.Values = values;
        }
    }
}
