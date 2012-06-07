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
        protected bool CreditsEnabled { get; set; }
        protected bool PrintButtonEnabled { get; set; }

        private ChartDataSource dataSource;
        private JsonObject chartConfig;

        public HighchartsSetUp(string id)
        {
            this.Id = id;
            this.dataSource = new EmptyDataSource();
            this.chartConfig = new JsonObject();

            this.chartConfig.Add(
                new JsonAttribute("chart", 
                    new JsonAttribute("renderTo", this.Id),
                    new JsonAttribute("credits", new JsonAttribute("enabled", this.CreditsEnabled),
                        new JsonAttribute("exporting",new JsonAttribute("printButton", 
                            new JsonAttribute("enabled", this.PrintButtonEnabled)))
                ))
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

        public HighchartsSetUp AxisX(string title, params string[] categories)
        {
            this.chartConfig.Add(
                new JsonAttribute("xAxis",
                    new JsonAttribute("title", new JsonAttribute("text", title)),
                    new JsonAttribute("categories", categories)
                )
            );

            return this;
        }

        public HighchartsSetUp AxisX(string title, int labelRotation, params string[] categories)
        {
            this.chartConfig.Add(
                new JsonAttribute("xAxis",
                    new JsonAttribute("title", new JsonAttribute("text", title)),
                    new JsonAttribute("categories", categories),
                    new JsonAttribute("labels", new JsonAttribute("rotation", labelRotation))
                )
            );

            return this;
        }

        public HighchartsSetUp AxisX(params string[] categories)
        {
            this.chartConfig.Add(
                new JsonAttribute("xAxis",
                    new JsonAttribute("categories", categories)
                )
            );

            return this;
        }

        public HighchartsSetUp AxisY(string title)
        {
            this.chartConfig.Add(
                new JsonAttribute("yAxis",
                    new JsonAttribute("title", 
                        new JsonAttribute("text", title)
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

        private HighchartsSetUp Configure<T>(Expression<Func<T, JsonConfigurator>> expression) where T : new()
        {
            this.chartConfig.Add(expression.ToJson());
            return this;
        }
    }
}
