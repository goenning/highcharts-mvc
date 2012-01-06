using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Highcharts.Mvc
{
    public class LegendConfigurator : AbstractJsonConfigurator
    {
        public LegendConfigurator()
            : base("legend")
        {

        }

        public LegendConfigurator Floating()
        {
            this.Set(new JsonObject("floating", true));
            return this;
        }

        public LegendConfigurator Border(string color, int radius, int width)
        {
            this.Set(new JsonObject("borderColor", color));
            this.Set(new JsonObject("borderRadius", radius));
            this.Set(new JsonObject("borderWidth", width));
            return this;
        }

        public LegendConfigurator Position(Expression<Func<PositionConfigurator, IJsonConfigurator>> expression)
        {
            this.SetOptions(expression.ToJson());
            return this;
        }
    }
}
