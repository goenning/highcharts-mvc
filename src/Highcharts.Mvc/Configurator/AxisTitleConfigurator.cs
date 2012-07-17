using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highcharts.Mvc.Json;
using Highcharts.Mvc.Models;

namespace Highcharts.Mvc
{
    public class AxisTitleConfigurator
    {
        private readonly AxisTitle title;
        internal AxisTitleConfigurator(AxisTitle title)
        {
            this.title = title;
        }

        public AxisTitleConfigurator Align(AxisTitleAlignment alignment)
        {
            this.title.Align = alignment;
            return this;
        }

        public AxisTitleConfigurator Margin(int margin)
        {
            this.title.Margin = margin;
            return this;
        }

        public AxisTitleConfigurator Offset(int offset)
        {
            this.title.Offset = offset;
            return this;
        }

        public AxisTitleConfigurator Rotation(int rotation)
        {
            this.title.Rotation = rotation;
            return this;
        }
    }
}
