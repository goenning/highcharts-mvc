
namespace Highcharts.Mvc.Json
{
    public class JsonNullAttribute : JsonAttribute
    {
        public JsonNullAttribute(string key)
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
