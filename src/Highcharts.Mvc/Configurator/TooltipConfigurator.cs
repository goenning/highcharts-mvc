using Highcharts.Mvc.Json;
using Highcharts.Mvc.Models;

namespace Highcharts.Mvc
{
    public class TooltipConfigurator : JsonConfigurator
    {
        private readonly Tooltip tooltip;
        internal TooltipConfigurator(Tooltip tooltip)
        {
            this.tooltip = tooltip;
        }

        public TooltipConfigurator Formatter(string function)
        {
            this.tooltip.Formatter = new JsonFunction(function);
            return this;
        }

        public TooltipConfigurator Shared()
        {
            this.tooltip.Shared = true;
            return this;
        }

        public TooltipConfigurator Crosshairs()
        {
            this.tooltip.Crosshairs = true;
            return this;
        }
    }
}
