using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Highcharts.Mvc
{
    public class CreditsConfigurator : AbstractJsonConfigurator
    {
        public CreditsConfigurator()
            : base("credits")
        {

        }

        public CreditsConfigurator Hide()
        {
            this.Set(new JsonObject("enabled", false));
            return this;
        }

        public CreditsConfigurator Text(string text)
        {
            this.Set(new JsonObject("text", text));
            return this;
        }

        public CreditsConfigurator Url(string url)
        {
            this.Set(new JsonObject("href", url));
            return this;
        }

        public CreditsConfigurator Position(Expression<Func<PositionConfigurator, IJsonConfigurator>> expression)
        {
            this.Set(expression.ToJson());
            return this;
        }
    }
}
