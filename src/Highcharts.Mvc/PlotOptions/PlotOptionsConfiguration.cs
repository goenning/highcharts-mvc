using System;
using System.Linq.Expressions;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc
{
    public abstract class PlotOptionsConfiguration<T> : PlotOptionsConfiguration where T : new()
    {
        public PlotOptionsConfiguration(string name)
            : base(name)
        {
            
        }

        protected T options;

        public T Id(string id)
        {
            return this.Set(new JsonAttribute("id", id));
        }

        public T HideInLegend()
        {
            return this.Set(new JsonAttribute("showInLegend", false));
        }

        public T ShowDataLabels()
        {
            return this.Set(new JsonAttribute("dataLabels",
                new JsonAttribute("enabled", true)
            ));
        }

        public T ZIndex(int index)
        {
            return this.Set(new JsonAttribute("zIndex", index));
        }

        public T HideSeries()
        {
            return this.Set(new JsonAttribute("visible", false));
        }

        public T DisableMouseTracking()
        {
            return this.Set(new JsonAttribute("enableMouseTracking", false));
        }

        public T Color(string color)
        {
            return this.Set(new JsonAttribute("color", color));
        }

        public T DisableStickyTracking()
        {
            return this.Set(new JsonAttribute("stickyTracking", false));
        }

        public T AllowPointSelect()
        {
            return this.Set(new JsonAttribute("allowPointSelect", true));
        }

        public T NoAnimation()
        {
            return this.Set(new JsonAttribute("animation", false));
        }

        public T Animation(Expression<Func<AnimationConfigurator, JsonConfigurator>> expression)
        {
            return this.Set(expression.ToJson());
        }

        public T ConnectNulls()
        {
            return this.Set(new JsonAttribute("connectNulls", true));
        }

        public T Cursor(ChartCursor cursor)
        {
            return this.Set(new JsonAttribute("cursor", cursor));
        }

        public T DashStyle(ChartDashStyle style)
        {
            return this.Set(new JsonAttribute("dashStyle", style));
        }

        public T LineWidth(int pixel)
        {
            return this.Set(new JsonAttribute("lineWidth", pixel));
        }
        
        public T Selected()
        {
            return this.Set(new JsonAttribute("selected", true));
        }

        public T HideShadow()
        {
            return this.Set(new JsonAttribute("shadow", false));
        }

        public T ShowCheckbox()
        {
            return this.Set(new JsonAttribute("showCheckbox", true));
        }

        public T DataLabels(Expression<Func<DataLabelsConfigurator, JsonConfigurator>> expression)
        {
            return this.Set(expression.ToJson());
        }

        public T Events(Expression<Func<EventsConfigurator, JsonConfigurator>> expression)
        {
            return this.Set(expression.ToJson());
        }

        public T Stacking(ChartStacking stacking)
        {
            if (ChartStacking.Disabled.Equals(stacking))
                return this.Set(new JsonNullAttribute("stacking"));

            return this.Set(new JsonAttribute("stacking", stacking));
        }

        protected new T Set(JsonAttribute json)
        {
            base.Set(json);
            return this.options;
        }
    }

    public abstract class PlotOptionsConfiguration : JsonConfigurator
    {
        public PlotOptionsConfiguration(string name)
            : base(name)
        {

        }
    }
}
