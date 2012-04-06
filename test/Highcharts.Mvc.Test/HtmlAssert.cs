using System.Web;
using NUnit.Framework;

namespace Highcharts.Mvc.Test
{
    public static class HtmlAssert
    {
        public static void AreEqual(IHtmlString expected, IHtmlString actual)
        {
            HtmlAssert.AreEqual(expected.ToString(), actual.ToString());
        }

        public static void AreEqual(string expected, string actual)
        {
            string expectedString = FormatString(expected);
            string actualString = FormatString(actual);
            Assert.AreEqual(expectedString, actualString);
        }

        private static string FormatString(string value)
        {
            return value.Replace(" ", "").Replace("\r\n", "").Replace("\n", "").Replace("\t", "");
        }
    }
}
