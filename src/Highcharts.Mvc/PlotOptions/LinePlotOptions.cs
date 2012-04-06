using Highcharts.Mvc.Json;

namespace Highcharts.Mvc
{
    public class LinePlotOptions : PlotOptionsConfiguration<LinePlotOptions>
    {
        public LinePlotOptions()
            : base("line")
        {
            this.options = this;
        }

        public LinePlotOptions Step()
        {
            return this.Set(new JsonAttribute("step", true));
        }
    }
}

