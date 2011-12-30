using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Highcharts.Mvc
{
    public class HighchartsChart<T> : HighchartsChart
    {
        private IEnumerable<T> items;
        public HighchartsChart(string id, IEnumerable<T> items)
            : base(id)
        {
            this.items = items;
        }

        public HighchartsChart<T> Series(Expression<Func<T, string>> name, Expression<Func<T, object>> values)
        {
            var dataSource = new ExpressionChartDataSource<T>(items, name, values);
            this.Series(dataSource);

            return this;
        }
    }
}
