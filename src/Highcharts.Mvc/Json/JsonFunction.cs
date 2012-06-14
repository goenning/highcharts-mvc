using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc.Json
{
    public class JsonFunction
    {
        private string function;

        public JsonFunction(string function)
        {
            if (function.Contains(" ") && !function.StartsWith("function("))
                function = string.Format("function() {{ {0} }}", function);

            this.function = function;
        }

        public override string ToString()
        {
            return this.function;
        }
    }
}
