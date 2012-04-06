
namespace Highcharts.Mvc.Json
{
    public class JsonFunctionAttribute : JsonAttribute
    {
        public JsonFunctionAttribute(string key, string function)
            : base(key)
        {
            if (function.Contains(" ") && !function.StartsWith("function("))
                function = string.Format("function() {{ {0} }}", function);

            this.Value = function;
        }
    }
}
