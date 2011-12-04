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

        public HighchartsChart(string id)
        {
            this.id = id;
        }

        public IHtmlString ToHtmlString()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            StringBuilder chartOptions = new StringBuilder();
            chartOptions.AppendFormat(@"chart: {{
                                            renderTo: '{0}'
                                        }}", this.id);

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
    }
}
