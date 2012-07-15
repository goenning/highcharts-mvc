using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Text;
using Highcharts.Mvc.Models;

namespace Highcharts.Mvc.Json
{
    public static class JsonConverter
    {
        public static string SerializeObject(object value)
        {
            if (value == null)
                return string.Empty;

            if (value is ICustomJsonConverter)
                return (value as ICustomJsonConverter).ToJson();

            if (value is string)
                return string.Format("'{0}'", value);

            if (value is bool)
                return Convert.ToBoolean(value) ? "true" : "false";

            if (value is Enum)
                return string.Format("'{0}'", value.ToString().ToLower());

            if (value is IEnumerable)
                return SerializeCollection(value as IEnumerable);

            if (!value.GetType().IsValueType)
                return SerializeComplexType(value);

            return value.ToString();
        }

        private static string SerializeCollection(IEnumerable values)
        {
            StringBuilder json = new StringBuilder();
            json.Append("[");

            bool first = true;
            foreach (object value in values)
            {
                if (!first)
                    json.Append(",");
                else
                    first = false;

                json.Append(SerializeObject(value));
            }

            json.Append("]");
            return json.ToString();
        }

        private static string SerializeComplexType(object value)
        {
            StringBuilder json = new StringBuilder();
            json.Append("{");
            json.Append(JsonConverter.SerializeComplexTypeProperties(value));
            json.Append("}");
            return json.ToString();
        }

        private static string SerializeComplexTypeProperties(object value)
        {
            Type type = value.GetType();
            StringBuilder json = new StringBuilder();

            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            bool first = true;
            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo property = properties[i];
                object propertyValue = property.GetValue(value, null);
                if (IsConsideredNull(propertyValue))
                    continue;

                if (!first)
                    json.Append(",");
                else
                    first = false;

                if (property.ContainsAttribute<MergePropertiesAttribute>())
                {
                    json.Append(JsonConverter.SerializeComplexTypeProperties(propertyValue));
                }
                else
                {
                    string attributeName = StringUtils.ToCamelCase(property.Name);
                    json.AppendFormat("{0}:{1}", attributeName, JsonConverter.SerializeObject(propertyValue));
                }
            }

            return json.ToString();
        }

        private static bool IsConsideredNull(object value)
        {
            if (value == null)
                return true;

            if (value is ICustomJsonConverter)
                return (value as ICustomJsonConverter).IsConsideredNull();

            if (value is IEnumerable)
                return !(value as IEnumerable).GetEnumerator().MoveNext();

            if (value.GetType().IsValueType || value is string)
                return false;

            return HasAnyNullProperty(value);
        }

        public static bool HasAnyNullProperty(object value)
        {
            var result = from p in value.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                         let propertyValue = p.GetValue(value, null)
                         where !IsConsideredNull(propertyValue)
                         select propertyValue;

            return result.Count() == 0;
        }
    }
}
