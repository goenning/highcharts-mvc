using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web.Mvc;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class HighchartSetUpTest
    {
        [Test]
        public void BasicSetUp()
        {
            HighchartsSetUp setup = new HighchartsSetUp("myChart");
            var actual = setup.ToHtmlString();
            var expected = MvcHtmlString.Create(@"var myChart;
                                                  $(document).ready(function () {
                                                      myChart = new Highcharts.Chart({
                                                          chart: {
                                                            renderTo: 'myChart'
                                                          }
                                                      });
                                                  });");

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
