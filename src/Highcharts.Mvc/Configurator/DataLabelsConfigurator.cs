using System;
using System.Linq.Expressions;
using Highcharts.Mvc.Json;
using Highcharts.Mvc.Models;

namespace Highcharts.Mvc
{
    public class DataLabelsConfigurator
    {
        private readonly DataLabels dataLabels;
        internal DataLabelsConfigurator(DataLabels dataLabels)
        {
            this.dataLabels = dataLabels;
        }

        public DataLabelsConfigurator Position(Action<PositionConfigurator> expression)
        {
            expression.Invoke(new PositionConfigurator(dataLabels.Position));
            return this;
        }

        public DataLabelsConfigurator Color(string color)
        {
            this.dataLabels.Color = color;
            return this;
        }

        public DataLabelsConfigurator Show()
        {
            this.dataLabels.Enabled = true;
            return this;
        }

        public DataLabelsConfigurator Formatter(string function)
        {
            this.dataLabels.Formatter = new JsonFunction(function);
            return this;
        }

        public DataLabelsConfigurator Rotation(int rotation)
        {
            this.dataLabels.Rotation = rotation;
            return this;
        }
    }
}
