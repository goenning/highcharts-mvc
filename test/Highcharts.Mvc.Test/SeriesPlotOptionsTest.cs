using NUnit.Framework;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class SeriesPlotOptionsTest : ConfiguratorTest<SeriesPlotOptions>
    {
        [Test]
        public void EmptySeriesPlotOptions()
        {
            var actual = this.Configure(x => x);
            var expected = @"series: { }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BasicSeriesPlotOptionsSetUp()
        {
            var actual = this.Configure(x => x.ShowDataLabels().DisableMouseTracking().HideInLegend());
            var expected = @"series: {
                                dataLabels: {
                                    enabled: true
                                },
                                enableMouseTracking: false,
                                showInLegend: false
                             }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void DisabledStackingSeriesPlotOptions()
        {
            var actual = this.Configure(x => x.Stacking(ChartStacking.Disabled));
            var expected = @"series: { stacking:null }";
            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void AnimationSeriesPlotOptions()
        {
            var actual = this.Configure(x =>
                x.Animation(y => y.Duration(2000).Easing(ChartAnimation.Linear))
            );

            var expected = @"series: { 
                                animation: {
                                    duration: 2000,
                                    easing: 'linear'
                                }
                            }";
            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void FullSeriesPlotOptionsSetUp()
        {
            var actual = this.Configure(x => 
                x.Id("my-series")
                .ShowDataLabels()
                .DisableMouseTracking()
                .HideInLegend()
                .Color("FFF")
                .AllowPointSelect()
                .NoAnimation()
                .ConnectNulls()
                .Cursor(ChartCursor.Pointer)
                .DashStyle(ChartDashStyle.LongDashDotDot)
                .LineWidth(10)
                .Selected()
                .HideShadow()
                .ShowCheckbox()
                .Stacking(ChartStacking.Percent)
                .HideSeries()
                .DisableStickyTracking()
                .ZIndex(100)
            );

            var expected = @"series: {
                                id: 'my-series',
                                dataLabels: {
                                    enabled: true
                                },
                                enableMouseTracking: false,
                                showInLegend: false,
                                color: 'FFF',
                                allowPointSelect: true,
                                animation: false,
                                connectNulls: true,
                                cursor: 'pointer',
                                dashStyle: 'longdashdotdot',
                                lineWidth: 10,
                                selected: true,
                                shadow: false,
                                showCheckbox: true,
                                stacking: 'percent',
                                visible: false,
                                stickyTracking: false,
                                zIndex: 100
                             }";

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
