using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Highcharts.Mvc.Test
{
    public abstract class ConfiguratorTest<T> where T : JsonConfigurator, new()
    {
        public string Configure(Expression<Func<T, JsonConfigurator>> expression)
        {
            return expression.Compile().Invoke(new T()).ToJson().ToString();
        }
    }
}
