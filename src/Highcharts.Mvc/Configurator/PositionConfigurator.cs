using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public class PositionConfigurator : AbstractJsonConfigurator
    {
        public PositionConfigurator()
            : base("position")
        {

        }

        public PositionConfigurator Top()
        {
            this.VerticalAlign("top");
            return this;
        }

        public PositionConfigurator Bottom()
        {
            this.VerticalAlign("bottom");
            return this;
        }

        public PositionConfigurator Middle()
        {
            this.VerticalAlign("middle");
            return this;
        }

        public PositionConfigurator Left()
        {
            this.HorizontalAlign("left");
            return this;
        }

        public PositionConfigurator Center()
        {
            this.HorizontalAlign("center");
            return this;
        }

        public PositionConfigurator Right()
        {
            this.HorizontalAlign("right");
            return this;
        }

        public PositionConfigurator X(int offset)
        {
            this.Set(new JsonObject("x", offset));
            return this;
        }

        public PositionConfigurator Y(int offset)
        {
            this.Set(new JsonObject("y", offset));
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
    }
}
