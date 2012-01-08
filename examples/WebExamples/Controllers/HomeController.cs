using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Highcharts.Mvc;

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
        public ActionResult Themed()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Advanced()
        {
            IList<Serie> series = new List<Serie>();
            series.Add(new AreaSerie("ERP", DataGenerator.GetRandomData(12)));
            series.Add(new LineSerie("CRM", DataGenerator.GetRandomData(12)));

            return View(series);
        }

        [HttpGet]
        public ActionResult Cached()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CachedChartSetUp()
        {
            return View();
        }
    }
}
