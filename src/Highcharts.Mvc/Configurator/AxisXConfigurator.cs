using Highcharts.Mvc.Json;
using System.Linq.Expressions;
using System;
using Highcharts.Mvc.Models;

namespace Highcharts.Mvc
{
    public class AxisXConfigurator : JsonConfigurator
    {
        private readonly XAxis axis;
        internal AxisXConfigurator(XAxis axis)
        {
            this.axis = axis;
        }

        public AxisXConfigurator()
            : base("xAxis")
        {

        }

        public AxisXConfigurator Categories(params string[] categories)
        {
            this.axis.Categories = categories;
            return this;
        }

        public AxisXConfigurator Title(string text)
        {
            return this.Title(text, x => { });
        }

        public AxisXConfigurator Title(string text, Action<AxisTitleConfigurator> action)
        {
            this.axis.Title.Text = text;

            action.Invoke(new AxisTitleConfigurator(this.axis.Title));
            return this;
        }
    }
}
