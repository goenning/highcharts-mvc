using System.Globalization;

namespace Highcharts.Mvc.Json
{
    internal static class StringUtils
    {
        public static string ToCamelCase(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            if (!char.IsUpper(s[0]))
                return s;

            string camelCase = null;
            camelCase = char.ToLower(s[0], CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);

            if (s.Length > 1)
                camelCase += s.Substring(1);

            return camelCase;
        }
    }
}
