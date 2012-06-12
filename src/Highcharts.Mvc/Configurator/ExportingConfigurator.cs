using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc
{
    public class ExportingConfigurator : JsonConfigurator
    {
        public ExportingConfigurator() : base("exporting")
        {

        }

        public ExportingConfigurator Buttons(Expression<Func<ExportingButtonsConfigurator, JsonConfigurator>> expression)
        {
            this.Set(expression.ToJson());
            return this;
        }
    }
}
