using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highcharts.Mvc.Json;
using System.Linq.Expressions;

namespace Highcharts.Mvc
{
    public class AxisYConfigurator : JsonConfigurator
    {
        public AxisYConfigurator()
            : base("yAxis")
        {

        }

        public AxisYConfigurator Title(string text)
        {
            return this.Title(text, x => x);
        }

        public AxisYConfigurator Title(string text, Expression<Func<AxisTitleConfigurator, JsonConfigurator>> expression)
        {
            JsonAttribute titleText = new JsonAttribute("text", text);
            this.Set(expression.ToJson(titleText));
            return this;
        }
    }
}
