using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public class JsonFunctionObject : JsonObject
    {
        public JsonFunctionObject(string key, string function)
            : base(key)
        {
            if (function.Contains(" "))
                function = string.Format("function() {{ {0} }}", function);

            this.Value = function;
        }
    }
}
