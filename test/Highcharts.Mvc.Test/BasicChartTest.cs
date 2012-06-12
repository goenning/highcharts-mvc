﻿using System.Web.Mvc;
using NUnit.Framework;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class BasicChartTest
    {
        [Test]
        public void EmptySetUp()
        {
            var chart = new HighchartsChart("myChart");
            var actual = chart.ToHtmlString();
            var expected = MvcHtmlString.Create(@"<div id=""myChart""></div>
                                                  <script type=""text/javascript"">
                                                  $(document).ready(function () {
                                                      hCharts['myChart'] = new Highcharts.Chart({
                                                          chart: {
                                                            renderTo: 'myChart'
                                                          }
                                                      });
                                                  });
                                                  </script>");

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BasicSetUp_WithTitle()
        {
            var chart = new HighchartsChart("myChart")
                            .Title("This is my chart with a title!");
            var actual = chart.ToHtmlString();
            var expected = MvcHtmlString.Create(@"<div id=""myChart""></div>
                                                  <script type=""text/javascript"">
                                                  $(document).ready(function () {
                                                      hCharts['myChart'] = new Highcharts.Chart({
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
        public void BasicSetUp_WithTitle_AndSubtitle()
        {
            var chart = new HighchartsChart("myChart")
                            .Title("This is my chart with a title!")
                            .Subtitle("And this is my subtitle!");


            var actual = chart.ToHtmlString();
            var expected = MvcHtmlString.Create(@"<div id=""myChart""></div>
                                                  <script type=""text/javascript"">
                                                  $(document).ready(function () {
                                                      hCharts['myChart'] = new Highcharts.Chart({
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
        public void BasicSetUp_WithXAxisCategories()
        {
            var chart = new HighchartsChart("myChart")
                            .AxisX("Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec");

            var actual = chart.ToHtmlString();
            var expected = MvcHtmlString.Create(@"<div id=""myChart""></div>
                                                  <script type=""text/javascript"">
                                                  $(document).ready(function () {
                                                      hCharts['myChart'] = new Highcharts.Chart({
                                                          chart: {
                                                            renderTo: 'myChart'
                                                          },
                                                          xAxis: { title: { text: 'Jan' },
                                                             categories: ['Feb', 'Mar', 'Apr', 'May', 'Jun', 
                                                                'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
                                                          }
                                                      });
                                                  });
                                                  </script>");

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BasicSetUp_WithoutXAxisTitle_Should_Cause_Bug()
        {
            //This exposes a bug in the AxisX method - it accepts a string for the title and a params string[] of categories,
            //but can't differentiate between title and categories, so even if title was not intentially set, it gets set to the
            //first category.
            var chart = new HighchartsChart("myChart")
                .AxisX("Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec");

            var actual = chart.ToHtmlString();
            var expected = MvcHtmlString.Create(@"<div id=""myChart""></div>
                                                  <script type=""text/javascript"">
                                                  $(document).ready(function () {
                                                      hCharts['myChart'] = new Highcharts.Chart({
                                                          chart: {
                                                            renderTo: 'myChart'
                                                          },
                                                          xAxis:
                                                             categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 
                                                                'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
                                                          }
                                                      });
                                                  });
                                                  </script>");

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BasicSetUp_WithYAxisTitle()
        {
            var chart = new HighchartsChart("myChart")
                            .AxisY("Tickets");

            var actual = chart.ToHtmlString();
            var expected = MvcHtmlString.Create(@"<div id=""myChart""></div>
                                                  <script type=""text/javascript"">
                                                  $(document).ready(function () {
                                                      hCharts['myChart'] = new Highcharts.Chart({
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
        public void BasicSetUp_Type()
        {
            var chart = new HighchartsChart("myChart")
                            .WithSerieType(ChartSerieType.Bar);

            var actual = chart.ToHtmlString();
            var expected = MvcHtmlString.Create(@"<div id=""myChart""></div>
                                                  <script type=""text/javascript"">
                                                  $(document).ready(function () {
                                                      hCharts['myChart'] = new Highcharts.Chart({
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
