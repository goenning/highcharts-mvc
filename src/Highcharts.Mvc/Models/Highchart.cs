using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc.Models
{
    internal class Highchart
    {
        public Highchart()
        {
            this.Chart = new Chart();
            this.Title = new ChartTitle();
            this.Subtitle = new ChartTitle();
            this.XAxis = new XAxis();
            this.YAxis = new YAxis();
            this.Exporting = new Exporting();
            this.PlotOptions = new PlotOptions();
            this.Credits = new Credits();
            this.Tooltip = new Tooltip();
            this.Legend = new Legend();
        }

        public Chart Chart { get; private set; }
        public ChartTitle Title { get; private set; }
        public ChartTitle Subtitle { get; private set; }
        public XAxis XAxis { get; private set; }
        public YAxis YAxis { get; private set; }
        public string[] Colors { get; set; }
        public Exporting Exporting { get; private set; }
        public PlotOptions PlotOptions { get; private set; }
        public Credits Credits { get; private set; }
        public Tooltip Tooltip { get; private set; }
        public Legend Legend { get; set; }
        public Serie[] Series { get; set; }
    }
}
