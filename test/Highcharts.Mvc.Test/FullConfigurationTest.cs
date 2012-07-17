using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web.Mvc;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class FullConfigurationTest
    {
        [Test]
        public void FullSetUp()
        {
            HighchartsSetUp setup = new HighchartsSetUp("myChart")
                                        .WithSerieType(ChartSerieType.Line)
                                        .Title("The title")
                                        .Subtitle("This is the subtitle")
                                        .Settings(x => 
                                            x.BackgroundColor("#eee")
                                        )
                                        .AxisY(x =>
                                            x.Title("Months", y => 
                                                y.Align(AxisTitleAlignment.High)
                                            )
                                        )
                                        .AxisX(x =>
                                            x.Title("Months", y =>
                                                y.Rotation(180)
                                            )
                                        )
                                        .Credits(x => x.Hide())
                                        .Legend(x => x.Position(y => y.Center()))
                                        .Options(x =>
                                        {
                                            x.Series.NoAnimation();
                                        })
                                        .Series(
                                            new PieSerie("Tickets", new int[] { 2, 5 })
                                        )
                                        .Tooltip(x =>
                                            x.Crosshairs()
                                             .Formatter("return 'Hello'")
                                        );

            var actual = setup.ToHtmlString();
            var expected = MvcHtmlString.Create(@"$(document).ready(function () {
                                                      hCharts['myChart'] = new Highcharts.Chart({
                                                          chart: {
                                                            renderTo: 'myChart',
                                                            type: 'line',
                                                            backgroundColor: '#eee'
                                                          },
                                                          title: { text: 'The title' },
                                                          subtitle: { text: 'This is the subtitle' },
                                                          xAxis: { 
                                                            title: {
                                                                text: 'Months',
                                                                rotation: 180
                                                            }
                                                          },
                                                          yAxis: {
                                                            title: { 
                                                                text: 'Months',
                                                                align: 'high' 
                                                            }
                                                          },
                                                          plotOptions: {
                                                            series: { animation: false }
                                                          },
                                                          credits: { enabled: false },
                                                          tooltip: { 
                                                            formatter: function() { return 'Hello' }, 
                                                            crosshairs: true 
                                                          },
                                                          legend: { align: 'center' },
                                                          series: [
                                                            { name: 'Tickets', type: 'pie', data: [ 2, 5 ] }
                                                          ]
                                                      });
                                                  });");

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
