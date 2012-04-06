using System.Web.Mvc;
using NUnit.Framework;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class ArraySeriesChartTest
    {
        [Test]
        public void BasicSetUp_WithSeries()
        {
            var actual = new HighchartsChart("myChart")
                            .Series(
                                new Serie("Open", new int[] { 10, 15, 61 }),
                                new Serie("Closed", new int[] { 461, 473, 985 }),
                                new Serie("Pending", new int[] { 722, 526, 224 })
                            )
                            .ToHtmlString();

            var expected = MvcHtmlString.Create(@"<div id=""myChart""></div>
                                                  <script type=""text/javascript"">
                                                  $(document).ready(function () {
                                                      hCharts['myChart'] = new Highcharts.Chart({
                                                        chart: {
                                                            renderTo: 'myChart'
                                                        },
                                                        series: [
                                                            { name: 'Open', data: [10, 15, 61] },
                                                            { name: 'Closed', data: [461, 473, 985] },
                                                            { name: 'Pending', data: [722, 526, 224] }
                                                        ]
                                                    });
                                                  });
                                                  </script>");

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BasicSetUp_WithTypedSeries()
        {
            var actual = new HighchartsChart("myChart")
                            .Series(
                                new ColumnSerie("Open", new int[] { 10, 15, 61 }),
                                new LineSerie("Closed", new int[] { 461, 473, 985 }),
                                new LineSerie("Pending", new int[] { 722, 526, 224 })
                            )
                            .ToHtmlString();

            var expected = MvcHtmlString.Create(@"<div id=""myChart""></div>
                                                  <script type=""text/javascript"">
                                                  $(document).ready(function () {
                                                      hCharts['myChart'] = new Highcharts.Chart({
                                                        chart: {
                                                            renderTo: 'myChart'
                                                        },
                                                        series: [
                                                            { name: 'Open', type: 'column', data: [10, 15, 61] },
                                                            { name: 'Closed', type: 'line' ,data: [461, 473, 985] },
                                                            { name: 'Pending', type: 'line', data: [722, 526, 224] }
                                                        ]
                                                    });
                                                  });
                                                  </script>");

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
