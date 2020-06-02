using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            var ship = new Ship(10);
            ship.OptimalLoadGreedy(DataGenerator.AllRandom(10));
            ship.OptimalLoadDinamically(DataGenerator.AllRandom(10));
        }
    }
}
