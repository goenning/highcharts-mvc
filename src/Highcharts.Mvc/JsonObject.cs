using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public class JsonObject
    {
        protected string Key { get; set; }
        protected string Value { get; set; }

        public JsonObject()
            : this(null)
        {

        }

        public JsonObject(string key)
        {
            this.Key = key;
            this.allOptions = new Dictionary<string, JsonObject>();
        }

        public JsonObject(string key, bool value)
            : this(key)
        {
            this.Value = value ? "true" : "false";
        }

        public JsonObject(string key, int value)
            : this(key)
        {
            this.Value = value.ToString();
        }

        public JsonObject(string key, float value)
            : this(key)
        {
            this.Value = value.ToString();
        }

        public JsonObject(string key, decimal value)
            : this(key)
        {
            this.Value = value.ToString();
        }

        public JsonObject(string key, double value)
            : this(key)
        {
            this.Value = value.ToString();
        }

        public JsonObject(string key, string value)
            : this(key)
        {
            this.Value = string.Concat("'", value.ToString(), "'");
        }

        public JsonObject(string key, Enum value)
            : this(key, value.ToString().ToLower())
        {

        }

        public JsonObject(string key, params string[] values)
            : this(key)
        {
            string htmlValues = string.Join("','", values.Select(x => x.ToString()));
            htmlValues = string.Concat("['", htmlValues, "']");
            this.Value = htmlValues;
        }

        public JsonObject(string key, Array values)
            : this(key)
        {
            string[] strValues = new string[values.Length];
            for (int i = 0; i < values.Length; i++)
                strValues[i] = values.GetValue(i).ToString();

            string htmlValues = string.Join(",", strValues);
            htmlValues = string.Concat("[", htmlValues, "]");
            this.Value = htmlValues;
        }

        public JsonObject(string key, params JsonObject[] values)
            : this(key)
        {
            string htmlValues = string.Join(",", values.Select(x => x.ToString()));
            this.Value = string.Concat("{ ", htmlValues, " }");
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

        private Dictionary<string, JsonObject> allOptions;
        public void Set(JsonObject obj)
        {
            if (allOptions.ContainsKey(obj.Key))
                allOptions[obj.Key] = obj;
            else
                this.allOptions.Add(obj.Key, obj);
        }

        public void SetOptions(JsonObject json)
        {
            foreach (var opt in json.allOptions)
                this.allOptions.Add(opt.Key, opt.Value);
        }
    }

}
