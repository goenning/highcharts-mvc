using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using Highcharts.Mvc.Json;
using System.Web;
using System.Web.Mvc;

namespace Highcharts.Mvc
{
    public class ArrayChartDataSource : ChartDataSource
    {
        public IEnumerable<Serie> Series { get; private set; }
        public ArrayChartDataSource(IEnumerable<Serie> series)
        {
            this.Series = series;
        }

        public override JsonAttribute AsJsonAttribute()
        {
            JsonObject[] seriesObjects = new JsonObject[this.Series.Count()];
            
            for (int i = 0; i < seriesObjects.Length; i++)
            {
                Serie serie = this.Series.ElementAt(i);
                JsonObject serieObj = new JsonObject();

                serieObj.Add(new JsonAttribute("name", serie.Name));
                if (!string.IsNullOrEmpty(serie.Type))
                    serieObj.Add(new JsonAttribute("type", serie.Type));
                serieObj.Add(new JsonAttribute("data", serie.Values));

			    seriesObjects[i] = serieObj;
            }

            return new JsonAttribute("series", seriesObjects);
        }
    }
}
