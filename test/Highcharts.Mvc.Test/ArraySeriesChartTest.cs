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
        public void BasicSetUp_WithSeries()
        {
            var chart = new HighchartsChart("myChart")
                            .Series(
                                new Serie("Open", new int[] { 10, 15, 61 }),
                                new Serie("Closed", new int[] { 461, 473, 985 }),
                                new Serie("Pending", new int[] { 722, 526, 224 })
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
        public void BasicSetUp_WithTypedSeries()
        {
            var chart = new HighchartsChart("myChart")
                            .Series(
                                new ColumnSerie("Open", new int[] { 10, 15, 61 }),
                                new LineSerie("Closed", new int[] { 461, 473, 985 }),
                                new LineSerie("Pending", new int[] { 722, 526, 224 })
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

                                                    myChart.addSeries({ name: 'Open', type: 'column', data: [10, 15, 61] });
                                                    myChart.addSeries({ name: 'Closed', type: 'line' ,data: [461, 473, 985] });
                                                    myChart.addSeries({ name: 'Pending', type: 'line', data: [722, 526, 224] });
                                                  });
                                                  </script>");

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
