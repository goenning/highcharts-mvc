using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc
{
    public class CreditsConfigurator : JsonConfigurator
    {
        public CreditsConfigurator()
            : base("credits")
        {

        }

        public CreditsConfigurator Hide()
        {
            this.Set(new JsonAttribute("enabled", false));
            return this;
        }

        public CreditsConfigurator Text(string text)
        {
            this.Set(new JsonAttribute("text", text));
            return this;
        }

        public CreditsConfigurator Url(string url)
        {
            this.Set(new JsonAttribute("href", url));
            return this;
        }

        public CreditsConfigurator Position(Expression<Func<PositionConfigurator, JsonConfigurator>> expression)
        {
            this.Set(expression.ToJson());
            return this;
        }
    }
}
