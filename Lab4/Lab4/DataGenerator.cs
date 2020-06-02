using System;
using System.Collections.Generic;


namespace Lab4
{
    public class DataGenerator
    {
        public static List<Container> AllRandom(int n)
        {
            var random = new Random();
            var result = new List<Container>();
            for (int i = 0; i < n ; i++)
            {
                result.Add(new Container {
                    Weight = random.Next(9) + 1,
                    Value = random.Next(9) + 1
                });
            }
            return result;
        }

        public static List<Container> RandomValueStaticWeight(int n)
        {
            var random = new Random();
            var result = new List<Container>();
            for (int i = 0; i < n ; i++)
            {
                result.Add(new Container {
                    Weight = 5,
                    Value = random.Next(9) + 1
                });
            }
            return result;
        }


        public static List<Container> StaticValueRandomWeight(int n)
        {
            var random = new Random();
            var result = new List<Container>();
            for (int i = 0; i < n ; i++)
            {
                result.Add(new Container {
                    Weight = random.Next(9) + 1,
                    Value = 5
                });
            }
            return result;
        }

    }
}