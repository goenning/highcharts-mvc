using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public class ColumnSerie : Serie
    {
        public ColumnSerie(string name, Array values)
            : base(name, "column", values)
        {

        }
    }
}
