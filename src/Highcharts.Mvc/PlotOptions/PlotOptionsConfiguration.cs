using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

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
            return this.Set(new JsonObject("id", id));
        }

        public T HideInLegend()
        {
            return this.Set(new JsonObject("showInLegend", false));
        }

        public T ShowDataLabels()
        {
            return this.Set(new JsonObject("dataLabels",
                new JsonObject("enabled", true)
            ));
        }

        public T ZIndex(int index)
        {
            return this.Set(new JsonObject("zIndex", index));
        }

        public T HideSeries()
        {
            return this.Set(new JsonObject("visible", false));
        }

        public T DisableMouseTracking()
        {
            return this.Set(new JsonObject("enableMouseTracking", false));
        }

        public T Color(string color)
        {
            return this.Set(new JsonObject("color", color));
        }

        public T DisableStickyTracking()
        {
            return this.Set(new JsonObject("stickyTracking", false));
        }

        public T AllowPointSelect()
        {
            return this.Set(new JsonObject("allowPointSelect", true));
        }

        public T NoAnimation()
        {
            return this.Set(new JsonObject("animation", false));
        }

        public T Animation(Expression<Func<AnimationConfigurator, IJsonConfigurator>> expression)
        {
            return this.Set(expression.ToJson());
        }

        public T ConnectNulls()
        {
            return this.Set(new JsonObject("connectNulls", true));
        }

        public T Cursor(ChartCursor cursor)
        {
            return this.Set(new JsonObject("cursor", cursor));
        }

        public T DashStyle(ChartDashStyle style)
        {
            return this.Set(new JsonObject("dashStyle", style));
        }

        public T LineWidth(int pixel)
        {
            return this.Set(new JsonObject("lineWidth", pixel));
        }
        
        public T Selected()
        {
            return this.Set(new JsonObject("selected", true));
        }

        public T HideShadow()
        {
            return this.Set(new JsonObject("shadow", false));
        }

        public T ShowCheckbox()
        {
            return this.Set(new JsonObject("showCheckbox", true));
        }

        public T Stacking(ChartStacking stacking)
        {
            if (ChartStacking.Disabled.Equals(stacking))
                return this.Set(new JsonNullObject("stacking"));

            return this.Set(new JsonObject("stacking", stacking));
        }

        protected new T Set(JsonObject json)
        {
            base.Set(json);
            return this.options;
        }
    }

    public abstract class PlotOptionsConfiguration : AbstractJsonConfigurator
    {
        public PlotOptionsConfiguration(string name)
            : base(name)
        {

        }

        public override string ToString()
        {
            return this.ToJson().ToString();
        }
    }
}
