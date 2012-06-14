using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc
{
    public class HighchartsSetUp
    {
        protected string Id { get; private set; }

        private ChartDataSource dataSource;
        private JsonObject chartConfig;

        public HighchartsSetUp(string id)
        {
            this.Id = id;
            this.dataSource = new EmptyDataSource();
            this.chartConfig = new JsonObject();

            this.chartConfig.Add(
                new JsonAttribute("chart", 
                    new JsonAttribute("renderTo", this.Id)
                )
            );
        }

        public virtual IHtmlString ToHtmlString()
        {
            IHtmlString chartSource = this.dataSource.ToHtmlString(this.Id);
            this.chartConfig.Add(this.dataSource.AsJsonAttribute());

            StringBuilder html = new StringBuilder();
            html.AppendFormat(@"$(document).ready(function () {{
                                    hCharts['{0}'] = new Highcharts.Chart({1});

                                    {2}
                                }});", this.Id, this.chartConfig.ToString(), chartSource);

            return MvcHtmlString.Create(html.ToString());
        }

        public HighchartsSetUp Title(string title)
        {
            this.chartConfig.Add(
                new JsonAttribute("title",
                    new JsonAttribute("text", title)
                )
            );

            return this;
        }

        public HighchartsSetUp Series(ChartDataSource datasource)
        {
            this.dataSource = datasource;
            return this;
        }

        public HighchartsSetUp Series(IEnumerable<Serie> series)
        {
            return Series(new ArrayChartDataSource(series));
        }

        public HighchartsSetUp Series(params Serie[] series)
        {
            return Series(series.AsEnumerable());
        }

        public HighchartsSetUp WithSerieType(ChartSerieType serieType)
        {
            string serieTypeName = serieType.ToString().ToLower();

            this.chartConfig.Add(
                new JsonAttribute("chart",
                    new JsonAttribute("renderTo", this.Id),
                    new JsonAttribute("type", serieTypeName)
                )
            );

            return this;
        }

        public HighchartsSetUp Subtitle(string subtitle)
        {
            this.chartConfig.Add(
                new JsonAttribute("subtitle",
                    new JsonAttribute("text", subtitle)
                )
            );

            return this;
        }

        public HighchartsSetUp Options(params PlotOptionsConfiguration[] options)
        {
            var jsons = options.Select(x => x.ToJson()).ToArray();
            this.chartConfig.Add(
                new JsonAttribute("plotOptions", jsons)
            ); 

            return this;
        }

        public HighchartsSetUp AxisY(Expression<Func<AxisYConfigurator, JsonConfigurator>> expression)
        {
            return this.Configure(expression);
        }

        public HighchartsSetUp AxisX(Expression<Func<AxisXConfigurator, JsonConfigurator>> expression)
        {
            return this.Configure(expression);
        }

        public HighchartsSetUp Tooltip(Expression<Func<TooltipConfigurator, JsonConfigurator>> expression)
        {
            return this.Configure(expression);
        }

        public HighchartsSetUp Legend(Expression<Func<LegendConfigurator, JsonConfigurator>> expression)
        {
            return this.Configure(expression);
        }

        public HighchartsSetUp Credits(Expression<Func<CreditsConfigurator, JsonConfigurator>> expression)
        {
            return this.Configure(expression);
        }

        public HighchartsSetUp Exporting(Expression<Func<ExportingConfigurator, JsonConfigurator>> expression)
        {
            return this.Configure(expression);
        }

        private HighchartsSetUp Configure<T>(Expression<Func<T, JsonConfigurator>> expression) where T : JsonConfigurator, new()
        {
            this.chartConfig.Add(expression.ToJson());
            return this;
        }
    }
}
