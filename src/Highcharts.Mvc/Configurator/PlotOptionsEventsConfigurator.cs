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
            this.Set(new JsonAttribute("click", new JsonFunction(function)));
            return this;
        }

        public EventsConfigurator OnCheckboxClick(string function)
        {
            this.Set(new JsonAttribute("checkboxClick", new JsonFunction(function)));
            return this;
        }

        public EventsConfigurator OnLegendItemClick(string function)
        {
            this.Set(new JsonAttribute("legendItemClick", new JsonFunction(function)));
            return this;
        }

        public EventsConfigurator OnMouseOver(string function)
        {
            this.Set(new JsonAttribute("mouseOver", new JsonFunction(function)));
            return this;
        }

        public EventsConfigurator OnMouseOut(string function)
        {
            this.Set(new JsonAttribute("mouseOut", new JsonFunction(function)));
            return this;
        }

        public EventsConfigurator OnHide(string function)
        {
            this.Set(new JsonAttribute("hide", new JsonFunction(function)));
            return this;
        }

        public EventsConfigurator OnShow(string function)
        {
            this.Set(new JsonAttribute("show", new JsonFunction(function)));
            return this;
        }
    }
}
