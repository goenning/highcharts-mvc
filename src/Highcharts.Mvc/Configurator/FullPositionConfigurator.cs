using Highcharts.Mvc.Json;

namespace Highcharts.Mvc
{
    public class FullPositionConfigurator : JsonConfigurator
    {
        public FullPositionConfigurator()
            : base("position")
        {

        }

        public FullPositionConfigurator Left()
        {
            this.HorizontalAlign("left");
            return this;
        }

        public FullPositionConfigurator Center()
        {
            this.HorizontalAlign("center");
            return this;
        }

        public FullPositionConfigurator Right()
        {
            this.HorizontalAlign("right");
            return this;
        }

        public FullPositionConfigurator X(int offset)
        {
            this.Set(new JsonAttribute("x", offset));
            return this;
        }

        public FullPositionConfigurator Y(int offset)
        {
            this.Set(new JsonAttribute("y", offset));
            return this;
        }

        public FullPositionConfigurator Top()
        {
            this.VerticalAlign("top");
            return this;
        }

        public FullPositionConfigurator Bottom()
        {
            this.VerticalAlign("bottom");
            return this;
        }

        public FullPositionConfigurator Middle()
        {
            this.VerticalAlign("middle");
            return this;
        }

        private void HorizontalAlign(string value)
        {
            this.Set(new JsonAttribute("align", value));
        }

        private void VerticalAlign(string value)
        {
            this.Set(new JsonAttribute("verticalAlign", value));
        }
    }
}
