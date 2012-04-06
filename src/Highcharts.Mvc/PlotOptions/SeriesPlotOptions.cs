
namespace Highcharts.Mvc
{
    public class SeriesPlotOptions : PlotOptionsConfiguration<SeriesPlotOptions>
    {
        public SeriesPlotOptions()
            : base("series")
        {
            this.options = this;
        }
    }
}
