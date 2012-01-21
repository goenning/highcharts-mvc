using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc.Json
{
    public class EmptyJsonAttribute : JsonAttribute
    {
        public EmptyJsonAttribute()
            : base(null)
        {

        }
    }
}
