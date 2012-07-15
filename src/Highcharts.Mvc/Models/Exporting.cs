using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc.Models
{
    internal class Exporting
    {
        public Exporting()
        {
            this.Buttons = new ExportingButtons();
        }

        public ExportingButtons Buttons { get; private set; }
    }
}
