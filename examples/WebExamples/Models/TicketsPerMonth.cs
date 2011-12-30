using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebExamples.Models
{
    public class TicketsPerMonth
    {
        public string Product { get; private set; }
        public int[] Tickets { get; private set; }

        public TicketsPerMonth(string product, int[] tickets)
        {
            this.Product = product;
            this.Tickets = tickets;
        }
    }
}