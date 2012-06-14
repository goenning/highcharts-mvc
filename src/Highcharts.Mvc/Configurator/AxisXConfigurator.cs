using Highcharts.Mvc.Json;
using System.Linq.Expressions;
using System;

namespace Highcharts.Mvc
{
    public class AxisXConfigurator : JsonConfigurator
    {
        public AxisXConfigurator()
            : base("xAxis")
        {

        }

        public AxisXConfigurator Categories(params string[] categories)
        {
            this.Set(new JsonAttribute("categories", categories));
            return this;
        }

        public AxisXConfigurator Title(string text)
        {
            return this.Title(text, x => x);
        }

        public AxisXConfigurator Title(string text, Expression<Func<AxisTitleConfigurator, JsonConfigurator>> expression)
        {
            JsonAttribute titleText = new JsonAttribute("text", text);
            this.Set(expression.ToJson(titleText));
            return this;
        }
    }
}
