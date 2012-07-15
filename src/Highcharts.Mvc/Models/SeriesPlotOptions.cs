using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc.Models
{
    internal class SeriesPlotOptions
    {
        public SeriesPlotOptions()
        {
            this.DataLabels = new DataLabels();
            this.Animation = new Animation();
        }

        public string Id { get; set; }
        public bool? ShowInLegend { get; set; }
        public DataLabels DataLabels { get; private set; }
        public int? ZIndex { get; set; }
        public bool? Visible { get; set; }
        public bool? EnableMouseTracking { get; set; }
        public string Color { get; set; }
        public bool? StickyTracking { get; set; }
        public bool? AllowPointSelect { get; set; }
        public Animation Animation { get; set; }
        public bool? ConnectNulls { get; set; }
        public ChartCursor? Cursor { get; set; }
        public ChartDashStyle? DashStyle { get; set; }
        public int? LineWidth { get; set; }
        public bool? Selected { get; set; }
        public bool? Shadow { get; set; }
        public bool? ShowCheckbox { get; set; }
        public ChartStacking? Stacking { get; set; }
    }
}
