using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Globalization;
using NUnit.Framework;

namespace Highcharts.Mvc.Test
{
    public static class HtmlAssert
    {
        public static void AreEqual(IHtmlString expected, IHtmlString actual)
        {
            string expectedString = expected.ToString().Replace(" ", "").Replace("\r\n", "").Replace("\n", "").Replace("\t", "");
            string actualString = actual.ToString().Replace(" ", "").Replace("\r\n", "").Replace("\n", "").Replace("\t", "");
            Assert.AreEqual(expectedString, actualString);
        }

        public static void AreEqual(string expected, string actual)
        {
            string expectedString = expected.ToString().Replace(" ", "").Replace("\r\n", "").Replace("\n", "").Replace("\t", "");
            string actualString = actual.ToString().Replace(" ", "").Replace("\r\n", "").Replace("\n", "").Replace("\t", "");
            Assert.AreEqual(expectedString, actualString);
        }
    }
}
