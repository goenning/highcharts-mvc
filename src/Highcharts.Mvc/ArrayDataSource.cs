using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace Highcharts.Mvc
{
    public class ArrayDataSource : DataSource
    {
        public Serie[] Series { get; private set; }
        public ArrayDataSource(Serie[] series)
        {
            this.Series = series;
        }

        public override string ToHtmlString(string chartId)        
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            StringBuilder script = new StringBuilder();
            foreach (var serie in this.Series)
            {
                script.AppendFormat("{0}.addSeries({{ name: '{1}', data: {2} }}); {3}", chartId, serie.Name, serializer.Serialize(serie.Values), Environment.NewLine);
            }
            return script.ToString();
        }
    }
}
