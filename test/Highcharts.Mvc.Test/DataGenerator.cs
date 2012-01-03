using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Highcharts.Mvc.Test
{
    public static class DataGenerator
    {
        private static Random rnd = new Random();

        public static int[] GetRandomData(int quantity)
        {
            int[] values = new int[quantity];
            for (int i = 0; i < quantity; i++)
                values[i] = rnd.Next(0, 100);

            return values;
        }
    }
}