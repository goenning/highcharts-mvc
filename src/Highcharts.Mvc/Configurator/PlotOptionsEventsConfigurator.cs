using Highcharts.Mvc.Json;

namespace Highcharts.Mvc
{
    public class EventsConfigurator : JsonConfigurator
    {
        public EventsConfigurator()
            : base("events")
        {

        }

        public EventsConfigurator OnClick(string function)
        {
            this.Set(new JsonFunctionAttribute("click", function));
            return this;
        }

        public EventsConfigurator OnCheckboxClick(string function)
        {
            this.Set(new JsonFunctionAttribute("checkboxClick", function));
            return this;
        }

        public EventsConfigurator OnLegendItemClick(string function)
        {
            this.Set(new JsonFunctionAttribute("legendItemClick", function));
            return this;
        }

        public EventsConfigurator OnMouseOver(string function)
        {
            this.Set(new JsonFunctionAttribute("mouseOver", function));
            return this;
        }

        public EventsConfigurator OnMouseOut(string function)
        {
            this.Set(new JsonFunctionAttribute("mouseOut", function));
            return this;
        }

        public EventsConfigurator OnHide(string function)
        {
            this.Set(new JsonFunctionAttribute("hide", function));
            return this;
        }

        public EventsConfigurator OnShow(string function)
        {
            this.Set(new JsonFunctionAttribute("show", function));
            return this;
        }
    }
}
