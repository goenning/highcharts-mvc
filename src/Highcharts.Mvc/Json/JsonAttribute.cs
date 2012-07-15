using System;
using System.Collections.Generic;
using System.Linq;

namespace Highcharts.Mvc.Json
{
    public class JsonAttribute : IEquatable<JsonAttribute>
    {
        public string Key { get; protected set; }
        public JsonObject Value { get; protected set; }

        public JsonAttribute()
        {
            this.Key = null;
            this.Value = new JsonObject();
        }

        public JsonAttribute(string key)
        {
            this.Key = key;
            this.Value = new JsonObject();
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
            this.Value = new JsonObject(attrs);
        }

        public JsonAttribute(string key, params JsonObject[] objs)
            : this(key)
        {
            this.Value = new JsonObject(objs);
        }

        public override string ToString()
        {
            if (this.Key == null && this.Value.ToString() == "{ }")
                return string.Empty;

            string outputKey = this.Key == null ? string.Empty : string.Concat(this.Key, ":");
            if (this.Value != null)
            {
                return string.Format("{0} {1}", outputKey, this.Value);
            }
            else
            {
                return string.Format("{0} {{ }}", outputKey);
            }
        }

        public void Set(JsonAttribute attr)
        {
            this.Value.Set(attr);
        }

        public void Set(JsonAttributeCollection attributes)
        {
            foreach (JsonAttribute attr in attributes)
                this.Value.Set(attr);
        }

        public bool Equals(JsonAttribute other)
        {
            return other.Key == this.Key;
        }
    }

}
