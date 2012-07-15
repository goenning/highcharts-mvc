using Highcharts.Mvc.Json;
using Highcharts.Mvc.Models;

namespace Highcharts.Mvc
{
    public class AnimationConfigurator : JsonConfigurator
    {
        private readonly Animation animation;
        internal AnimationConfigurator(Animation animation)
        {
            this.animation = animation;
        }

        public AnimationConfigurator Duration(int milliseconds)
        {
            this.animation.Duration = milliseconds;
            return this;
        }

        public AnimationConfigurator Easing(ChartEasing easing)
        {
            this.animation.Easing = easing;
            return this;
        }
    }
}
