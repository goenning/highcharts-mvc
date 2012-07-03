using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc
{
    public class PieData
    {
        protected string name;
        protected object value;

        public PieData(string name, int value)
        {
            this.name = name;
            this.value = value;
        }

        public PieData(string name, decimal value)
        {
            this.name = name;
            this.value = value;
        }

        public PieData(string name, double value)
        {
            this.name = name;
            this.value = value;
        }

        public PieData(string name, float value)
        {
            this.name = name;
            this.value = value;
        }

        public override string ToString()
        {
            return new JsonObject(new object[] { this.name, this.value }).ToString();
        }
    }
}
