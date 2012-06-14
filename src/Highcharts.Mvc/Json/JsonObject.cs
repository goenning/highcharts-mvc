
using System.Globalization;
using System;
namespace Highcharts.Mvc.Json
{
    public class JsonObject
    {
        private static CultureInfo enUS = new CultureInfo("en-US");

        private JsonAttribute attribute;
        protected string result;

        public JsonObject()
        {
            this.attribute = new JsonAttribute();
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

        public void Add(JsonAttribute attr)
        {
            this.attribute.Set(attr);
        }

        public override string ToString()
        {
            return ToJson();
        }

        public virtual string ToJson()
        {
            if (this.attribute != null)
                return string.Format("{{ {0} }}", this.attribute.ToString());

            return result;
        }
    }
}
