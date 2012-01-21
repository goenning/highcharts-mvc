using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;
using Highcharts.Mvc.Json;
using System.Linq.Expressions;

namespace Highcharts.Mvc
{
    public class AjaxChartDataSource : ChartDataSource
    {
        private JsonObject jsonConfiguration;
        public AjaxChartDataSource(string url)
        {
            this.jsonConfiguration = new JsonObject();
            this.jsonConfiguration.Add(new JsonAttribute("url", url));
        }

        public override IHtmlString ToHtmlString(string chartId)
        {
            this.jsonConfiguration.Add(new JsonAttribute("chartId", chartId));
            string js = string.Format("loadChartAjax({0});", this.jsonConfiguration.ToJson());
            return MvcHtmlString.Create(js);
        }

        public AjaxChartDataSource Reload(int miliseconds)
        {
            this.jsonConfiguration.Add(new JsonAttribute("interval", miliseconds));
            return this;
        }

        public AjaxChartDataSource AsGet()
        {
            this.jsonConfiguration.Add(new JsonAttribute("method", "GET"));
            return this;
        }

        public AjaxChartDataSource NoAnimation()
        {
            this.jsonConfiguration.Add(new JsonAttribute("animation", false));
            return this;
        }

        public AjaxChartDataSource Animation(Expression<Func<AnimationConfigurator, JsonConfigurator>> expression)
        {
            this.jsonConfiguration.Add(expression.ToJson());
            return this;
        }
    }
}
