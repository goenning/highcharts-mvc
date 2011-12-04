using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Dynamic;

namespace Highcharts.Mvc
{
    public class HighchartsChart
    {
        private string id;
        private string title;
        private string[] xAxisCategories;
        private string yAxisTitle;
        private Serie[] series;
        private ChartSerieType serieType;

        public HighchartsChart(string id)
        {
            this.id = id;
            this.serieType = ChartSerieType.Default;
        }

        public IHtmlString ToHtmlString()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            StringBuilder chartOptions = new StringBuilder();
            string serieTypeName = this.serieType.ToString().ToLower();

            if (this.serieType == ChartSerieType.Default)
            {
                chartOptions.AppendFormat(@"chart: {{
                                            renderTo: '{0}'
                                        }}", this.id);
            }
            else
            {
                chartOptions.AppendFormat(@"chart: {{
                                            renderTo: '{0}',
                                            type: '{1}'
                                        }}", this.id, serieTypeName);  
            }

            if (this.title != null)
            {
                chartOptions.AppendFormat(@", title: {{
                                                text: '{0}'
                                            }}", this.title);
            }

            if (this.xAxisCategories != null)
            {
                string categories = serializer.Serialize(this.xAxisCategories).Replace("\"", "'");
                chartOptions.AppendFormat(@", xAxis: {{
                                                categories: {0}
                                            }}", categories);
            }

            if (this.yAxisTitle != null)
            {
                chartOptions.AppendFormat(@", yAxis: {{
                                                title: {{ 
                                                    text: '{0}'
                                                }}
                                            }}", this.yAxisTitle);
            }

            if (this.series != null)
            {
                StringBuilder seriesOptions = new StringBuilder();
                seriesOptions.Append("[");
                for (int i = 0; i < this.series.Length; i++)
                {
                    Serie serie = this.series[i];
                    if (i > 0)
                        seriesOptions.Append(",");

                    seriesOptions.AppendFormat("{{ name:'{0}', data: {1} }}", serie.Name, serializer.Serialize(serie.Values));
                }
                seriesOptions.Append("]");
                chartOptions.AppendFormat(@", series: {0}", seriesOptions.ToString());
            }

            StringBuilder html = new StringBuilder();
            html.AppendFormat("<div id=\"{0}\"></div>", this.id);
            html.AppendLine();
            html.AppendFormat(@"<script type=""text/javascript"">
                                    var {0};
                                    $(document).ready(function () {{
                                        {0} = new Highcharts.Chart({{
                                            {1}
                                        }});
                                    }});
                                </script>", this.id, chartOptions.ToString());

            return MvcHtmlString.Create(html.ToString());
        }

        public HighchartsChart Title(string title)
        {
            this.title = title;
            return this;
        }

        public HighchartsChart AxisX(params string[] categories)
        {
            this.xAxisCategories = categories;
            return this;
        }

        public HighchartsChart AxisY(string title)
        {
            this.yAxisTitle = title;
            return this;
        }

        public HighchartsChart Series(params Serie[] series)
        {
            this.series = series;
            return this;
        }

        public HighchartsChart WithSerieType(ChartSerieType serieType)
        {
            this.serieType = serieType;
            return this;
        }
    }
}
