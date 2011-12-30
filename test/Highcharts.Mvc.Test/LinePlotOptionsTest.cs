using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web.Mvc;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class LinePlotOptionsTest
    {
        [Test]
        public void EmptyOptions()
        {
            var options = PlotOptions.Line;
            var actual = options.ToString();
            var expected = @"line: { }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void OptionsWithDataLabels() 
        {
            var options = PlotOptions.Line.ShowDataLabels();
            var actual = options.ToString();
            var expected = @"line: {
                                dataLabels: {
                                    enabled: true
                                }
                             }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void OptionsWithDataLabels_AndMouseTrackingOff()
        {
            var options = PlotOptions.Line.ShowDataLabels().DisableMouseTracking();
            var actual = options.ToString();
            var expected = @"line: {
                                dataLabels: {
                                    enabled: true
                                },
                                enableMouseTracking: false
                             }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void OptionsWithDataLabels_AndMouseTrackingOff_AndHideInLegend()
        {
            var options = PlotOptions.Line.ShowDataLabels().DisableMouseTracking().HideInLegend();
            var actual = options.ToString();
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
