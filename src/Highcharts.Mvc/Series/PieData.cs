using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public class PieData
    {
        public string Name { get; private set; }
        public float Value { get; private set; }

        public PieData(string name, float value)
        {
            this.Name = name;
            this.Value = value;
        }

        public override string ToString()
        {
            return string.Format("['{0}', {1}]", this.Name, this.Value);
        }
    }
}
