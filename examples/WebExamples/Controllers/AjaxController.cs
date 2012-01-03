using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Highcharts.Mvc;

namespace WebExamples.Controllers
{
    public class AjaxController : Controller
    {
        public JsonResult LoadData()
        {
            Serie[] series = new Serie[] {
                new Serie("iPhone", DataGenerator.GetRandomData(12)),
                new Serie("iPad", DataGenerator.GetRandomData(12)),
                new Serie("MacBook", DataGenerator.GetRandomData(12))
            };

            return Json(series, JsonRequestBehavior.AllowGet);
        }
    }
}
