using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc
{
    public class AjaxChartDataSource : ChartDataSource
    {
        private JsonObject jsonConfiguration;
        public AjaxChartDataSource(string url)
        {
            this.jsonConfiguration = new JsonObject();
            this.jsonConfiguration.Set(new JsonAttribute("url", url));
        }

        public override IHtmlString ToHtmlString(string chartId)
        {
            this.jsonConfiguration.Set(new JsonAttribute("chartId", chartId));
            string js = string.Format("loadChartAjax({0});", this.jsonConfiguration.ToJson());
            return MvcHtmlString.Create(js);
        }

        public AjaxChartDataSource Reload(int miliseconds)
        {
            this.jsonConfiguration.Set(new JsonAttribute("interval", miliseconds));
            return this;
        }

        public AjaxChartDataSource AsGet()
        {
            this.jsonConfiguration.Set(new JsonAttribute("method", "GET"));
            return this;
        }

        public AjaxChartDataSource NoAnimation()
        {
            this.jsonConfiguration.Set(new JsonAttribute("animation", false));
            return this;
        }
        
        //TODO: add this 
        /*
        public AjaxChartDataSource Animation(Expression<Func<AnimationConfigurator, JsonConfigurator>> expression)
        {
            this.jsonConfiguration.Set(expression.ToJson());
            return this;
        }*/
    }
}
