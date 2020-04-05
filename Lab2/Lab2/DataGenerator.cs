using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public static class DataGenerator
    {
        public static int[] UniqueArray(int n)
        {
            var result = new int[n];
            for (var i = 0; i< n; i++)
            {
                result[i] = i;
            }

            return Shuffle(result);
        }

        private static int[] Shuffle(int[] array)
        {
            var rand = new Random();
            var index = 0;
            var tmp = 0;
            for (var i = 0; i < array.Length; i++)
            {
                index = rand.Next(0, array.Length);
                tmp = array[i];
                array[i] = array[index];
                array[index] = tmp;
            }

            return array;
        }
    }
}
