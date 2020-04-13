using CsvHelper;
using CsvHelper.Configuration;
using System.Diagnostics;
using System;
using System.IO;

namespace Lab2
{
    class Program
    {
        const string RESULTS_DIRECTORY = "../Results/";

        static void Main(string[] args)
        {
            Console.Write(
                "\n" +
                "BST and Sorted Linked List speed comparison\n" +
                "made by Maciej Frel and Marcin Duda\n" +
                "\n"
                );

            int start = ReadNumberFromConsole("Starting point number");
            int step = ReadNumberFromConsole("Step number");
            int stop = ReadNumberFromConsole("End point number");

            CompareInsertTime(start, step, stop);
            // CompareSearchTime(start, step, stop);
            // CompareDestroyTime(start, step, stop);
        }

        static void CompareInsertTime(int start, int step, int stop)
        {
            int numberOfElements = start;

            using (StreamWriter output = File.CreateText(RESULTS_DIRECTORY + "insert.csv"))
            using (CsvWriter csv = new CsvWriter(output, System.Globalization.CultureInfo.CurrentCulture))
            {
                csv.Configuration.NewLine = NewLine.LF;
                csv.Configuration.Delimiter = ",";
                csv.WriteHeader(typeof(CompareResults));
                while (numberOfElements <= stop) {
                    var data = DataGenerator.UniqueArray(numberOfElements);
                    var bst = new BST();
                    var linkedList = new SortedLinkedList();
                    var result = new CompareResults
                    {
                        NumberOfElements = numberOfElements,
                        BST = bst.MeasureInsertTime(data),
                        LinkedList = linkedList.MeasureInsertTime(data)
                    };
                    csv.NextRecord();
                    csv.WriteRecord(result);
                    numberOfElements += step;
                }
            }
        }

        static void CompareSearchTime(int start, int step, int stop)
        {
            throw new NotImplementedException();
        }

        static void CompareDestroyTime(int start, int step, int stop)
        {
            throw new NotImplementedException();
        }

        private static int ReadNumberFromConsole(string consoleMessage) {
            Console.Write(consoleMessage + ": ");
            return ReadNumberFromConsole();
        }

        private static int ReadNumberFromConsole()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result)) {
                Console.Write("Invalid value, type a number: ");
            }
            return result;
        }
    }
}
