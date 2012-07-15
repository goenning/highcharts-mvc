using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc.Test.Json.Models
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }

        public Customer Friend { get; set; }
        public CustomerType? Type { get; set; }
        public int[] Ids { get; set; }
    }
}
