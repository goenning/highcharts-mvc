
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

        public string ToJson()
        {
            return this.ToString();
        }

        public void Add(JsonAttribute attr)
        {
            this.attribute.Set(attr);
        }
    }
}
