
namespace Highcharts.Mvc
{
    public class AjaxConfig
    {
        public static AjaxChartDataSource LoadFrom(string url)
        {
            return new AjaxChartDataSource(url);
        }
    }
}
