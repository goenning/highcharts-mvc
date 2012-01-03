using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web.Mvc;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class ChartPlotOptionsTest
    {
        [Test]
        public void Chart_WithBasicPlotOptions()
        {
            HighchartsChart chart = new HighchartsChart("myChart")
                                        .Options(
                                            PlotOptions.Line.ShowDataLabels().HideInLegend().Color("#00FF00")
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
                                                          plotOptions: {
                                                            line: {
                                                                dataLabels: {
                                                                    enabled: true
                                                                },
                                                                showInLegend: false,
                                                                color: '#00FF00'
                                                            }
                                                          }
                                                      });
                                                  });
                                                  </script>");

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Chart_WithTwoPlotOptions()
        {
            HighchartsChart chart = new HighchartsChart("myChart")
                                        .Options(
                                            PlotOptions.Line.HideInLegend(),
                                            PlotOptions.Column.ShowDataLabels()
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
                                                          plotOptions: {
                                                            line: {
                                                                showInLegend: false
                                                            },
                                                            column: {
                                                                dataLabels: {
                                                                    enabled: true
                                                                }
                                                            }
                                                          }
                                                      });
                                                  });
                                                  </script>");

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
