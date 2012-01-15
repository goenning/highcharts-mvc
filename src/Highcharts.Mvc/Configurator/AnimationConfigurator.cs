using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public class AnimationConfigurator : AbstractJsonConfigurator
    {
        public AnimationConfigurator()
            : base("animation")
        {

        }

        public AnimationConfigurator Duration(int milliseconds)
        {
            this.Set(new JsonObject("duration", milliseconds));
            return this;
        }

        public AnimationConfigurator Easing(ChartAnimation animation)
        {
            this.Set(new JsonObject("easing", animation));
            return this;
        }
    }
}
