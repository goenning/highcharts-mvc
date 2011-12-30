using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExamples.Models;

namespace WebExamples.Controllers
{
    public class HomeController : Controller
    {
        private Random rnd;
        public HomeController()
        {
            this.rnd = new Random();
        }

        [HttpGet]
        public ActionResult Basic()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Advanced()
        {
            IList<TicketsPerMonth> items = new List<TicketsPerMonth>();
            items.Add(new TicketsPerMonth("CRM", this.GetRandomData(12)));
            items.Add(new TicketsPerMonth("ERP", this.GetRandomData(12)));

            return View(items);
        }

        public int[] GetRandomData(int quantity)
        {
            int[] values = new int[quantity];
            for (int i = 0; i < quantity; i++)
                values[i] = rnd.Next(0, 100);

            return values;
        }
    }
}
