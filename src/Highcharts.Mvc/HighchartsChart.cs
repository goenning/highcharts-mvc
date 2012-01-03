﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Dynamic;
using System.Linq.Expressions;

namespace Highcharts.Mvc
{
    public class HighchartsChart
    {
        private string id;
        private ChartDataSource dataSource;
        private JsonObject chartConfig;

        public HighchartsChart(string id)
        {
            this.id = id;
            this.dataSource = new EmptyDataSource();
            this.chartConfig = new JsonObject();

            this.chartConfig.Set(
                new JsonObject("chart", 
                    new JsonObject("renderTo", this.id)
                )
            );
        }

        public IHtmlString ToHtmlString()
        {
            string chartSource = dataSource.ToHtmlString(this.id);

            StringBuilder html = new StringBuilder();
            html.AppendFormat("<div id=\"{0}\"></div>", this.id);
            html.AppendLine();
            html.AppendFormat(@"<script type=""text/javascript"">
                                    var {0};
                                    $(document).ready(function () {{
                                        {0} = new Highcharts.Chart({{
                                            {1}
                                        }});

                                        {2}
                                    }});
                                </script>", this.id, this.chartConfig.ToString(), chartSource);

            return MvcHtmlString.Create(html.ToString());
        }

        public HighchartsChart Title(string title)
        {
            this.chartConfig.Set(
                new JsonObject("title",
                    new JsonObject("text", title)
                )
            );

            return this;
        }

        public HighchartsChart AxisX(params string[] categories)
        {
            this.chartConfig.Set(
                new JsonObject("xAxis",
                    new JsonObject("categories", categories)
                )
            );

            return this;
        }

        public HighchartsChart AxisY(string title)
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

        public HighchartsChart Series(ChartDataSource datasource)
        {
            this.dataSource = datasource;
            return this;
        }

        public HighchartsChart Series(IEnumerable<Serie> series)
        {
            return Series(new ArrayChartDataSource(series));
        }

        public HighchartsChart Series(params Serie[] series)
        {
            return Series(series.AsEnumerable());
        }

        public HighchartsChart WithSerieType(ChartSerieType serieType)
        {
            string serieTypeName = serieType.ToString().ToLower();

            this.chartConfig.Set(
                new JsonObject("chart",
                    new JsonObject("renderTo", this.id),
                    new JsonObject("type", serieTypeName)
                )
            );

            return this;
        }

        public HighchartsChart Subtitle(string subtitle)
        {
            this.chartConfig.Set(
                new JsonObject("subtitle",
                    new JsonObject("text", subtitle)
                )
            );

            return this;
        }

        public HighchartsChart Options(params PlotOptions[] options)
        {
            var jsons = options.Select(x => x.ToJson()).ToArray();
            this.chartConfig.Set(
                new JsonObject("plotOptions", jsons)
            ); 

            return this;
        }

        public HighchartsChart Tooltip(Expression<Func<TooltipConfigurator, IJsonConfigurator>> expression)
        {
            return this.Configure<TooltipConfigurator>(expression);
        }

        public HighchartsChart Legend(Expression<Func<LegendConfigurator, IJsonConfigurator>> expression)
        {
            return this.Configure<LegendConfigurator>(expression);
        }

        private HighchartsChart Configure<T>(Expression<Func<T, IJsonConfigurator>> expression) where T : new()
        {
            T configurator = new T();
            var config = expression.Compile().Invoke(configurator);
            this.chartConfig.Set(config.ToJson());
            return this;
        }
    }
}