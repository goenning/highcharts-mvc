using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Web.Script.Serialization;

namespace Highcharts.Mvc
{
    public class ExpressionChartDataSource<T> : ChartDataSource
    {
        private IEnumerable<T> items;
        private Expression<Func<T, string>> name;
        private Expression<Func<T, object>> values;

        public ExpressionChartDataSource(IEnumerable<T> items, Expression<Func<T, string>> name, Expression<Func<T, object>> values)
        {
            this.items = items;
            this.name = name;
            this.values = values;
        }

        public override string ToHtmlString(string chartId)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            StringBuilder script = new StringBuilder();

            var getName = this.name.Compile();
            var getValues = this.values.Compile();

            foreach (var item in this.items)
            {
                string name = getName.Invoke(item);
                object values = getValues.Invoke(item);
                script.AppendFormat("{0}.addSeries({{ name: '{1}', data: {2} }}); {3}", chartId, name, serializer.Serialize(values), Environment.NewLine);
            }

            return script.ToString();
        }
    }
}
