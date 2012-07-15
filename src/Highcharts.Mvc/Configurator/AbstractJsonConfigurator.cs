using Highcharts.Mvc.Json;

namespace Highcharts.Mvc
{
    public abstract class JsonConfigurator
    {
        private JsonAttribute topAttribute;
        private JsonAttributeCollection attributes;

        public JsonConfigurator()
            : this(null)
        {

        }

        public JsonConfigurator(string name)
        {
            this.topAttribute = new JsonAttribute(name);
            this.attributes = new JsonAttributeCollection();
        }

        public void Set(JsonAttribute attr)
        {
            this.attributes.Set(attr);
        }

        public void Set(JsonAttributeCollection attributes)
        {
            this.attributes = attributes;
        }

        internal JsonAttribute ToJson()
        {
            this.topAttribute.Set(attributes);
            return this.topAttribute;
        }

        internal JsonAttributeCollection ToAttributes()
        {
            return this.attributes;
        }
    }
}
