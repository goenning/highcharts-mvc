using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highcharts.Mvc.Models;
using System.Linq.Expressions;

namespace Highcharts.Mvc.Configurator.PlotOptions
{
    public abstract class CommonPlotOptionsConfigurator { }

    public abstract class CommonPlotOptionsConfigurator<T> : CommonPlotOptionsConfigurator where T : CommonPlotOptionsConfigurator
    {
        private readonly SeriesPlotOptions seriePlotOptions;
        private readonly T configurator;
        internal CommonPlotOptionsConfigurator(SeriesPlotOptions seriePlotOptions)
        {
            this.seriePlotOptions = seriePlotOptions;
            this.configurator = this as T;
        }

        public T Id(string id)
        {
            this.seriePlotOptions.Id = id;
            return this.configurator;
        }

        public T HideInLegend()
        {
            this.seriePlotOptions.ShowInLegend = false;
            return this.configurator;
        }

        public T ShowDataLabels()
        {
            this.seriePlotOptions.DataLabels.Enabled = true;
            return this.configurator;
        }

        public T ZIndex(int index)
        {
            this.seriePlotOptions.ZIndex = index;
            return this.configurator;
        }

        public T HideSeries()
        {
            this.seriePlotOptions.Visible = false;
            return this.configurator;
        }

        public T DisableMouseTracking()
        {
            this.seriePlotOptions.EnableMouseTracking = false;
            return this.configurator;
        }

        public T Color(string color)
        {
            this.seriePlotOptions.Color = color;
            return this.configurator;
        }

        public T DisableStickyTracking()
        {
            this.seriePlotOptions.StickyTracking = false;
            return this.configurator;
        }

        public T AllowPointSelect()
        {
            this.seriePlotOptions.AllowPointSelect = true;
            return this.configurator;
        }

        public T NoAnimation()
        {
            this.seriePlotOptions.Animation.Disable();
            return this.configurator;
        }

        public T Animation(Expression<Action<AnimationConfigurator>> expression)
        {
            expression.Compile().Invoke(new AnimationConfigurator(this.seriePlotOptions.Animation));
            return this.configurator;
        }

        public T ConnectNulls()
        {
            this.seriePlotOptions.ConnectNulls = true;
            return this.configurator;
        }

        public T Cursor(ChartCursor cursor)
        {
            this.seriePlotOptions.Cursor = cursor;
            return this.configurator;
        }

        public T DashStyle(ChartDashStyle style)
        {
            this.seriePlotOptions.DashStyle = style;
            return this.configurator;
        }

        public T LineWidth(int pixel)
        {
            this.seriePlotOptions.LineWidth = pixel;
            return this.configurator;
        }

        public T Selected()
        {
            this.seriePlotOptions.Selected = true;
            return this.configurator;
        }

        public T HideShadow()
        {
            this.seriePlotOptions.Shadow = false;
            return this.configurator;
        }

        public T ShowCheckbox()
        {
            this.seriePlotOptions.ShowCheckbox = true;
            return this.configurator;
        }
        
        //TODO: Add this
        /*
        public void DataLabels(Expression<Func<DataLabelsConfigurator, JsonConfigurator>> expression)
        {
            return this.Set(expression.ToJson());
        }

        public void Events(Expression<Func<EventsConfigurator, JsonConfigurator>> expression)
        {
            return this.Set(expression.ToJson());
        }
        */

        public T Stacking(ChartStacking stacking)
        {
            this.seriePlotOptions.Stacking = stacking;
            return this.configurator;
        }
    }
}
