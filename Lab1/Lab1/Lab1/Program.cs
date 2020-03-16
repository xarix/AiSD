using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = DataGenerator.VShape(25);
            foreach(var i in data)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Hello World!");
        }
    }
}
