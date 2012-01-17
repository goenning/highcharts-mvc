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
            HtmlAssert.AreEqual(expected.ToString(), actual.ToString());
        }


        public static void AreNotEqual(IHtmlString expected, IHtmlString actual)
        {
            HtmlAssert.AreNotEqual(expected.ToString(), actual.ToString());
        }

        public static void AreEqual(string expected, string actual)
        {
            string expectedString = FormatString(expected);
            string actualString = FormatString(actual);
            Assert.AreEqual(expectedString, actualString);
        }

        public static void AreNotEqual(string expected, string actual)
        {
            string expectedString = FormatString(expected);
            string actualString = FormatString(actual);
            Assert.AreNotEqual(expectedString, actualString);
        }

        private static string FormatString(string value)
        {
            return value.Replace(" ", "").Replace("\r\n", "").Replace("\n", "").Replace("\t", "");
        }
    }
}
