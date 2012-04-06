using Highcharts.Mvc.Json;

namespace Highcharts.Mvc
{
    public class PositionConfigurator : JsonConfigurator
    {
        public PositionConfigurator()
            : base("position")
        {

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
            this.Set(new JsonAttribute("x", offset));
            return this;
        }

        public PositionConfigurator Y(int offset)
        {
            this.Set(new JsonAttribute("y", offset));
            return this;
        }

        private void HorizontalAlign(string value)
        {
            this.Set(new JsonAttribute("align", value));
        }
    }
}
