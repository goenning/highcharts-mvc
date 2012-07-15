using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc.Test.Json.Models
{
    public class Person
    {
        public Person()
        {
            this.BestFriend = new Dog();
        }

        public string Name { get; set; }
        public Dog BestFriend { get; set; }
    }
}
