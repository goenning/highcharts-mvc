using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Highcharts.Mvc.Test.Models;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class ExpressionChartDataSourceTest
    {
        [Test]
        public void EmptyDataSource()
        {
            List<SaleReportItem> items = new List<SaleReportItem>();

            ExpressionChartDataSource<SaleReportItem> dataSource = new ExpressionChartDataSource<SaleReportItem>(items, x => x.Employee, x => x.TotalSalesValue);

            string actual = dataSource.ToHtmlString("some-id");
            string expected = "";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void DataSourceWithTwoValues()
        {
            List<SaleReportItem> items = new List<SaleReportItem>();
            items.Add(new SaleReportItem("Jack Sparrow", new float[] { 1256.03f, 3521.12f, 6412.61f, 3526.35f, 5413.461f }));
            items.Add(new SaleReportItem("Luke Skywalker", new float[] { 857f, 2311.64f, 1542.12f, 3451.2f, 3613f }));

            ExpressionChartDataSource<SaleReportItem> dataSource = new ExpressionChartDataSource<SaleReportItem>(items, x => x.Employee, x => x.TotalSalesValue);

            string actual = dataSource.ToHtmlString("myChart");
            string expected = @"myChart.addSeries({ name: 'Jack Sparrow', data: [ 1256.03, 3521.12, 6412.61, 3526.35, 5413.461 ] });
                                myChart.addSeries({ name: 'Luke Skywalker', data: [ 857, 2311.64, 1542.12, 3451.2, 3613 ] });";

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
