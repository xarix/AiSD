using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public static class DataGenerator
    {
        public static int[] GetData(string dataType, int n)
        {
            return dataType switch
            {
                Sort.DESCENDING => Descending(n),
                Sort.ASCENDING => Ascending(n),
                Sort.ASHAPED => AShape(n),
                Sort.VSHAPED => VShape(n),
                Sort.RANDOM => Random(n, 2),
                Sort.CONSTANT => Constant(n),
                _ => throw new ArgumentException("Data type doesn't exist!"),
            };
        }

        private static int[] Descending(int n)
        {
            var result = new int[n];
            for(var i = 0; i < n; i++)
            {
                result[i] = n - i;
            }

            return result;
        }

        private static int[] Ascending(int n)
        {
            var result = new int[n];
            for(var i = 0; i < n; i++)
            {
                result[i] = i;
            }
            return result;
        }

        private static int[] Constant(int n)
        {
            var result = new int[n];
            for(var i = 0; i < n; i++)
            {
                result[i] = 1;
            }

            return result;
        }

        private static int[] AShape(int n)
        {
            var result = new int[n];
            int j = 0;
            for (var i = 0; i < n/2; i++)
            {
                result[i] = j;
                j += 2;
            }

            j++;
            for(var i = n/2; i < n; i++)
            {
                result[i] = j;
                j -= 2;
            }
            return result;
        }

        private static int[] VShape(int n)
        {
            var result = new int[n];
            var j = n;
            for (var i = 0; i < n/2; i++)
            {
                result[i] = j;
                j -= 2;
            }

            j++;
            for(var i = n/2; i < n; i++)
            {
                result[i] = j;
                j += 2;
            }

            return result;
        }

        private static int[] Random(int n)
        {
            var result = new int[n];
            var rand = new Random();
            for (int i = 0; i < n; i++)
            {
                result[i] = rand.Next(0, 1000000);
            }
            return result;
        }

        private static int[] Random(int n, int limitMultiplier)
        {
            var result = new int[n];
            var rand = new Random();
            for (int i = 0; i < n; i++)
            {
                result[i] = rand.Next(0, n * limitMultiplier);
            }
            return result;
        }
    }
}
