using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web.Mvc;
using System.Linq.Expressions;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class LegendChartTest : ConfiguratorTest<LegendConfigurator>
    {
        [Test]
        public void EmptyLegendSetup()
        {
            var actual = this.Configure(x => x);
            var expected = @"legend: { }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BasicLegendSetup()
        {
            var actual = this.Configure(x => x.Left().Top().Floating().X(20).Y(10));
            var expected = @"legend: {
                                align: 'left',
                                verticalAlign: 'top',
                                floating: true,
                                x: 20,
                                y: 10 
                            }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void OverrideLegendAlignSetup()
        {
            var actual = this.Configure(x => x.Left().Right().Top().Bottom());
            var expected = @"legend: {
                                align: 'right',
                                verticalAlign: 'bottom'
                            }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void LegendBorderSetup()
        {
            var actual = this.Configure(x => x.Middle().Border("#FFF", 10, 5));
            var expected = @"legend: {
                               verticalAlign: 'middle',
                               borderColor: '#FFF',
                               borderRadius: 10,
                               borderWidth : 5
                           }";

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
