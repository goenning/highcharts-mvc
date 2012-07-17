using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Highcharts.Mvc.Json;
using Highcharts.Mvc.Models;

namespace Highcharts.Mvc
{
    public class AjaxChartDataSource : ChartDataSource
    {
        private AjaxOptions options;
        public AjaxChartDataSource(string url)
        {
            this.options = new AjaxOptions();
            this.options.Url = url;
        }

        public override IHtmlString ToHtmlString(string chartId)
        {
            this.options.ChartId = chartId;

            string js = string.Format("loadChartAjax({0});", 
                            JsonConverter.SerializeObject(this.options)
                        );
            return MvcHtmlString.Create(js);
        }

        public AjaxChartDataSource Reload(int miliseconds)
        {
            this.options.Interval = miliseconds;
            return this;
        }

        public AjaxChartDataSource AsGet()
        {
            this.options.Method = "GET";
            return this;
        }

        public AjaxChartDataSource NoAnimation()
        {
            this.options.Animation.Disable();
            return this;
        }
        
        public AjaxChartDataSource Animation(Action<AnimationConfigurator> expression)
        {
            expression.Invoke(new AnimationConfigurator(this.options.Animation));
            return this;
        }
    }
}
