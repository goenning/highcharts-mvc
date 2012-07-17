using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc.Models
{
    internal class Animation : ICustomJsonConverter
    {
        private bool disabled;

        public void Disable()
        {
            this.disabled = true;
        }

        public int? Duration { get; set; }
        public ChartEasing? Easing { get; set; }

        public string ToJson()
        {
            return disabled
                ? JsonConverter.SerializeObject(false)
                : JsonConverter.SerializeComplexType(this);
        }

        public bool IsConsideredNull()
        {
            return disabled
                ? false
                : JsonConverter.HasAnyNullProperty(this);
        }
    }
}
