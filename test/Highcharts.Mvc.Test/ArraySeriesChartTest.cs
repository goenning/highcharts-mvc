using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web.Mvc;
using System.Diagnostics;
using Highcharts.Mvc.Test.Models;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class ArraySeriesChartTest
    {
        [Test]
        public void BasicSetup_WithSeries()
        {
            HighchartsChart chart = new HighchartsChart("myChart")
                                    .Series(
                                        new Serie("Open", 10, 15, 61),
                                        new Serie("Closed", 461, 473, 985),
                                        new Serie("Pending", 722, 526, 224)
                                    );

            var actual = chart.ToHtmlString();
            var expected = MvcHtmlString.Create(@"<div id=""myChart""></div>
                                                  <script type=""text/javascript"">
                                                  var myChart;
                                                  $(document).ready(function () {
                                                    myChart = new Highcharts.Chart({
                                                        chart: {
                                                            renderTo: 'myChart'
                                                        }
                                                    });

                                                    myChart.addSeries({ name: 'Open', data: [10, 15, 61] });
                                                    myChart.addSeries({ name: 'Closed', data: [461, 473, 985] });
                                                    myChart.addSeries({ name: 'Pending', data: [722, 526, 224] });
                                                  });
                                                  </script>");

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BasicSetup_WithExpressionSeries()
        {
            List<SaleReportItem> items = new List<SaleReportItem>();
            items.Add(new SaleReportItem("Jack Sparrow", new float[] { 1256.03f, 3521.12f, 6412.61f, 3526.35f, 5413.461f }));
            items.Add(new SaleReportItem("Luke Skywalker", new float[] { 857f, 2311.64f, 1542.12f, 3451.2f, 3613f }));

            HighchartsChart chart = new HighchartsChart<SaleReportItem>("myChart", items)
                                        .Series(x => x.Employee, x => x.TotalSalesValue);

            var actual = chart.ToHtmlString();
            var expected = MvcHtmlString.Create(@"<div id=""myChart""></div>
                                                  <script type=""text/javascript"">
                                                  var myChart;
                                                  $(document).ready(function () {
                                                    myChart = new Highcharts.Chart({
                                                        chart: {
                                                            renderTo: 'myChart'
                                                        }
                                                    });

                                                    myChart.addSeries({ name: 'Jack Sparrow', data: [ 1256.03, 3521.12, 6412.61, 3526.35, 5413.461 ] });
                                                    myChart.addSeries({ name: 'Luke Skywalker', data: [ 857, 2311.64, 1542.12, 3451.2, 3613 ] });
                                                  });
                                                  </script>");

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
