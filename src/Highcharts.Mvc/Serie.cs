using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public class Serie
    {
        public string Name { get; private set; }
        public int?[] Values { get; private set; }

        public Serie(string name, int?[] values)
        {
            this.Name = name;
            this.Values = values;
        }
    }
}
