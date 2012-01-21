using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc.Json
{
    public class JsonAttribute
    {
        protected string Key { get; set; }
        protected string Value { get; set; }

        public JsonAttribute()
            : this(null)
        {

        }

        public JsonAttribute(string key)
        {
            this.Key = key;
            this.allOptions = new Dictionary<string, JsonAttribute>();
        }

        public JsonAttribute(string key, bool value)
            : this(key)
        {
            this.Value = value ? "true" : "false";
        }

        public JsonAttribute(string key, int value)
            : this(key)
        {
            this.Value = value.ToString();
        }

        public JsonAttribute(string key, float value)
            : this(key)
        {
            this.Value = value.ToString();
        }

        public JsonAttribute(string key, decimal value)
            : this(key)
        {
            this.Value = value.ToString();
        }

        public JsonAttribute(string key, double value)
            : this(key)
        {
            this.Value = value.ToString();
        }

        public JsonAttribute(string key, string value)
            : this(key)
        {
            this.Value = string.Concat("'", value.ToString(), "'");
        }

        public JsonAttribute(string key, Enum value)
            : this(key, value.ToString().ToLower())
        {

        }

        public JsonAttribute(string key, params string[] values)
            : this(key)
        {
            string htmlValues = string.Join("','", values.Select(x => x.ToString()));
            htmlValues = string.Concat("['", htmlValues, "']");
            this.Value = htmlValues;
        }

        public JsonAttribute(string key, Array values)
            : this(key)
        {
            string[] strValues = new string[values.Length];
            for (int i = 0; i < values.Length; i++)
                strValues[i] = values.GetValue(i).ToString();

            string htmlValues = string.Join(",", strValues);
            htmlValues = string.Concat("[", htmlValues, "]");
            this.Value = htmlValues;
        }

        public JsonAttribute(string key, params JsonAttribute[] values)
            : this(key)
        {
            string htmlValues = string.Join(",", values.Select(x => x.ToString()));
            this.Value = string.Concat("{ ", htmlValues, " }");
        }

        public JsonAttribute(string key, params JsonObject[] objs)
            : this(key)
        {
            string htmlValues = string.Join(",", objs.Select(x => x.ToJson()));
            this.Value = string.Concat("[ ", htmlValues, " ]");
        }

        public override string ToString()
        {
            if (this.Key == null && this.Value == null && this.allOptions.Count == 0)
                return string.Empty;

            string outputKey = this.Key == null ? string.Empty : string.Concat(this.Key, ":");
            if (this.allOptions.Count > 0)
            {
                string childValues = string.Join(",", this.allOptions.Select(x => x.Value.ToString()));
                if (this.Key != null)
                    childValues = string.Concat("{ ", childValues, " }");

                return string.Format("{0} {1}", outputKey, childValues);
            }
            else if (this.Value != null)
            {
                return string.Format("{0} {1}", outputKey, this.Value);
            }
            else
            {
                return string.Format("{0} {{ }}", outputKey);
            }
        }

        private Dictionary<string, JsonAttribute> allOptions;
        public void Set(JsonAttribute obj)
        {
            if (string.IsNullOrEmpty(obj.Key))
                return;

            if (allOptions.ContainsKey(obj.Key))
                allOptions[obj.Key] = obj;
            else
                this.allOptions.Add(obj.Key, obj);
        }

        public void SetOptions(JsonAttribute json)
        {
            foreach (var opt in json.allOptions)
                this.allOptions.Add(opt.Key, opt.Value);
        }
    }

}
