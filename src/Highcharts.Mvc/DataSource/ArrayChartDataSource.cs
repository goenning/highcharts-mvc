using System.Collections.Generic;
using System.Linq;
using Highcharts.Mvc.Json;

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
                if (!serie.Type.Equals(ChartSerieType.Default))
                    serieObj.Add(new JsonAttribute("type", serie.Type));
                serieObj.Add(new JsonAttribute("data", serie.Values));

                if(serie is PieSerie)
                {
                    var pieSerie = serie as PieSerie;

                    if(pieSerie.Size.HasValue)
                    {
                        serieObj.Add(new JsonAttribute("size", string.Format("{0}%", pieSerie.Size.Value)));
                    }
                    if(pieSerie.InnerSize.HasValue)
                    {
                        serieObj.Add(new JsonAttribute("innerSize", string.Format("{0}%", pieSerie.InnerSize.Value)));
                    }
                }

			    seriesObjects[i] = serieObj;
            }

            return new JsonAttribute("series", seriesObjects);
        }
    }
}
