using NUnit.Framework;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class DataLabelsChartTest : ConfiguratorTest<DataLabelsConfigurator>
    {
        [Test]
        public void EmptySetUp()
        {
            var actual = this.Configure(x => x);
            var expected = @"dataLabels: {
                            }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BasicSetUp()
        {
            var actual = this.Configure(x => 
                                        x.Position(y => y.Center())
                                         .Color("FF0000")
                                         .Show()
                                         .Formatter("showCoolLabel")
                                         .Rotation(90)
            );
            var expected = @"dataLabels: {
                                align: 'center',
                                color: 'FF0000',
                                enabled: true,
                                formatter: showCoolLabel,
                                rotation: 90                               
                            }";

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
