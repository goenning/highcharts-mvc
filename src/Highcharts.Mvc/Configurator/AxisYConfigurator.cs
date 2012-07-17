using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highcharts.Mvc.Json;
using System.Linq.Expressions;
using Highcharts.Mvc.Models;

namespace Highcharts.Mvc
{
    public class AxisYConfigurator
    {
        private readonly YAxis axis;
        internal AxisYConfigurator(YAxis axis)
        {
            this.axis = axis;
        }

        public AxisYConfigurator Title(string text)
        {
            this.axis.Title.Text = text;
            return this;
        }

        public AxisYConfigurator Title(string text, Action<AxisTitleConfigurator> action)
        {
            this.axis.Title.Text = text;
            action.Invoke(new AxisTitleConfigurator(this.axis.Title));
            return this;
        }
    }
}
