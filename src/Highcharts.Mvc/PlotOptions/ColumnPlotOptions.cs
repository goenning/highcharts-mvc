
namespace Highcharts.Mvc
{
    public class ColumnPlotOptions : PlotOptionsConfiguration<ColumnPlotOptions>
    {
        public ColumnPlotOptions()
            : base("column")
        {
            this.options = this;
        }
    }
}
