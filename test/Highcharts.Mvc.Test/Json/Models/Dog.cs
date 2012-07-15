using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc.Test.Json.Models
{
    public class Dog : ICustomJsonConverter
    {
        public string ToJson()
        {
            return "{custom:'I\'m a dog'}";
        }

        public bool IsConsideredNull()
        {
            return false;
        }
    }
}
