using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc
{
    public class AxisTitleConfigurator : JsonConfigurator
    {
        public AxisTitleConfigurator()
            : base("title")
        {

        }

        public AxisTitleConfigurator Align(AxisTitleAlignment alignment)
        {
            this.Set(new JsonAttribute("align", alignment));
            return this;
        }

        public AxisTitleConfigurator Margin(int margin)
        {
            this.Set(new JsonAttribute("margin", margin));
            return this;
        }

        public AxisTitleConfigurator Offset(int offset)
        {
            this.Set(new JsonAttribute("offset", offset));
            return this;
        }

        public AxisTitleConfigurator Rotation(int rotation)
        {
            this.Set(new JsonAttribute("rotation", rotation));
            return this;
        }
    }
}
