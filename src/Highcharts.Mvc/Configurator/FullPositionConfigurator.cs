using Highcharts.Mvc.Json;
using Highcharts.Mvc.Models;

namespace Highcharts.Mvc
{
    public class FullPositionConfigurator
    {
        private readonly FullPosition position;
        internal FullPositionConfigurator(FullPosition position)
        {
            this.position = position;
        }

        public FullPositionConfigurator Left()
        {
            this.position.Align = HorizontalAlignment.Left;
            return this;
        }

        public FullPositionConfigurator Center()
        {
            this.position.Align = HorizontalAlignment.Center;
            return this;
        }

        public FullPositionConfigurator Right()
        {
            this.position.Align = HorizontalAlignment.Right;
            return this;
        }

        public FullPositionConfigurator X(int offset)
        {
            this.position.X = offset;
            return this;
        }

        public FullPositionConfigurator Y(int offset)
        {
            this.position.Y = offset;
            return this;
        }

        public FullPositionConfigurator Top()
        {
            this.position.VerticalAlign = VerticalAlignment.Top;
            return this;
        }

        public FullPositionConfigurator Bottom()
        {
            this.position.VerticalAlign = VerticalAlignment.Bottom;
            return this;
        }

        public FullPositionConfigurator Middle()
        {
            this.position.VerticalAlign = VerticalAlignment.Middle;
            return this;
        }
    }
}
