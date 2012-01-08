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
        public void BasicSetUp_WithAjaxSource()
        {
            var chart = new HighchartsChart("myChart")
                            .Series(AjaxConfig.LoadFrom("/Ajax/LoadData"));

            var actual = chart.ToHtmlString();
            var expected = MvcHtmlString.Create(@"<div id=""myChart""></div>
                                                  <script type=""text/javascript"">
                                                  $(document).ready(function () {
                                                      hCharts['myChart'] = new Highcharts.Chart({
                                                            chart: {
                                                                renderTo: 'myChart'
                                                            }
                                                        });
                                                        
                                                        postChartAjax(hCharts['myChart'], '/Ajax/LoadData');
                                                  });
                                                  </script>");

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BasicSetUp_WithAjaxSource_AndInternal()
        {
            var chart = new HighchartsChart("myChart")
                            .Series(AjaxConfig.LoadFrom("/Ajax/LoadData").Reload(1000));

            var actual = chart.ToHtmlString();
            var expected = MvcHtmlString.Create(@"<div id=""myChart""></div>
                                                  <script type=""text/javascript"">
                                                  $(document).ready(function () {
                                                      hCharts['myChart'] = new Highcharts.Chart({
                                                            chart: {
                                                                renderTo: 'myChart'
                                                            }
                                                        });
                                                        
                                                        postChartAjax(hCharts['myChart'], '/Ajax/LoadData', 1000);
                                                  });
                                                  </script>");

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BasicSetUp_WithAjaxSource_AndGetMethod()
        {
            var chart = new HighchartsChart("myChart")
                            .Series(AjaxConfig.LoadFrom("/Ajax/LoadData").AsGet());

            var actual = chart.ToHtmlString();
            var expected = MvcHtmlString.Create(@"<div id=""myChart""></div>
                                                  <script type=""text/javascript"">
                                                  $(document).ready(function () {
                                                      hCharts['myChart'] = new Highcharts.Chart({
                                                            chart: {
                                                                renderTo: 'myChart'
                                                            }
                                                        });
                                                        
                                                        getChartAjax(hCharts['myChart'], '/Ajax/LoadData');
                                                  });
                                                  </script>");

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
