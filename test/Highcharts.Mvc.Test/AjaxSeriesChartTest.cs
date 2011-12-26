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
                                                        
                                                        postChartAjax(myChart, '/Ajax/LoadData');
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
                                                        
                                                        postChartAjax(myChart, '/Ajax/LoadData', 1000);
                                                  });
                                                  </script>");

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BasicSetup_WithAjaxSource_AndGetMethod()
        {
            HighchartsChart chart = new HighchartsChart("myChart")
                                    .Series(AjaxConfig.LoadFrom("/Ajax/LoadData").AsGet());

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
                                                        
                                                        getChartAjax(myChart, '/Ajax/LoadData');
                                                  });
                                                  </script>");

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
