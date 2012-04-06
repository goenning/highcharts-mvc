using NUnit.Framework;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class LegendChartTest : ConfiguratorTest<LegendConfigurator>
    {
        [Test]
        public void EmptySetUp()
        {
            var actual = this.Configure(x => x);
            var expected = @"legend: { }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BasicSetUp()
        {
            var actual = this.Configure(x => x.Position(y => y.Left().Top().X(20).Y(10)).Floating());
            var expected = @"legend: {
                                align: 'left',
                                verticalAlign: 'top',
                                x: 20,
                                y: 10,
                                floating: true
                            }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void LegendBorderSetUp()
        {
            var actual = this.Configure(x => x.Position(y => y.Middle()).Border("#FFF", 10, 5));
            var expected = @"legend: {
                               verticalAlign: 'middle',
                               borderColor: '#FFF',
                               borderRadius: 10,
                               borderWidth : 5
                           }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void FullSetUp()
        {
            var actual = this.Configure(x => 
                                            x.Position(y => y.Middle())
                                             .Border("#FFF", 10, 5)
                                             .BackgroundColor("#00FF00")
                                             .Hide()
                                             .Floating()
                                             .ItemWidth(10)
                                             .LineHeight(15)
                                             .Margin(5)
                                             .Reverse()
                                             .ShowShadow()
                                             .SymbolPadding(8)
                                             .SymbolWidth(12)
                                             .Width(200)
                                             .Layout(LegendLayout.Vertical)
                                             .LabelFormatter("legendLabelFormatter")
            );
            var expected = @"legend: {
                               verticalAlign: 'middle',
                               borderColor: '#FFF',
                               borderRadius: 10,
                               borderWidth : 5,
                               backgroundColor: '#00FF00',
                               enabled: false,
                               floating: true,
                               itemWidth: 10, 
                               lineHeight: 15, 
                               margin: 5, 
                               reversed: true, 
                               shadow: true, 
                               symbolPadding: 8, 
                               symbolWidth: 12, 
                               width: 200, 
                               layout: 'vertical',
                               labelFormatter: legendLabelFormatter
                           }";

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
