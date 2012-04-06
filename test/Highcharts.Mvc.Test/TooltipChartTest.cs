using NUnit.Framework;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class TooltipChartTest : ConfiguratorTest<TooltipConfigurator>
    {
        [Test]
        public void BasicTooltipSetUp()
        {
            var actual = this.Configure(x => x.Shared().Crosshairs());
            var expected = @"tooltip: {
                                shared: true,
                                crosshairs: true
                            }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TooltipAnonymousFormatterSetUp()
        {
            var actual = this.Configure(x => x.Formatter("return 'The value for <b>' + this.x + '</b> is <b>' + this.y + '</b>';"));
            var expected = @"tooltip: {
                                formatter: function() {
                                    return 'The value for <b>' + this.x + '</b> is <b>' + this.y +'</b>';
                                }
                            }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TooltipNamedFormatterSetUp()
        {
            var actual = this.Configure(x => x.Formatter("myFunction"));
            var expected = @"tooltip: {
                                formatter: myFunction
                            }";

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
