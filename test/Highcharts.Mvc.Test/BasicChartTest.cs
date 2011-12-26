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
        public void BasicSetup_WithTitle_AndSubtitle()
        {
            HighchartsChart chart = new HighchartsChart("myChart")
                                        .Title("This is my chart with a title!")
                                        .Subtitle("And this is my subtitle!");


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
                                                          },
                                                          subtitle: {
                                                             text: 'And this is my subtitle!'
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
        public void BasicSetup_Type()
        {
            HighchartsChart chart = new HighchartsChart("myChart").WithSerieType(ChartSerieType.Bar);

            var actual = chart.ToHtmlString();
            var expected = MvcHtmlString.Create(@"<div id=""myChart""></div>
                                                  <script type=""text/javascript"">
                                                  var myChart;
                                                  $(document).ready(function () {
                                                      myChart = new Highcharts.Chart({
                                                          chart: {
                                                            renderTo: 'myChart',
                                                            type: 'bar'
                                                          }
                                                      });
                                                  });
                                                  </script>");

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
