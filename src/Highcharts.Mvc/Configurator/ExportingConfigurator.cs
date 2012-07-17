using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Highcharts.Mvc.Json;
using Highcharts.Mvc.Models;

namespace Highcharts.Mvc
{
    public class ExportingConfigurator
    {
        private readonly Exporting exporting;
        internal ExportingConfigurator(Exporting exporting)
        {
            this.exporting = exporting;
        }

        public ExportingConfigurator Buttons(Expression<Func<ExportingButtonsConfigurator, ExportingButtonsConfigurator>> expression)
        {
            expression.Compile().Invoke(new ExportingButtonsConfigurator(this.exporting.Buttons));
            return this;
        }
    }
}
