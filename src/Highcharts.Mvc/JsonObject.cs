using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public class JsonObject
    {
        private string key;
        private string value;

        public JsonObject()
            : this(null)
        {

        }

        public JsonObject(string key)
        {
            this.key = key;
            this.allOptions = new Dictionary<string, JsonObject>();
        }

        public JsonObject(string key, bool value)
            : this(key)
        {
            this.value = value ? "true" : "false";
        }

        public JsonObject(string key, int value)
            : this(key)
        {
            this.value = value.ToString();
        }

        public JsonObject(string key, float value)
            : this(key)
        {
            this.value = value.ToString();
        }

        public JsonObject(string key, decimal value)
            : this(key)
        {
            this.value = value.ToString();
        }

        public JsonObject(string key, double value)
            : this(key)
        {
            this.value = value.ToString();
        }

        public JsonObject(string key, string value)
            : this(key)
        {
            this.value = string.Concat("'", value.ToString(), "'");
        }

        public JsonObject(string key, params string[] values)
            : this(key)
        {
            string htmlValues = string.Join("','", values.Select(x => x.ToString()));
            htmlValues = string.Concat("['", htmlValues, "']");
            this.value = htmlValues;
        }

        public JsonObject(string key, params object[] values)
            : this(key)
        {
            string htmlValues = string.Join(",", values.Select(x => x.ToString()));
            htmlValues = string.Concat("[", htmlValues ,"]");
            this.value = htmlValues;
        }

        public JsonObject(string key, params JsonObject[] values)
            : this(key)
        {
            string htmlValues = string.Join(",", values.Select(x => x.ToString()));
            this.value = string.Concat("{ ", htmlValues, " }");
        }

        public override string ToString()
        {
            if (this.key == null && this.value == null && this.allOptions.Count == 0)
                return string.Empty;

            string outputKey = this.key == null ? string.Empty : string.Concat(this.key, ":");
            if (this.allOptions.Count > 0)
            {
                string childValues = string.Join(",", this.allOptions.Select(x => x.Value.ToString()));
                if (this.key != null)
                    childValues = string.Concat("{ ", childValues, " }");

                return string.Format("{0} {1}", outputKey, childValues);
            }
            else if (this.value != null)
            {
                return string.Format("{0} {1}", outputKey, this.value);
            }
            else
            {
                return string.Format("{0} {{ }}", outputKey);
            }
        }

        private Dictionary<string, JsonObject> allOptions;
        public void Set(JsonObject obj)
        {
            if (allOptions.ContainsKey(obj.key))
                allOptions[obj.key] = obj;
            else
                this.allOptions.Add(obj.key, obj);
        }
    }

}
