using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public class Serie
    {
        public string Name { get; private set; }
        public object[] Values { get; private set; }

        public Serie(string name, params object[] values)
        {
            this.Name = name;
            this.Values = values;
        }
    }
}
