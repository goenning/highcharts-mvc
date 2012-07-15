using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc.Json
{
    public interface ICustomJsonConverter
    {
        bool IsConsideredNull();
        string ToJson();
    }
}
