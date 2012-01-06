using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Highcharts.Mvc
{
    public static class ConfigurationExpressionExtension
    {
        public static JsonObject ToJson<T>(this Expression<Func<T, IJsonConfigurator>> expression) where T : new()
        {
            T configurator = new T();
            var config = expression.Compile().Invoke(configurator);
            return config.ToJson();
        }
    }
}
