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


        public AxisYConfigurator Title(Expression<Func<TitleConfigurator, JsonConfigurator>> expression)
        {
            this.Set(expression.ToJson());
            return this;
        }
    }
}
