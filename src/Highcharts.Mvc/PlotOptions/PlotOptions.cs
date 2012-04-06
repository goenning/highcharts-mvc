
namespace Highcharts.Mvc
{
    public static class PlotOptions
    {
        public static LinePlotOptions Line
        {
            get { return new LinePlotOptions(); }
        }

        public static SeriesPlotOptions Series
        {
            get { return new SeriesPlotOptions(); }
        }

        public static ColumnPlotOptions Column
        {
            get { return new ColumnPlotOptions(); }
        }

        public static ScatterPlotOptions Scatter
        {
            get { return new ScatterPlotOptions(); }
        }

        public static SplinePlotOptions Spline
        {
            get { return new SplinePlotOptions(); }
        }

        public static PiePlotOptions Pie
        {
            get { return new PiePlotOptions(); }
        }
    }
}
