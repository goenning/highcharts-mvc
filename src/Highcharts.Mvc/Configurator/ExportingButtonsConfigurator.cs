using System;
using System.Linq.Expressions;

namespace Highcharts.Mvc
{
    public class ExportingButtonsConfigurator : JsonConfigurator
    {
        public ExportingButtonsConfigurator()
            : base("buttons")
        {
            
        }

        public ExportingButtonsConfigurator PrintButton(Expression<Func<PrintButtonConfigurator, JsonConfigurator>> expression)
        {
            this.Set(expression.ToJson());
            return this;
        }

        public ExportingButtonsConfigurator ExportButton(Expression<Func<ExportButtonConfigurator, JsonConfigurator>> expression)
        {
            this.Set(expression.ToJson());
            return this;
        }
    }
}
