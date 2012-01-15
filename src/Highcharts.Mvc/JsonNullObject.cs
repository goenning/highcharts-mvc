using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public class JsonNullObject : JsonObject
    {
        public JsonNullObject(string key)
            : base(key)
        {
            this.Value = null;
        }

        public override string ToString()
        {
            return string.Format("{0}: null", this.Key);
        }
    }
}
