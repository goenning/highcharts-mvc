using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Globalization;
using NUnit.Framework;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class BasicChartTest
    {
        [Test]
        public void BasicSetup()
        {
            HighchartsChart chart = new HighchartsChart("myChart");
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
                                                  });
                                                  </script>");

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BasicSetup_WithTitle()
        {
            HighchartsChart chart = new HighchartsChart("myChart").Title("This is my chart with a title!");
            var actual = chart.ToHtmlString();
            var expected = MvcHtmlString.Create(@"<div id=""myChart""></div>
                                                  <script type=""text/javascript"">
                                                  var myChart;
                                                  $(document).ready(function () {
                                                      myChart = new Highcharts.Chart({
                                                          chart: {
                                                            renderTo: 'myChart'
                                                          },
                                                          title: {
                                                            text: 'This is my chart with a title!'
                                                          }
                                                      });
                                                  });
                                                  </script>");

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BasicSetup_WithXAxisCategories()
        {
            HighchartsChart chart = new HighchartsChart("myChart")
                                    .AxisX("Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec");

            var actual = chart.ToHtmlString();
            var expected = MvcHtmlString.Create(@"<div id=""myChart""></div>
                                                  <script type=""text/javascript"">
                                                  var myChart;
                                                  $(document).ready(function () {
                                                      myChart = new Highcharts.Chart({
                                                          chart: {
                                                            renderTo: 'myChart'
                                                          },
                                                          xAxis: {
                                                             categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 
                                                                'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
                                                          }
                                                      });
                                                  });
                                                  </script>");

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BasicSetup_WithYAxisTitle()
        {
            HighchartsChart chart = new HighchartsChart("myChart")
                                    .AxisY("Tickets");

            var actual = chart.ToHtmlString();
            var expected = MvcHtmlString.Create(@"<div id=""myChart""></div>
                                                  <script type=""text/javascript"">
                                                  var myChart;
                                                  $(document).ready(function () {
                                                      myChart = new Highcharts.Chart({
                                                          chart: {
                                                            renderTo: 'myChart'
                                                          },
                                                          yAxis: {
                                                             title: {
                                                                text: 'Tickets'
                                                             }
                                                          }
                                                      });
                                                  });
                                                  </script>");

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BasicSetup_WithSeries()
        {
            HighchartsChart chart = new HighchartsChart("myChart")
                                    .Series(
                                        new Serie("Open", new int?[] { 10, 15, 61 }),
                                        new Serie("Closed", new int?[] { 461, 473, 985 }),
                                        new Serie("Pending", new int?[] { 722, 526, 224 })
                                    );

            var actual = chart.ToHtmlString();
            var expected = MvcHtmlString.Create(@"<div id=""myChart""></div>
                                                  <script type=""text/javascript"">
                                                  var myChart;
                                                  $(document).ready(function () {
                                                      myChart = new Highcharts.Chart({
                                                          chart: {
                                                            renderTo: 'myChart'
                                                          },
                                                          series: [{
                                                              name: 'Open',
                                                              data: [10, 15, 61]
                                                          }, {
                                                              name: 'Closed',
                                                              data: [461, 473, 985]
                                                          }, {
                                                              name: 'Pending',
                                                              data: [722, 526, 224]
                                                          }]
                                                      });
                                                  });
                                                  </script>");

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
