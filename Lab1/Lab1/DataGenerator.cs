using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    public static class DataGenerator
    {
        public static int[] GetData(string dataType, int n)
        {
            return dataType switch
            {
                "Desc" => Descending(n),
                "Asc" => Ascending(n),
                "AShape" => AShape(n),
                "VShape" => VShape(n),
                "Random" => Random(n),
                "Const" => Constant(n),
                _ => throw new ArgumentException("Data type doesn't exist!"),
            };
        }

        private static int[] Descending(int n)
        {
            var res = new int[n];
            for(var i = 0; i < n; i++)
            {
                res[i] = n - i;
            }

            return res;
        }

        private static int[] Ascending(int n)
        {
            var res = new int[n];
            for(var i = 0; i < n; i++)
            {
                res[i] = i;
            }
            return res;
        }

        private static int[] Constant(int n)
        {
            var res = new int[n];
            for(var i = 0; i < n; i++)
            {
                res[i] = 1;
            }

            return res;
        }

        private static int[] AShape(int n)
        {
            var res = new int[n];
            int j = 0;
            for (var i = 0; i < n/2; i++)
            {
                res[i] = j;
                j += 2;
            }

            j++;
            for(var i = n/2; i < n; i++)
            {
                res[i] = j;
                j -= 2;
            }
            return res;
        }

        private static int[] VShape(int n)
        {
            var res = new int[n];
            var j = n;
            for (var i = 0; i < n/2; i++)
            {
                res[i] = j;
                j -= 2;
            }

            j++;
            for(var i = n/2; i < n; i++)
            {
                res[i] = j;
                j += 2;
            }

            return res;
        }

        private static int[] Random(int n)
        {
            var res = new int[n];
            var rand = new Random();
            for (int i = 0; i < n; i++)
            {
                res[i] = rand.Next(0, 1000000);
            }

            return res;
        }
    }
}
