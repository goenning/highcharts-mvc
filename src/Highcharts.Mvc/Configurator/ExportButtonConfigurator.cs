using Highcharts.Mvc.Json;

namespace Highcharts.Mvc
{
    public class ExportButtonConfigurator : JsonConfigurator
    {
        public ExportButtonConfigurator() : base("exportButton")
        {
            
        }

        public ExportButtonConfigurator Hide()
        {
            this.Set(new JsonAttribute("enabled", false));
            return this;
        }
    }
}
