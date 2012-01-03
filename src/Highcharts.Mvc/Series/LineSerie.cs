using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public class LineSerie : Serie
    {
        public LineSerie(string name, Array values)
            : base(name, "line", values)
        {

        }
    }
}
