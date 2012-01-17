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
