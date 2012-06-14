using System;
using System.Linq.Expressions;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc
{
    public class LegendConfigurator : JsonConfigurator
    {
        public LegendConfigurator()
            : base("legend")
        {

        }

        public LegendConfigurator Floating()
        {
            this.Set(new JsonAttribute("floating", true));
            return this;
        }

        public LegendConfigurator Border(string color, int radius, int width)
        {
            this.Set(new JsonAttribute("borderColor", color));
            this.Set(new JsonAttribute("borderRadius", radius));
            this.Set(new JsonAttribute("borderWidth", width));
            return this;
        }

        public LegendConfigurator Position(Expression<Func<FullPositionConfigurator, JsonConfigurator>> expression)
        {
            this.SetOptions(expression.ToJson());
            return this;
        }

        public LegendConfigurator BackgroundColor(string color)
        {
            this.Set(new JsonAttribute("backgroundColor", color));
            return this;
        }

        public LegendConfigurator Hide()
        {
            this.Set(new JsonAttribute("enabled", false));
            return this;
        }

        public LegendConfigurator ItemWidth(int width)
        {
            this.Set(new JsonAttribute("itemWidth", width));
            return this;
        }

        public LegendConfigurator LineHeight(int height)
        {
            this.Set(new JsonAttribute("lineHeight", height));
            return this;
        }

        public LegendConfigurator Margin(int margin)
        {
            this.Set(new JsonAttribute("margin", margin));
            return this;
        }

        public LegendConfigurator Reverse()
        {
            this.Set(new JsonAttribute("reversed", true));
            return this;
        }

        public LegendConfigurator ShowShadow()
        {
            this.Set(new JsonAttribute("shadow", true));
            return this;
        }

        public LegendConfigurator SymbolPadding(int padding)
        {
            this.Set(new JsonAttribute("symbolPadding", padding));
            return this;
        }

        public LegendConfigurator SymbolWidth(int width)
        {
            this.Set(new JsonAttribute("symbolWidth", width));
            return this;
        }

        public LegendConfigurator Width(int width)
        {
            this.Set(new JsonAttribute("width", width));
            return this;
        }

        public LegendConfigurator Layout(LegendLayout layout)
        {
            this.Set(new JsonAttribute("layout", layout));
            return this;
        }

        public LegendConfigurator LabelFormatter(string function)
        {
            this.Set(new JsonAttribute("labelFormatter", new JsonFunction(function)));
            return this;
        }
    }
}
