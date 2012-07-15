
using System.Globalization;
using System;
namespace Highcharts.Mvc.Json
{
    public class JsonObject
    {
        private static CultureInfo enUS = new CultureInfo("en-US");

        private JsonAttributeCollection attributes = new JsonAttributeCollection();
        private string result;

        public JsonObject()
        {
            this.result = "{ }";
        }

        public JsonObject(JsonAttribute[] attributes)
        {
            foreach (var attr in attributes)
                this.attributes.Set(attr);
        }

        public JsonObject(Array values)
        {
            string[] formattedValues = new string[values.Length];
            for (int i = 0; i < values.Length; i++)
                formattedValues[i] = this.Format(values.GetValue(i));

            this.result = string.Format("[{0}]", string.Join(",", formattedValues));
        }

        private string Format(object value)
        {
            if (value is string)
                return string.Format("'{0}'", value);

            if (value is bool)
                return Convert.ToBoolean(value) ? "true" : "false";

            if (value is float)
                return Convert.ToSingle(value).ToString(enUS.NumberFormat);

            if (value is decimal)
                return Convert.ToDecimal(value).ToString(enUS.NumberFormat);

            if (value is double)
                return Convert.ToDouble(value).ToString(enUS.NumberFormat);

            return value.ToString();
        }

        public JsonObject(bool value)
        {
            this.result = Format(value);
        }

        public JsonObject(int value)
        {
            this.result = Format(value);
        }

        public JsonObject(string value)
        {
            this.result = Format(value);
        }

        public JsonObject(float value)
        {
            this.result = Format(value);
        }

        public JsonObject(decimal value)
        {
            this.result = Format(value);
        }

        public JsonObject(double value)
        {
            this.result = Format(value);
        }

        public JsonObject(JsonFunction function)
        {
            this.result = function.ToString();
        }

        public void Set(JsonAttribute attr)
        {
            this.attributes.Set(attr);
        }

        public override string ToString()
        {
            return ToJson();
        }

        public virtual string ToJson()
        {
            if (this.attributes.Count > 0)
                return string.Format("{{ {0} }}", this.attributes.ToString());

            return result;
        }
    }
}
