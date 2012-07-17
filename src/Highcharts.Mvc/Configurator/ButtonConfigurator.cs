using Highcharts.Mvc.Json;
using Highcharts.Mvc.Models;

namespace Highcharts.Mvc
{
    public class ButtonConfigurator
    {
        private readonly Button button;
        internal ButtonConfigurator(Button button)
        {
            this.button = button;
        }

        public ButtonConfigurator Hide()
        {
            this.button.Enabled = false;
            return this;
        }
    }
}
