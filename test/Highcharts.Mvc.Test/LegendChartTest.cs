﻿using System;
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
        public void EmptyLegendSetUp()
        {
            var actual = this.Configure(x => x);
            var expected = @"legend: { }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BasicLegendSetUp()
        {
            var actual = this.Configure(x => x.Position(y => y.Left().Top().X(20).Y(10)).Floating());
            var expected = @"legend: {
                                align: 'left',
                                verticalAlign: 'top',
                                x: 20,
                                y: 10,
                                floating: true
                            }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void OverrideLegendAlignSetUp()
        {
            var actual = this.Configure(x => x.Position(y => y.Left().Right().Top().Bottom()));
            var expected = @"legend: {
                                align: 'right',
                                verticalAlign: 'bottom'
                            }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void LegendBorderSetUp()
        {
            var actual = this.Configure(x => x.Position(y => y.Middle()).Border("#FFF", 10, 5));
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