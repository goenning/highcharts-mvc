using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc
{
    public class LegendConfigurator : JsonConfigurator
    {
        public LegendConfigurator()
            : base("legend")
        {

        }

        public LegendConfigurator Floating()
        {
            this.Set(new JsonAttribute("floating", true));
            return this;
        }

        public LegendConfigurator Border(string color, int radius, int width)
        {
            this.Set(new JsonAttribute("borderColor", color));
            this.Set(new JsonAttribute("borderRadius", radius));
            this.Set(new JsonAttribute("borderWidth", width));
            return this;
        }

        public LegendConfigurator Position(Expression<Func<PositionConfigurator, JsonConfigurator>> expression)
        {
            this.SetOptions(expression.ToJson());
            return this;
        }
    }
}
