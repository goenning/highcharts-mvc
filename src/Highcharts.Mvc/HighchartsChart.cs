﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Dynamic;
using System.Linq.Expressions;

namespace Highcharts.Mvc
{
    public class HighchartsChart : HighchartsSetUp
    {
        public HighchartsChart(string id)
            : base(id)
        {
        }

        public override IHtmlString ToHtmlString()
        {
            StringBuilder html = new StringBuilder();
            html.AppendFormat("<div id=\"{0}\"></div>", this.Id);
            html.AppendLine();
            html.AppendFormat(@"<script type=""text/javascript"">
                                    {1}
                                </script>", this.Id, base.ToHtmlString());

            return MvcHtmlString.Create(html.ToString());
        }
    }
}