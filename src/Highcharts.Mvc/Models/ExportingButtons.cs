using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc.Models
{
    internal class ExportingButtons
    {
        public ExportingButtons()
        {
            this.ExportButton = new Button();
            this.PrintButton = new Button();
        }

        public Button ExportButton { get; private set; }
        public Button PrintButton { get; private set; }
    }
}
