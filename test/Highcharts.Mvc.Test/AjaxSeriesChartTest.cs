using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web.Mvc;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class AjaxSeriesChartTest
    {
        [Test]
        public void BasicSetup_WithAjaxSource()
        {
            HighchartsChart chart = new HighchartsChart("myChart")
                                    .Series(AjaxConfig.LoadFrom("/Ajax/LoadData"));

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

                                                        $.getJSON('/Ajax/LoadData', function(data) {
                                                            myChart.clearSeries();

                                                            $.each(data, function (key, value) {
                                                                myChart.addSeries({
                                                                    name: value.Name,
                                                                    data: value.Values
                                                                }); ;
                                                            });
                                                        });
                                                  });
                                                  </script>");

            HtmlAssert.AreEqual(expected, actual);
        }
        [Test]
        public void BasicSetup_WithAjaxSource_AndInternal()
        {
            HighchartsChart chart = new HighchartsChart("myChart")
                                    .Series(AjaxConfig.LoadFrom("/Ajax/LoadData").Reload(1000));

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
                                                        
                                                        setIntervalAndExecute(function() {
                                                            $.getJSON('/Ajax/LoadData', function(data) {
                                                                myChart.clearSeries();

                                                                $.each(data, function (key, value) {
                                                                    myChart.addSeries({
                                                                        name: value.Name,
                                                                        data: value.Values
                                                                    }); ;
                                                                });
                                                            });
                                                        }, 1000);
                                                  });
                                                  </script>");

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
