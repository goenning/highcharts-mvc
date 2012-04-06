
namespace Highcharts.Mvc
{
    public class ScatterPlotOptions : PlotOptionsConfiguration<ScatterPlotOptions>
    {
        public ScatterPlotOptions()
            : base("scatter")
        {
            this.options = this;
        }
    }
}
