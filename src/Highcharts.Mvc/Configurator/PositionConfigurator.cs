using Highcharts.Mvc.Json;
using Highcharts.Mvc.Models;

namespace Highcharts.Mvc
{
    public class PositionConfigurator
    {
        private readonly Position position;
        internal PositionConfigurator(Position position)
        {
            this.position = position;
        }

        public PositionConfigurator Left()
        {
            this.position.Align = HorizontalAlignment.Left;
            return this;
        }

        public PositionConfigurator Center()
        {
            this.position.Align = HorizontalAlignment.Center;
            return this;
        }

        public PositionConfigurator Right()
        {
            this.position.Align = HorizontalAlignment.Right;
            return this;
        }

        public PositionConfigurator X(int offset)
        {
            this.position.X = offset;
            return this;
        }

        public PositionConfigurator Y(int offset)
        {
            this.position.Y = offset;
            return this;
        }
    }
}
