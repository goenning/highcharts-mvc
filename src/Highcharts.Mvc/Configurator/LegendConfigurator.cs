using System;
using System.Linq.Expressions;
using Highcharts.Mvc.Json;
using Highcharts.Mvc.Models;

namespace Highcharts.Mvc
{
    public class LegendConfigurator : JsonConfigurator
    {
        private readonly Legend legend;
        internal LegendConfigurator(Legend legend)
        {
            this.legend = legend;
        }

        public LegendConfigurator Floating()
        {
            this.legend.Floating = true;
            return this;
        }

        public LegendConfigurator Border(string color, int radius, int width)
        {
            this.legend.BorderColor = color;
            this.legend.BorderRadius = radius;
            this.legend.BorderWidth = width;
            return this;
        }

        public LegendConfigurator Position(Action<FullPositionConfigurator> action)
        {
            action.Invoke(new FullPositionConfigurator(this.legend.Position));
            return this;
        }

        public LegendConfigurator BackgroundColor(string color)
        {
            this.legend.BackgroundColor = color;
            return this;
        }

        public LegendConfigurator Hide()
        {
            this.legend.Enabled = false;
            return this;
        }

        public LegendConfigurator ItemWidth(int width)
        {
            this.legend.ItemWidth = width;
            return this;
        }

        public LegendConfigurator LineHeight(int height)
        {
            this.legend.LineHeight = height;
            return this;
        }

        public LegendConfigurator Margin(int margin)
        {
            this.legend.Margin = margin;
            return this;
        }

        public LegendConfigurator Reverse()
        {
            this.legend.Reversed = true;
            return this;
        }

        public LegendConfigurator ShowShadow()
        {
            this.legend.Shadow = true;
            return this;
        }

        public LegendConfigurator SymbolPadding(int padding)
        {
            this.legend.SymbolPadding = padding;
            return this;
        }

        public LegendConfigurator SymbolWidth(int width)
        {
            this.legend.SymbolWidth = width;
            return this;
        }

        public LegendConfigurator Width(int width)
        {
            this.legend.Width = width;
            return this;
        }

        public LegendConfigurator Layout(LegendLayout layout)
        {
            this.legend.Layout = layout;
            return this;
        }

        public LegendConfigurator LabelFormatter(string function)
        {
            this.legend.LabelFormatter = new JsonFunction(function);
            return this;
        }
    }
}
