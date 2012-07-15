using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Highcharts.Mvc.Json
{
    public class JsonAttributeCollection : IEnumerable<JsonAttribute>
    {
        private IList<JsonAttribute> attributes;

        public JsonAttributeCollection()
        {
            this.attributes = new List<JsonAttribute>();
        }

        public JsonAttribute this[int idx]
        {
            get { return this.attributes[idx]; }
        }

        public void Set(JsonAttribute attr)
        {
            if (attr == null)
                return;

            int idx = attributes.IndexOf(attr);
            if (idx >= 0)
                attributes[idx] = attr;
            else
                this.attributes.Add(attr);
        }

        public int Count
        {
            get { return this.attributes.Count; }
        }

        public override string ToString()
        {
            return string.Join(", ", this.attributes.Select(x => x.ToString()));
        }

        public IEnumerator<JsonAttribute> GetEnumerator()
        {
            return this.attributes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.attributes.GetEnumerator();
        }
    }
}
