using System;
using System.Linq.Expressions;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc
{
    public static class ConfigurationExpressionExtension
    {
        public static JsonAttribute ToJson<T>(this Expression<Func<T, JsonConfigurator>> expression) where T : JsonConfigurator, new()
        {
            T configurator = new T();
            var config = expression.Compile().Invoke(configurator);
            return config.ToJson();
        }

        public static JsonAttribute ToJson<T>(this Expression<Func<T, JsonConfigurator>> expression, params JsonAttribute[] attrs) where T : JsonConfigurator, new()
        {
            T configurator = new T();
            var config = expression.Compile().Invoke(configurator);
            foreach (var attr in attrs)
                configurator.Set(attr);

            return config.ToJson();
        }
    }
}
