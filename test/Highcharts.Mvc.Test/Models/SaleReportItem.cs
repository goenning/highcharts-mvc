using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Highcharts.Mvc.Test.Models
{
    public class SaleReportItem
    {
        public string Employee { get; private set; }
        public float[] TotalSalesValue { get; private set; }

        public SaleReportItem(string employee, float[] totalSalesValue)
        {
            this.Employee = employee;
            this.TotalSalesValue = totalSalesValue;
        }
    }
}