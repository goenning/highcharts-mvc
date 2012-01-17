using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc
{
    public interface IJsonConfigurator
    {
        JsonAttribute ToJson();
    }
}
