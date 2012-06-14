using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc.Test.Json
{
    [TestFixture]
    public class JsonSerializerTest
    {
        [Test]
        public void BasicAttribute()
        {
            var json = new JsonAttribute("enabled", "true");
            string actual = json.ToString();
            string expected = "enabled: 'true'";
            
            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BasicWithMoneyValueObject()
        {
            var json = new JsonAttribute("total", 125.20);
            string actual = json.ToString();
            string expected = "total: 125.2";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void NestedAttributeTest()
        {
            var enabled = new JsonAttribute("enabled", 2);
            var dataLabels = new JsonAttribute("dataLabels", enabled);
            string actual = dataLabels.ToString();
            string expected = "dataLabels: { enabled: 2 }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TwoNestedAttributeTest()
        {
            var enabled = new JsonAttribute("enabled", "true");
            var color = new JsonAttribute("color", "red");
            var dataLabels = new JsonAttribute("dataLabels", enabled, color);
            string actual = dataLabels.ToString();
            string expected = "dataLabels: { enabled: 'true', color: 'red' }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void AttributeWithStringArrayValueTest()
        {
            var values = new JsonAttribute("values", new string[] { "Jan", "Feb", "Mar" });
            string actual = values.ToString();
            string expected = "values: [ 'Jan', 'Feb', 'Mar' ]";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void AttributeWithIntegerArrayValueTest()
        {
            var values = new JsonAttribute("values", new object[] { 1, 2, 3 });
            string actual = values.ToString();
            string expected = "values: [ 1, 2, 3 ]";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void AttributeWithBooleanValueTest()
        {
            var values = new JsonAttribute("enabled", true);
            string actual = values.ToString();
            string expected = "enabled: true";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void NoValueTest()
        {
            var values = new JsonAttribute("chart");
            string actual = values.ToString();
            string expected = "chart: { }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void EmptyAttributesShouldBeIgnored()
        {
            var values = new JsonAttribute("chart");
            values.Set(new EmptyJsonAttribute());
            string actual = values.ToString();
            string expected = "chart: { }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void AddChildTest()
        {
            var values = new JsonAttribute("chart");
            values.Set(new JsonAttribute("enabled", true));
            string actual = values.ToString();
            string expected = "chart: { enabled: true }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void AddChildShouldOverrideValue()
        {
            var values = new JsonAttribute("options", false);
            values.Set(new JsonAttribute("enabled", true));
            string actual = values.ToString();
            string expected = "options: { enabled: true }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldUseLastChildWhenDuplicated()
        {
            var values = new JsonAttribute("options", false);
            values.Set(new JsonAttribute("enabled", true));
            values.Set(new JsonAttribute("enabled", false));
            string actual = values.ToString();
            string expected = "options: { enabled: false }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void NamedFunction()
        {
            var formatter = new JsonAttribute("formatter", new JsonFunction("showFormat"));
            string actual = formatter.ToString();
            string expected = "formatter: showFormat";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void EnumJsonObject()
        {
            var formatter = new JsonAttribute("cursor", ChartCursor.Pointer);
            string actual = formatter.ToString();
            string expected = "cursor: 'pointer'";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void NullValueJsonObject()
        {
            var formatter = new JsonNullAttribute("stacking");
            string actual = formatter.ToString();
            string expected = "stacking: null";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void FullFunction()
        {
            var formatter = new JsonAttribute("formatter", new JsonFunction("function() { return 'Hello'; }"));
            string actual = formatter.ToString();
            string expected = "formatter: function() { return 'Hello'; }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void AnonymousFunction()
        {
            var formatter = new JsonAttribute("formatter", new JsonFunction("return 'Hello';"));
            string actual = formatter.ToString();
            string expected = "formatter: function() { return 'Hello'; }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void AttributeWithTwoChildObjects()
        {
            var firstObj = new JsonObject();
            firstObj.Add(new JsonAttribute("name", "First Value"));

            var secondObj = new JsonObject();
            secondObj.Add(new JsonAttribute("name", "Second Value"));

            var chart = new JsonAttribute("series", firstObj, secondObj);
            string actual = chart.ToString();
            string expected = @"series: [
                                    { name: 'First Value'},
                                    { name: 'Second Value'}
                                ]";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void EmptyKeyAndValue()
        {
            var chart = new JsonAttribute();
            string actual = chart.ToString();
            string expected = "";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void EmptyKeyWithChild()
        {
            var chart = new JsonAttribute();
            chart.Set(new JsonAttribute("renderTo", "container"));
            string actual = chart.ToString();
            string expected = "renderTo: 'container'";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void EmptyKeyWithDuplicatedChild()
        {
            var chart = new JsonAttribute();
            chart.Set(new JsonAttribute("renderTo", "container"));
            chart.Set(new JsonAttribute("renderTo", "new-container"));
            string actual = chart.ToString();
            string expected = "renderTo: 'new-container'";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ComplexJsonObjectGraph()
        {
            var chart = new JsonAttribute();
            var title = new JsonAttribute("title");
            chart.Set(title);
            title.Set(new JsonAttribute("color", "red"));
            title.Set(new JsonAttribute("size", "16px"));
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
            var chart = new JsonAttribute();

            var title = new JsonAttribute("title");
            chart.Set(title);
            title.Set(new JsonAttribute("color", "red"));
            title.Set(new JsonAttribute("size", "16px"));

            var subtitle = new JsonAttribute("subtitle");
            chart.Set(subtitle);
            subtitle.Set(new JsonAttribute("size", "12px"));

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

