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
            int[] values = new int[9];
            Random rnd = new Random();
            for (int i = 0; i < values.Length; i++)
                values[i] = rnd.Next(0, 100);

            Serie[] series = new Serie[] {
                new Serie("iPhone", values[0], values[1], values[2]),
                new Serie("iPad", values[3], values[4], values[5]),
                new Serie("MacBook", values[6], values[7], values[8])
            };

            return Json(series, JsonRequestBehavior.AllowGet);
        }
    }
}
