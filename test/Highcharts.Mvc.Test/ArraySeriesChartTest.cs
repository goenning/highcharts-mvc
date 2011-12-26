using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web.Mvc;
using System.Diagnostics;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class ArraySeriesChartTest
    {
        [Test]
        public void BasicSetup_WithSeries()
        {
            HighchartsChart chart = new HighchartsChart("myChart")
                                    .Series(
                                        new Serie("Open", 10, 15, 61),
                                        new Serie("Closed", 461, 473, 985),
                                        new Serie("Pending", 722, 526, 224)
                                    );

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

                                                    myChart.addSeries({ name: 'Open', data: [10, 15, 61] });
                                                    myChart.addSeries({ name: 'Closed', data: [461, 473, 985] });
                                                    myChart.addSeries({ name: 'Pending', data: [722, 526, 224] });
                                                  });
                                                  </script>");

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
