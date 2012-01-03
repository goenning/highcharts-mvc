using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public class AreaSerie : Serie
    {
        public AreaSerie(string name, Array values)
            : base(name, "area", values)
        {

        }
    }
}
