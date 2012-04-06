using NUnit.Framework;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class CreditsChartTest : ConfiguratorTest<CreditsConfigurator>
    {
        [Test]
        public void CreditsEmptySetUp()
        {
            var actual = this.Configure(x => x);
            var expected = @"credits: { }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void CreditsBasicSetUp()
        {
            var actual = this.Configure(x => x.Hide().Text("Google").Url("http://www.google.com"));
            var expected = @"credits: {
                                enabled: false,
                                text: 'Google',
                                href: 'http://www.google.com'
                            }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void CreditsPositionSetUp()
        {
            var actual = this.Configure(x => x.Position(y => y.Left().Top().X(20).Y(10)));
            var expected = @"credits: {
                                position: {
	                                align: 'left',
	                                verticalAlign: 'top',
	                                x: 20,
	                                y: 10
                                }
                            }";

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
