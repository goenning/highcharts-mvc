using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class JsonSerializerTest
    {
        [Test]
        public void BasicObject()
        {
            var json = new JsonObject("enabled", "true");
            string actual = json.ToString();
            string expected = "enabled: 'true'";
            
            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BasicWithMoneyValueObject()
        {
            var json = new JsonObject("total", 125.20);
            string actual = json.ToString();
            string expected = "total: 125.2";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void NestedObjectTest()
        {
            var enabled = new JsonObject("enabled", 2);
            var dataLabels = new JsonObject("dataLabels", enabled);
            string actual = dataLabels.ToString();
            string expected = "dataLabels: { enabled: 2 }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TwoNestedObjectTest()
        {
            var enabled = new JsonObject("enabled", "true");
            var color = new JsonObject("color", "red");
            var dataLabels = new JsonObject("dataLabels", enabled, color);
            string actual = dataLabels.ToString();
            string expected = "dataLabels: { enabled: 'true', color: 'red' }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ObjectWithStringArrayValueTest()
        {
            var values = new JsonObject("values", new string[] { "Jan", "Feb", "Mar" });
            string actual = values.ToString();
            string expected = "values: [ 'Jan', 'Feb', 'Mar' ]";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ObjectWithIntegerArrayValueTest()
        {
            var values = new JsonObject("values", new object[] { 1, 2, 3 });
            string actual = values.ToString();
            string expected = "values: [ 1, 2, 3 ]";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ObjectWithBooleanValueTest()
        {
            var values = new JsonObject("enabled", true);
            string actual = values.ToString();
            string expected = "enabled: true";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void NoValueTest()
        {
            var values = new JsonObject("chart");
            string actual = values.ToString();
            string expected = "chart: { }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void AddChildTest()
        {
            var values = new JsonObject("chart");
            values.Set(new JsonObject("enabled", true));
            string actual = values.ToString();
            string expected = "chart: { enabled: true }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void AddChildShouldOverrideValue()
        {
            var values = new JsonObject("options", false);
            values.Set(new JsonObject("enabled", true));
            string actual = values.ToString();
            string expected = "options: { enabled: true }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldUseLastChildWhenDuplicated()
        {
            var values = new JsonObject("options", false);
            values.Set(new JsonObject("enabled", true));
            values.Set(new JsonObject("enabled", false));
            string actual = values.ToString();
            string expected = "options: { enabled: false }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void NamedFunction()
        {
            var formatter = new JsonFunctionObject("formatter", "showFormat");
            string actual = formatter.ToString();
            string expected = "formatter: showFormat";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void AnonymousFunction()
        {
            var formatter = new JsonFunctionObject("formatter", "return 'Hello';");
            string actual = formatter.ToString();
            string expected = "formatter: function() { return 'Hello'; }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void EmptyKeyAndValue()
        {
            var chart = new JsonObject();
            string actual = chart.ToString();
            string expected = "";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void EmptyKeyWithChild()
        {
            var chart = new JsonObject();
            chart.Set(new JsonObject("renderTo", "container"));
            string actual = chart.ToString();
            string expected = "renderTo: 'container'";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void EmptyKeyWithDuplicatedChild()
        {
            var chart = new JsonObject();
            chart.Set(new JsonObject("renderTo", "container"));
            chart.Set(new JsonObject("renderTo", "new-container"));
            string actual = chart.ToString();
            string expected = "renderTo: 'new-container'";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ComplexJsonObjectGraph()
        {
            var chart = new JsonObject();
            var title = new JsonObject("title");
            chart.Set(title);
            title.Set(new JsonObject("color", "red"));
            title.Set(new JsonObject("size", "16px"));
            string actual = chart.ToString();
            string expected = @"title: {
                                    color: 'red',
                                    size: '16px'
                                }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ComplexJsonObjectGraph_WithTwoMainObjects()
        {
            var chart = new JsonObject();

            var title = new JsonObject("title");
            chart.Set(title);
            title.Set(new JsonObject("color", "red"));
            title.Set(new JsonObject("size", "16px"));

            var subtitle = new JsonObject("subtitle");
            chart.Set(subtitle);
            subtitle.Set(new JsonObject("size", "12px"));

            string actual = chart.ToString();
            string expected = @"title: {
                                    color: 'red',
                                    size: '16px'
                                }, 
                                subtitle: {
                                    size: '12px'
                                }";

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}

