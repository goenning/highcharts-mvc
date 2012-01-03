using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public class LegendConfigurator : AbstractJsonConfigurator
    {
        public LegendConfigurator()
            : base("legend")
        {

        }

        public LegendConfigurator Top()
        {
            this.VerticalAlign("top");
            return this;
        }

        public LegendConfigurator Bottom()
        {
            this.VerticalAlign("bottom");
            return this;
        }

        public LegendConfigurator Middle()
        {
            this.VerticalAlign("middle");
            return this;
        }

        public LegendConfigurator Left()
        {
            this.HorizontalAlign("left");
            return this;
        }

        public LegendConfigurator Center()
        {
            this.HorizontalAlign("center");
            return this;
        }

        public LegendConfigurator Right()
        {
            this.HorizontalAlign("right");
            return this;
        }

        private void VerticalAlign(string value)
        {
            this.Set(new JsonObject("verticalAlign", value));
        }

        private void HorizontalAlign(string value)
        {
            this.Set(new JsonObject("align", value));
        }

        public LegendConfigurator Floating()
        {
            this.Set(new JsonObject("floating", true));
            return this;
        }

        public LegendConfigurator X(int offset)
        {
            this.Set(new JsonObject("x", offset));
            return this;
        }

        public LegendConfigurator Y(int offset)
        {
            this.Set(new JsonObject("y", offset));
            return this;
        }

        public LegendConfigurator Border(string color, int radius, int width)
        {
            this.Set(new JsonObject("borderColor", color));
            this.Set(new JsonObject("borderRadius", radius));
            this.Set(new JsonObject("borderWidth", width));
            return this;
        }
    }
}
