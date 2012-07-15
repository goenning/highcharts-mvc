using Highcharts.Mvc.Json;
using NUnit.Framework;
using Highcharts.Mvc.Test.Json.Models;
using System.Collections.Generic;

namespace Highcharts.Mvc.Test.Json
{
    [TestFixture]
    public class JsonConverterTest
    {
        [Test]
        public void NullTest()
        {
            string json = JsonConverter.SerializeObject(null);
            Assert.AreEqual("", json);
        }

        [Test]
        public void IntegerTest()
        {
            string json = JsonConverter.SerializeObject(1);
            Assert.AreEqual("1", json);
        }

        [Test]
        public void StringTest()
        {
            string json = JsonConverter.SerializeObject("Hello World");
            Assert.AreEqual("'Hello World'", json);
        }

        [Test]
        public void ArrayTest()
        {
            string json = JsonConverter.SerializeObject(new int[] { 1, 3, 2 });
            Assert.AreEqual("[1,3,2]", json);
        }

        [Test]
        public void BooleanArrayTest()
        {
            string json = JsonConverter.SerializeObject(new bool[] { true, false, true });
            Assert.AreEqual("[true,false,true]", json);
        }

        [Test]
        public void MixedArrayTest()
        {
            string json = JsonConverter.SerializeObject(new object[] { true, 1, "a" });
            Assert.AreEqual("[true,1,'a']", json);
        }

        [Test]
        public void CollectionTest()
        {
            IList<string> list = new List<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");

            string json = JsonConverter.SerializeObject(list);
            Assert.AreEqual("['a','b','c']", json);
        }

        [Test]
        public void ComplexTypeTest()
        {
            Customer customer = new Customer();
            customer.FirstName = "Bob";
            customer.LastName = "Marley";
            customer.Age = 35;
            customer.Type = CustomerType.Special;
            customer.Ids = new int[] { 10, 20, 30 };

            string json = JsonConverter.SerializeObject(customer);
            Assert.AreEqual("{firstName:'Bob',lastName:'Marley',age:35,type:'special',ids:[10,20,30]}", json);
        }

        [Test]
        public void ComplexType_ShouldIgnoreNullPropertiesTest()
        {
            Customer customer = new Customer();
            customer.FirstName = "Bob";

            string json = JsonConverter.SerializeObject(customer);
            Assert.AreEqual("{firstName:'Bob'}", json);
        }

        [Test]
        public void ComplexType_WithAllNullPropertiesTest()
        {
            Customer customer = new Customer();

            string json = JsonConverter.SerializeObject(customer);
            Assert.AreEqual("{}", json);
        }

        [Test]
        public void ComplexType_WithComplexPropertyTest()
        {
            Customer customer = new Customer();
            customer.FirstName = "Bob";
            customer.Friend = new Customer();
            customer.Friend.FirstName = "Doug";

            string json = JsonConverter.SerializeObject(customer);
            Assert.AreEqual("{firstName:'Bob',friend:{firstName:'Doug'}}", json);
        }

        [Test]
        public void ComplexType_ShouldIgnoreComplexPropertyWhenAllOfItsPropertiesAreNull()
        {
            Customer customer = new Customer();
            customer.FirstName = "Bob";
            customer.Friend = new Customer();

            string json = JsonConverter.SerializeObject(customer);
            Assert.AreEqual("{firstName:'Bob'}", json);
        }

        [Test]
        public void MergePropertiesAttributeTest()
        {
            Shape shape = new Shape();
            shape.Name = "Square";
            shape.Style.Color = "Red";
            shape.Style.Border = false;

            string json = JsonConverter.SerializeObject(shape);
            Assert.AreEqual("{name:'Square',color:'Red',border:false}", json);
        }

        [Test]
        public void CustomJsonConverterTest()
        {
            Dog dog = new Dog();

            string json = JsonConverter.SerializeObject(dog);
            Assert.AreEqual("{custom:'I\'m a dog'}" , json);
        }

        [Test]
        public void ComplexType_WithPropertyWithCustomJsonConverterTypeTest()
        {
            Person person = new Person();
            person.Name = "Bob";

            string json = JsonConverter.SerializeObject(person);
            Assert.AreEqual("{name:'Bob',bestFriend:{custom:'I\'m a dog'}}", json);
        }

        [Test]
        public void PartialFunctionTest()
        {
            ShapeStyle style = new ShapeStyle();
            style.OnLoad = new JsonFunction("return 2;");

            string json = JsonConverter.SerializeObject(style);
            Assert.AreEqual("{onLoad:function(){return 2;}}", json);
        }

        [Test]
        public void FullFunctionTest()
        {
            ShapeStyle style = new ShapeStyle();
            style.OnLoad = new JsonFunction("function() { return 3; }");

            string json = JsonConverter.SerializeObject(style);
            Assert.AreEqual("{onLoad:function() { return 3; }}", json);
        }
    }
}
