using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc
{
    public class PieData
    {
        public string Name { get; private set; }
        public object Value { get; private set; }

        public PieData(string name, int value)
        {
            this.Name = name;
            this.Value = value;
        }

        public PieData(string name, decimal value)
        {
            this.Name = name;
            this.Value = value;
        }

        public PieData(string name, double value)
        {
            this.Name = name;
            this.Value = value;
        }

        public PieData(string name, float value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
