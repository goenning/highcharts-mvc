using Highcharts.Mvc.Json;

namespace Highcharts.Mvc
{
    public class AnimationConfigurator : JsonConfigurator
    {
        public AnimationConfigurator()
            : base("animation")
        {

        }

        public AnimationConfigurator Duration(int milliseconds)
        {
            this.Set(new JsonAttribute("duration", milliseconds));
            return this;
        }

        public AnimationConfigurator Easing(ChartAnimation animation)
        {
            this.Set(new JsonAttribute("easing", animation));
            return this;
        }
    }
}
