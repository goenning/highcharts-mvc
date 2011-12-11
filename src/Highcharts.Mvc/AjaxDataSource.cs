using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highcharts.Mvc
{
    public class AjaxDataSource : DataSource
    {
        public string Url { get; private set; }
        private int? milisecondsInterval = null;

        public AjaxDataSource(string url)
        {
            this.Url = url;
        }

        public override string ToHtmlString(string chartId)
        {
            string function = string.Format(@"$.getJSON('{0}', function(data) {{
                                                {1}.clearSeries();

                                                $.each(data, function (key, value) {{
                                                    {1}.addSeries({{
                                                        name: value.Name,
                                                        data: value.Values
                                                    }}); ;
                                                }});
                                            }});", this.Url, chartId);

            if (milisecondsInterval.HasValue)
            {
                return string.Format(@"setIntervalAndExecute(function(){{ 
                                            {0}
                                       }}, {1});", function, this.milisecondsInterval.Value);
            }
            
            return function;
        }

        public AjaxDataSource Reload(int miliseconds)
        {
            this.milisecondsInterval = miliseconds;
            return this;
        }
    }
}
