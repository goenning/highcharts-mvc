using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web.Mvc;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class PieChartTest
    {
        [Test]
        public void BasicPieChartTest()
        {
            var chart = new HighchartsChart("myChart")
                            .WithSerieType(ChartSerieType.Pie)
                            .Series(
                                new PieSerie("Browser share", new PieData[] {
                                    new PieData("Firefox", 45.0f),
                                    new PieData("Chrome", 12.8f),
                                    new PieData("IE", 26.8f),
                                    new PieData("Safari", 8.5f),
                                    new PieData("Opera", 6.2f),
                                    new PieData("Others", 0.7f),
                                })
                            );
            var actual = chart.ToHtmlString();
            var expected = MvcHtmlString.Create(@"<div id=""myChart""></div>
                                                  <script type=""text/javascript"">
                                                  $(document).ready(function () {
                                                      hCharts['myChart'] = new Highcharts.Chart({
                                                          chart: {
                                                            renderTo: 'myChart',
			                                                type: 'pie'
                                                          },
                                                          series: [{
			                                                  name: 'Browser share',
			                                                  type: 'pie',
			                                                  data: [
				                                                  ['Firefox', 45],
				                                                  ['Chrome', 12.8],
				                                                  ['IE', 26.8],
				                                                  ['Safari', 8.5],
				                                                  ['Opera', 6.2],
				                                                  ['Others', 0.7]
			                                                  ]
		                                                  }]
                                                      });
                                                  });
                                                  </script>");

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
