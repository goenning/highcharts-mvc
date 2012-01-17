using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highcharts.Mvc.Json;

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
                new JsonFunctionAttribute("formatter", function)
            );

            return this;
        }

        public TooltipConfigurator Shared()
        {
            this.Set(
                new JsonAttribute("shared", true)
            );
            return this;
        }

        public TooltipConfigurator Crosshairs()
        {
            this.Set(
                new JsonAttribute("crosshairs", true)
            );
            return this;
        }
    }
}
