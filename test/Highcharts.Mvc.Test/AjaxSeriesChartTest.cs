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
            //TODO: uncoment this
            var actual = AjaxConfig.LoadFrom("/Ajax/LoadData")
                                   .AsGet()
                                   .Reload(100)
                                   //.Animation(x => x.Duration(2000).Easing(ChartEasing.Swing))
                                   .ToHtmlString("myChart");
            var expected = MvcHtmlString.Create(@"loadChartAjax({  
                                                    url: '/Ajax/LoadData',
                                                    method: 'GET',
                                                    interval: 100,
                                                    animation: {
                                                        duration: 2000,
                                                        easing: 'swing'
                                                    },
                                                    chartId: 'myChart'
                                                  });");

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void AjaxSourceWithoutAnimation()
        {
            var actual = AjaxConfig.LoadFrom("/Ajax/LoadData").NoAnimation().ToHtmlString("myChart");
            var expected = MvcHtmlString.Create(@"loadChartAjax({ 
                                                    url: '/Ajax/LoadData',
                                                    animation: false,
                                                    chartId: 'myChart'
                                                  });");

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
