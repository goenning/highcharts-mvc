using Highcharts.Mvc.Json;
using Highcharts.Mvc.Models;

namespace Highcharts.Mvc
{
    public class PlotOptionsEventsConfigurator
    {
        private readonly PlotOptionsEvents events;
        internal PlotOptionsEventsConfigurator(PlotOptionsEvents events)
        {
            this.events = events;
        }

        public PlotOptionsEventsConfigurator OnClick(string function)
        {
            this.events.Click = new JsonFunction(function);
            return this;
        }

        public PlotOptionsEventsConfigurator OnCheckboxClick(string function)
        {
            this.events.CheckboxClick = new JsonFunction(function);
            return this;
        }

        public PlotOptionsEventsConfigurator OnLegendItemClick(string function)
        {
            this.events.LegendItemClick = new JsonFunction(function);
            return this;
        }

        public PlotOptionsEventsConfigurator OnMouseOver(string function)
        {
            this.events.MouseOver = new JsonFunction(function);
            return this;
        }

        public PlotOptionsEventsConfigurator OnMouseOut(string function)
        {
            this.events.MouseOut = new JsonFunction(function);
            return this;
        }

        public PlotOptionsEventsConfigurator OnHide(string function)
        {
            this.events.Hide = new JsonFunction(function);
            return this;
        }

        public PlotOptionsEventsConfigurator OnShow(string function)
        {
            this.events.Show = new JsonFunction(function);
            return this;
        }
    }
}
