using NUnit.Framework;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class PlotOptionsEventsChartTest : ConfiguratorTest<EventsConfigurator>
    {
        [Test]
        public void EmptySetUp()
        {
            var actual = this.Configure(x => x);
            var expected = @"events: { }";

            HtmlAssert.AreEqual(expected, actual);
        }
        
        [Test]
        public void BasicSetUp()
        {
            var actual = this.Configure(x =>
                                        x.OnClick("onClickFunction")
                                         .OnCheckboxClick("onCheckboxClickFunction")
                                         .OnHide("onHideFunction")
                                         .OnLegendItemClick(@"function() {
                                                                  return true;
                                                              }")
                                         .OnMouseOver("onMouseOverFunction")
                                         .OnMouseOut("onMouseOutFunction")
                                         .OnShow(@"function(e) {
                                                       alert ('The series was just shown');
                                                   }")
            );
            var expected = @"events: {
                                click: onClickFunction,
                                checkboxClick: onCheckboxClickFunction,
                                hide: onHideFunction,
                                legendItemClick: function() {
                                    return true;
                                },
                                mouseOver: onMouseOverFunction,
                                mouseOut: onMouseOutFunction,
                                show: function(e) {
                                    alert ('The series was just shown');
                                }
                            }";

            HtmlAssert.AreEqual(expected, actual);

        }
    }
}
