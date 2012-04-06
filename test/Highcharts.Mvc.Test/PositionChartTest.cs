using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class PositionChartTest : ConfiguratorTest<PositionConfigurator>
    {
        [Test]
        public void EmptySetUp()
        {
            var actual = this.Configure(x => x);
            var expected = @"position: { }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BasicSetUp()
        {
            var actual = this.Configure(x => x.Center().X(20).Y(10));
            var expected = @"position: {
                                align: 'center',
                                x: 20,
                                y: 10
                            }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void OverrideSetUp()
        {
            var actual = this.Configure(x => x.Left().Right().X(20).Y(10).X(35).Y(15));
            var expected = @"position: {
                                align: 'right',
                                x: 35,
                                y: 15
                            }";

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
