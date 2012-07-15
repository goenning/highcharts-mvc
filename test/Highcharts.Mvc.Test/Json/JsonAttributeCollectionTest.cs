using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc.Test.Json
{
    [TestFixture]
    public class JsonAttributeCollectionTest
    {
        [Test]
        public void SingleItemTest()
        {
            JsonAttribute colorAttribute = new JsonAttribute("color", "red");
            JsonAttributeCollection attributes = new JsonAttributeCollection();
            attributes.Set(colorAttribute);

            Assert.AreEqual(colorAttribute, attributes[0]);
        }

        [Test]
        public void TwoItemTest()
        {
            JsonAttribute colorAttribute = new JsonAttribute("color", "red");
            JsonAttribute alignAttribute = new JsonAttribute("align", "center");
            JsonAttributeCollection attributes = new JsonAttributeCollection();
            attributes.Set(colorAttribute);
            attributes.Set(alignAttribute);

            Assert.AreEqual(colorAttribute, attributes[0]);
            Assert.AreEqual(alignAttribute, attributes[1]);
        }

        [Test]
        public void OverrideItemTest()
        {
            JsonAttribute redColorAttribute = new JsonAttribute("color", "red");
            JsonAttribute blueColorAttribute = new JsonAttribute("color", "blue");
            JsonAttributeCollection attributes = new JsonAttributeCollection();
            attributes.Set(redColorAttribute);
            attributes.Set(blueColorAttribute);

            Assert.AreEqual(blueColorAttribute, attributes[0]);
            Assert.AreEqual(1, attributes.Count);
        }

        [Test]
        public void ToStringTest()
        {
            JsonAttribute colorAttribute = new JsonAttribute("color", "red");
            JsonAttributeCollection attributes = new JsonAttributeCollection();
            attributes.Set(colorAttribute);

            Assert.AreEqual("color: 'red'", attributes.ToString());
        }

        [Test]
        public void TwoItemsToStringTest()
        {
            JsonAttribute colorAttribute = new JsonAttribute("color", "red");
            JsonAttribute alignAttribute = new JsonAttribute("align", "center");
            JsonAttributeCollection attributes = new JsonAttributeCollection();
            attributes.Set(colorAttribute);
            attributes.Set(alignAttribute);

            Assert.AreEqual("color: 'red', align: 'center'", attributes.ToString());
        }
    }
}
