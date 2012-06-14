using System;
using System.Collections.Generic;
using System.Linq;

namespace Highcharts.Mvc.Json
{
    public class JsonAttribute
    {
        protected string Key { get; set; }
        protected JsonObject Value { get; set; }

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
            this.Value = new JsonObject(value);
        }

        public JsonAttribute(string key, int value)
            : this(key)
        {
            this.Value = new JsonObject(value);
        }

        public JsonAttribute(string key, double value)
            : this(key)
        {
            this.Value = new JsonObject(value);
        }

        public JsonAttribute(string key, JsonFunction value)
            : this(key)
        {
            this.Value = new JsonObject(value);
        }

        public JsonAttribute(string key, string value)
            : this(key)
        {
            this.Value = new JsonObject(value);
        }

        public JsonAttribute(string key, Enum value)
            : this(key, value.ToString().ToLower())
        {

        }

        public JsonAttribute(string key, Array values)
            : this(key)
        {
            this.Value = new JsonObject(values);
        }

        public JsonAttribute(string key, params JsonAttribute[] attrs)
            : this(key)
        {
            JsonObject obj = new JsonObject();
            foreach (JsonAttribute attr in attrs)
                obj.Add(attr);

            this.Value = obj;
        }

        public JsonAttribute(string key, params JsonObject[] objs)
            : this(key)
        {
            this.Value = new JsonObject(objs);
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
