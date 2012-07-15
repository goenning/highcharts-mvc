using NUnit.Framework;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class SerieTypeTest
    {
        [Test, TestCaseSource("AllSeries")]
        public void CorrectTypeNamePerSerie(Serie serie, ChartSerieType? expected)
        {
            Assert.AreEqual(expected, serie.Type);
        }

        public static object[] AllSeries = new object[]
        {
            new object [] { new PieSerie("My Serie", new int[0]), ChartSerieType.Pie },
            new object [] { new AreaSplineSerie("My Serie", null), ChartSerieType.AreaSpline },
            new object [] { new AreaSerie("My Serie", null), ChartSerieType.Area },
            new object [] { new BarSerie("My Serie", null), ChartSerieType.Bar },
            new object [] { new ColumnSerie("My Serie", null), ChartSerieType.Column },
            new object [] { new LineSerie("My Serie", null), ChartSerieType.Line },
            new object [] { new SplineSerie("My Serie", null), ChartSerieType.Spline },
            new object [] { new ScatterSerie("My Serie", null), ChartSerieType.Scatter },
            new object [] { new Serie("My Serie", ChartSerieType.Scatter, null), ChartSerieType.Scatter },
            new object [] { new Serie("My Serie", null), null }
        };
    }
}
