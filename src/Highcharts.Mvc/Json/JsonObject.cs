using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc.Json
{
    public class JsonObject
    {
        private JsonAttribute attribute;
        public JsonObject()
        {
            this.attribute = new JsonAttribute();
        }

        public override string ToString()
        {
            return string.Format("{{ {0} }}", this.attribute.ToString());
        }

        public void Add(JsonAttribute attr)
        {
            this.attribute.Set(attr);
        }
    }
}
