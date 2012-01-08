using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace Highcharts.Mvc
{
    public class ArrayChartDataSource : ChartDataSource
    {
        public IEnumerable<Serie> Series { get; private set; }
        public ArrayChartDataSource(IEnumerable<Serie> series)
        {
            this.Series = series;
        }

        public override string ToHtmlString(string chartId)        
        {
            StringBuilder script = new StringBuilder();
            foreach (var serie in this.Series)
            {
                JsonObject jsonSerie = new JsonObject();
                jsonSerie.Set(new JsonObject("name", serie.Name));
                if (!string.IsNullOrEmpty(serie.Type))
                    jsonSerie.Set(new JsonObject("type", serie.Type));
                jsonSerie.Set(new JsonObject("data", serie.Values));

                script.AppendFormat("hCharts['{0}'].addSeries({{ {1} }}); {2}", chartId, jsonSerie.ToString(), Environment.NewLine);
            }

            return script.ToString();
        }
    }
}
