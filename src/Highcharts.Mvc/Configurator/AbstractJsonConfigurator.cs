using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public abstract class AbstractJsonConfigurator : IJsonConfigurator
    {
        private JsonObject jsonConfig;
        public AbstractJsonConfigurator(string name)
        {
            this.jsonConfig = new JsonObject(name);
        }

        protected void Set(JsonObject json)
        {
            this.jsonConfig.Set(json);
        }

        public JsonObject ToJson()
        {
            return this.jsonConfig;
        }
    }
}
