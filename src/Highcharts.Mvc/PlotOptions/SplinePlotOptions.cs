
namespace Highcharts.Mvc
{
    public class SplinePlotOptions : PlotOptionsConfiguration<SplinePlotOptions>
    {
        public SplinePlotOptions()
            : base("spline")
        {
            this.options = this;
        }
    }
}
