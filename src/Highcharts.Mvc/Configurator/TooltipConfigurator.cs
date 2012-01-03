using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public class TooltipConfigurator : AbstractJsonConfigurator
    {
        public TooltipConfigurator()
            : base("tooltip")
        {

        }

        public TooltipConfigurator Formatter(string function)
        {
            this.Set(
                new JsonFunctionObject("formatter", function)
            );

            return this;
        }

        public TooltipConfigurator Shared()
        {
            this.Set(
                new JsonObject("shared", true)
            );
            return this;
        }

        public TooltipConfigurator Crosshairs()
        {
            this.Set(
                new JsonObject("crosshairs", true)
            );
            return this;
        }
    }
}
