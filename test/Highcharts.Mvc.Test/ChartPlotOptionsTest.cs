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
            var actual = new HighchartsChart("myChart")
                            .Options(
                                PlotOptions.Line.ShowDataLabels().HideInLegend().Color("#00FF00")
                            ).ToHtmlString();


            var expected = MvcHtmlString.Create(@"<div id=""myChart""></div>
                                                  <script type=""text/javascript"">
                                                  $(document).ready(function () {
                                                      hCharts['myChart'] = new Highcharts.Chart({
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
            var actual = new HighchartsChart("myChart")
                            .Options(
                                PlotOptions.Line.HideInLegend(),
                                PlotOptions.Column.ShowDataLabels()
                            ).ToHtmlString();

            var expected = MvcHtmlString.Create(@"<div id=""myChart""></div>
                                                  <script type=""text/javascript"">
                                                  $(document).ready(function () {
                                                      hCharts['myChart'] = new Highcharts.Chart({
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

        [Test]
        public void Chart_WithThreePlotOptions()
        {
            var actual = new HighchartsChart("myChart")
                            .Options(
                                PlotOptions.Line.HideInLegend(),
                                PlotOptions.Series.HideInLegend(),
                                PlotOptions.Column.HideInLegend()
                            ).ToHtmlString();


            var expected = MvcHtmlString.Create(@"<div id=""myChart""></div>
                                                  <script type=""text/javascript"">
                                                  $(document).ready(function () {
                                                      hCharts['myChart'] = new Highcharts.Chart({
                                                          chart: {
                                                            renderTo: 'myChart'
                                                          },
                                                          plotOptions: {
                                                            line: {
                                                                showInLegend: false
                                                            },
                                                            series: {
                                                                showInLegend: false
                                                            },
                                                            column: {
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
