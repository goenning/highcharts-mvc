using System.Web.Mvc;
using NUnit.Framework;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class AjaxSeriesChartTest
    {
        [Test]
        public void BasicAjaxSource()
        {
            var actual = AjaxConfig.LoadFrom("/Ajax/LoadData").ToHtmlString("myChart");
            var expected = MvcHtmlString.Create(@"loadChartAjax({ 
                                                    url: '/Ajax/LoadData',
                                                    chartId: 'myChart'
                                                  });");

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void AjaxSourceWithAllOptions()
        {
            var actual = AjaxConfig.LoadFrom("/Ajax/LoadData")
                                   .AsGet()
                                   .Reload(100)
                                   .Animation(x => x.Duration(2000).Easing(ChartEasing.Swing))
                                   .ToHtmlString("myChart");
            var expected = MvcHtmlString.Create(@"loadChartAjax({  
                                                    url: '/Ajax/LoadData',
                                                    chartId: 'myChart',
                                                    interval: 100,
                                                    method: 'GET',
                                                    animation: {
                                                        duration: 2000,
                                                        easing: 'swing'
                                                    }
                                                  });");

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void AjaxSourceWithoutAnimation()
        {
            var actual = AjaxConfig.LoadFrom("/Ajax/LoadData").NoAnimation().ToHtmlString("myChart");
            var expected = MvcHtmlString.Create(@"loadChartAjax({ 
                                                    url: '/Ajax/LoadData',
                                                    chartId: 'myChart',
                                                    animation: false
                                                  });");

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
