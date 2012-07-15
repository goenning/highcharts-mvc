using System;
using System.Linq.Expressions;
using Highcharts.Mvc.Models;

namespace Highcharts.Mvc
{
    public class ExportingButtonsConfigurator : JsonConfigurator
    {
        private readonly ExportingButtons exportingButtons;
        internal ExportingButtonsConfigurator(ExportingButtons exportingButtons)
        {
            this.exportingButtons = exportingButtons;
        }

        public ExportingButtonsConfigurator PrintButton(Expression<Func<ButtonConfigurator, ButtonConfigurator>> expression)
        {
            expression.Compile().Invoke(new ButtonConfigurator(this.exportingButtons.PrintButton));
            return this;
        }

        public ExportingButtonsConfigurator ExportButton(Expression<Func<ButtonConfigurator, ButtonConfigurator>> expression)
        {
            expression.Compile().Invoke(new ButtonConfigurator(this.exportingButtons.ExportButton));
            return this;
        }
    }
}
