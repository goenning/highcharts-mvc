using System;
using System.Linq.Expressions;
using Highcharts.Mvc.Json;
using Highcharts.Mvc.Models;

namespace Highcharts.Mvc
{
    public class CreditsConfigurator : JsonConfigurator
    {
        private readonly Credits credits;
        internal CreditsConfigurator(Credits credits)
        {
            this.credits = credits;
        }

        public CreditsConfigurator Hide()
        {
            this.credits.Enabled = false;
            return this;
        }

        public CreditsConfigurator Text(string text)
        {
            this.credits.Text = text;
            return this;
        }

        public CreditsConfigurator Url(string url)
        {
            this.credits.Href = url;
            return this;
        }

        //TODO: Fix this
        public CreditsConfigurator Position(Action<FullPositionConfigurator> expression)
        {
            return this;
        }
    }
}
