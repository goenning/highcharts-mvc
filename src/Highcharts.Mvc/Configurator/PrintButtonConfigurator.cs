using Highcharts.Mvc.Json;

namespace Highcharts.Mvc
{
    public class PrintButtonConfigurator : JsonConfigurator
    {
        public PrintButtonConfigurator() 
            : base("printButton")
        {
            
        }

        public PrintButtonConfigurator Hide()
        {
            this.Set(new JsonAttribute("enabled", false));
            return this;
        }
    }
}
