using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc.Test.Json
{
    [TestFixture]
    public class JsonObjectTest
    {
        [Test]
        public void EmptyObject()
        {
            var json = new JsonObject();
            var actual = json.ToString();
            var expected = "{ }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void FunctionObject()
        {
            var json = new JsonObject(new JsonFunction("return 'Hello';"));
            var actual = json.ToString();
            var expected = "function() { return 'Hello'; }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ObjectArrayObject()
        {
            Array arr = new JsonObject[] { 
                new JsonObject(), 
                new JsonObject() 
            };

            var json = new JsonObject(arr);
            var actual = json.ToString();
            var expected = "[{ },{ }]";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void StringArrayObject()
        {
            Array arr = new string[] { "One", "Two" };
            var json = new JsonObject(arr);
            var actual = json.ToString();
            var expected = "['One','Two']";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Int32ArrayObject()
        {
            Array arr = new int[] { 1, 2 };
            var json = new JsonObject(arr);
            var actual = json.ToString();
            var expected = "[1,2]";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void DecimalObject()
        {
            var json = new JsonObject(24.52);
            var actual = json.ToString();
            var expected = "24.52";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void StringObject()
        {
            var json = new JsonObject("Hello World");
            var actual = json.ToString();
            var expected = "'Hello World'";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void FalseObject()
        {
            var json = new JsonObject(false);
            var actual = json.ToString();
            var expected = "false";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TrueObject()
        {
            var json = new JsonObject(true);
            var actual = json.ToString();
            var expected = "true";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Int32Object()
        {
            var json = new JsonObject(2);
            var actual = json.ToString();
            var expected = "2";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void EmptyWithOneAttribute()
        {
            var json = new JsonObject();
            json.Add(new JsonAttribute("title", "My Object"));
            var actual = json.ToString();
            var expected = "{ title: 'My Object' }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void EmptyWithTwoAttributes()
        {
            var json = new JsonObject();
            json.Add(new JsonAttribute("title", "My Object"));
            json.Add(new JsonAttribute("subtitle", "This is the subtitle"));
            var actual = json.ToString();
            var expected = @"{ 
                                title: 'My Object',  
                                subtitle: 'This is the subtitle'
                            }";

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
