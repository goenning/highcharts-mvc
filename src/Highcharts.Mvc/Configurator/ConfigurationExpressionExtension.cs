using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc
{
    public static class ConfigurationExpressionExtension
    {
        public static JsonAttribute ToJson<T>(this Expression<Func<T, JsonConfigurator>> expression) where T : new()
        {
            T configurator = new T();
            var config = expression.Compile().Invoke(configurator);
            return config.ToJson();
        }
    }
}
