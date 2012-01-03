using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web.Mvc;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class LinePlotOptionsTest : ConfiguratorTest<LinePlotOptions>
    {
        [Test]
        public void EmptyLinePlotOptions()
        {
            var actual = this.Configure(x => x);
            var expected = @"line: { }";

            HtmlAssert.AreEqual(expected, actual);
        }
        [Test]
        public void BasicLinePlotOptionsSetup()
        {
            var actual = this.Configure(x => x.ShowDataLabels().DisableMouseTracking().HideInLegend());
            var expected = @"line: {
                                dataLabels: {
                                    enabled: true
                                },
                                enableMouseTracking: false,
                                showInLegend: false
                             }";

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
