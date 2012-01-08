using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;

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

            this.chartConfig.Set(
                new JsonObject("chart", 
                    new JsonObject("renderTo", this.Id)
                )
            );
        }

        public virtual IHtmlString ToHtmlString()
        {
            string chartSource = dataSource.ToHtmlString(this.Id);

            StringBuilder html = new StringBuilder();
            html.AppendFormat(@"$(document).ready(function () {{
                                    hCharts['{0}'] = new Highcharts.Chart({{
                                        {1}
                                    }});

                                    {2}
                                }});", this.Id, this.chartConfig.ToString(), chartSource);

            return MvcHtmlString.Create(html.ToString());
        }

        public HighchartsSetUp Title(string title)
        {
            this.chartConfig.Set(
                new JsonObject("title",
                    new JsonObject("text", title)
                )
            );

            return this;
        }

        public HighchartsSetUp AxisX(params string[] categories)
        {
            this.chartConfig.Set(
                new JsonObject("xAxis",
                    new JsonObject("categories", categories)
                )
            );

            return this;
        }

        public HighchartsSetUp AxisY(string title)
        {
            this.chartConfig.Set(
                new JsonObject("yAxis",
                    new JsonObject("title", 
                        new JsonObject("text", title)
                    )
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

            this.chartConfig.Set(
                new JsonObject("chart",
                    new JsonObject("renderTo", this.Id),
                    new JsonObject("type", serieTypeName)
                )
            );

            return this;
        }

        public HighchartsSetUp Subtitle(string subtitle)
        {
            this.chartConfig.Set(
                new JsonObject("subtitle",
                    new JsonObject("text", subtitle)
                )
            );

            return this;
        }

        public HighchartsSetUp Options(params PlotOptions[] options)
        {
            var jsons = options.Select(x => x.ToJson()).ToArray();
            this.chartConfig.Set(
                new JsonObject("plotOptions", jsons)
            ); 

            return this;
        }

        public HighchartsSetUp Tooltip(Expression<Func<TooltipConfigurator, IJsonConfigurator>> expression)
        {
            return this.Configure(expression);
        }

        public HighchartsSetUp Legend(Expression<Func<LegendConfigurator, IJsonConfigurator>> expression)
        {
            return this.Configure(expression);
        }

        public HighchartsSetUp Credits(Expression<Func<CreditsConfigurator, IJsonConfigurator>> expression)
        {
            return this.Configure(expression);
        }

        private HighchartsSetUp Configure<T>(Expression<Func<T, IJsonConfigurator>> expression) where T : new()
        {
            this.chartConfig.Set(expression.ToJson());
            return this;
        }
    }
}
