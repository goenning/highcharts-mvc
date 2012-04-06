using System;
using System.Linq.Expressions;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc
{
    public class DataLabelsConfigurator : JsonConfigurator
    {
        public DataLabelsConfigurator()
            : base("dataLabels")
        {

        }

        public DataLabelsConfigurator Position(Expression<Func<PositionConfigurator, JsonConfigurator>> expression)
        {
            this.SetOptions(expression.ToJson());
            return this;
        }

        public DataLabelsConfigurator Color(string color)
        {
            this.Set(new JsonAttribute("color", color));
            return this;
        }

        public DataLabelsConfigurator Show()
        {
            this.Set(new JsonAttribute("enabled", true));
            return this;
        }

        public DataLabelsConfigurator Formatter(string function)
        {
            this.Set(new JsonFunctionAttribute("formatter", function));
            return this;
        }

        public DataLabelsConfigurator Rotation(int rotation)
        {
            this.Set(new JsonAttribute("rotation", rotation));
            return this;
        }
    }
}
