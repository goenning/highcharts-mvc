using NUnit.Framework;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class AnimationChartTest : ConfiguratorTest<AnimationConfigurator>
    {
        [Test]
        public void BasicAnimationSetUp()
        {
            var actual = this.Configure(x => x.Duration(2000).Easing(ChartAnimation.Linear));
            var expected = @"animation: {
                                duration: 2000,
                                easing: 'linear'
                            }";

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
