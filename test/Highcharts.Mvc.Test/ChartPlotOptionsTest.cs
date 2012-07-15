using System.Web.Mvc;
using NUnit.Framework;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class ChartPlotOptionsTest
    {
        [Test]
        public void Chart_WithBasicPlotOptions()
        {
            var actual = new HighchartsChart("myChart")
                            .Options(x => {
                                x.Line.ShowDataLabels().HideInLegend().Color("#00FF00");
                            }).ToHtmlString();


            var expected = MvcHtmlString.Create(@"<div id=""myChart""></div>
                                                  <script type=""text/javascript"">
                                                  $(document).ready(function () {
                                                      hCharts['myChart'] = new Highcharts.Chart({
                                                          chart: {
                                                            renderTo: 'myChart'
                                                          },
                                                          plotOptions: {
                                                            line: {
                                                                showInLegend: false,
                                                                dataLabels: {
                                                                    enabled: true
                                                                },
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
                            .Options(x => {
                                x.Line.HideInLegend();
                                x.Column.ShowDataLabels();
                            }).ToHtmlString();

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
                            .Options(x => {
                                x.Line.HideInLegend();
                                x.Series.HideInLegend();
                                x.Column.HideInLegend();
                            }).ToHtmlString();


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
                                                                showInLegend: false
                                                            },
                                                            series: {
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
