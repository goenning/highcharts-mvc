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

        public AxisXConfigurator Title(Expression<Func<TitleConfigurator, JsonConfigurator>> expression)
        {
            this.Set(expression.ToJson());
            return this;
        }
    }
}
