using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Highcharts.Mvc.Json;
using Highcharts.Mvc.Models;

namespace Highcharts.Mvc
{
    public class HighchartsSetUp
    {
        protected string Id { get; private set; }

        private ChartDataSource dataSource;
        private JsonObject chartConfig;
        private JsonAttribute chartAttribute;
        private Highchart obj;

        public HighchartsSetUp(string id)
        {
            this.Id = id;
            this.dataSource = new EmptyDataSource();
            this.chartConfig = new JsonObject();

            this.chartAttribute = new JsonAttribute("chart",
                new JsonAttribute("renderTo", this.Id)
            );

            this.chartConfig.Set(this.chartAttribute);

            this.obj = new Highchart();
            this.obj.Chart.RenderTo = this.Id;
        }

        public virtual IHtmlString ToHtmlString()
        {
            IHtmlString chartSource = this.dataSource.ToHtmlString(this.Id);
            this.chartConfig.Set(this.dataSource.AsJsonAttribute());

            string json = JsonConverter.SerializeObject(this.obj);

            string html = string.Format(@"$(document).ready(function () {{
                                            hCharts['{0}'] = new Highcharts.Chart({1});

                                            {2}
                                        }});", this.Id, json, chartSource);

            return MvcHtmlString.Create(html.ToString());
        }

        public HighchartsSetUp Title(string title)
        {
            this.obj.Title.Text = title;
            return this;
        }

        public HighchartsSetUp Series(ChartDataSource datasource)
        {
            this.dataSource = datasource;
            return this;
        }

        public HighchartsSetUp Series(IEnumerable<Serie> series)
        {
            return Series(series.ToArray());
        }

        public HighchartsSetUp Series(params Serie[] series)
        {
            this.obj.Series = series;
            return this;
        }

        public HighchartsSetUp WithSerieType(ChartSerieType serieType)
        {
            this.obj.Chart.Type = serieType;
            return this;
        }

        public HighchartsSetUp Subtitle(string subtitle)
        {
            this.obj.Subtitle.Text = subtitle;
            return this;
        }

        public HighchartsSetUp Options(Action<PlotOptionsConfigurator> action)
        {
            action.Invoke(new PlotOptionsConfigurator(this.obj.PlotOptions));
            return this;
        }

        public HighchartsSetUp Colors(params string[] colors)
        {
            this.obj.Colors = colors;
            return this;
        }

        public HighchartsSetUp Settings(Action<ChartSettingsConfigurator> expression)
        {
            expression.Invoke(new ChartSettingsConfigurator(this.obj.Chart));
            return this;
        }

        public HighchartsSetUp AxisY(Action<AxisYConfigurator> expression)
        {
            expression.Invoke(new AxisYConfigurator(this.obj.YAxis));
            return this;
        }

        public HighchartsSetUp AxisX(Action<AxisXConfigurator> expression)
        {
            expression.Invoke(new AxisXConfigurator(this.obj.XAxis));
            return this;
        }

        public HighchartsSetUp Tooltip(Action<TooltipConfigurator> expression)
        {
            expression.Invoke(new TooltipConfigurator(this.obj.Tooltip));
            return this;
        }

        public HighchartsSetUp Legend(Action<LegendConfigurator> expression)
        {
            expression.Invoke(new LegendConfigurator(this.obj.Legend));
            return this;
        }

        public HighchartsSetUp Credits(Action<CreditsConfigurator> expression)
        {
            expression.Invoke(new CreditsConfigurator(this.obj.Credits));
            return this;
        }

        public HighchartsSetUp Exporting(Action<ExportingConfigurator> expression)
        {
            expression.Invoke(new ExportingConfigurator(this.obj.Exporting));
            return this;
        }

        private HighchartsSetUp Configure<T>(Expression<Func<T, JsonConfigurator>> expression) where T : JsonConfigurator, new()
        {
            this.chartConfig.Set(expression.ToJson());
            return this;
        }
    }
}
