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
                                        .Title("This is my chart with a title!")
                                        .Subtitle("And this is my subtitle!")
                                        .Options(
                                            PlotOptions.Line.ShowDataLabels().HideInLegend()
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
                                                          title: {
                                                            text: 'This is my chart with a title!'
                                                          },
                                                          subtitle: {
                                                            text: 'And this is my subtitle!'
                                                          },
                                                          plotOptions: {
                                                            line: {
                                                                dataLabels: {
                                                                    enabled: true
                                                                },
                                                                showInLegend: false
                                                            }
                                                          }
                                                      });
                                                  });
                                                  </script>");

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
