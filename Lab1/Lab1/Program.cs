using CsvHelper;
using CsvHelper.Configuration;
using Sort;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Lab1
{
    class Program
    {
        public static void Exc1(int numberOfElements, int step)
        {
            var dataTypes = new List<string>() { "Desc", "Asc", "AShape", "VShape", "Random", "Const" };
            var stopWatch = new Stopwatch();

            using (StreamWriter output = File.CreateText("results1.csv"))
            using (CsvWriter csv = new CsvWriter(output, System.Globalization.CultureInfo.CurrentCulture))
            {
                csv.WriteHeader(typeof(Results));
                csv.Configuration.NewLine = NewLine.LF;
                for (int i = 0; i < 15; i++)
                {
                    foreach (var dataType in dataTypes)
                    {
                        var results = new Results();
                        results.NumberOfElements = numberOfElements;
                        results.DataType = dataType;

                        var dataIS = DataGenerator.GetData(dataType, numberOfElements);
                        stopWatch.Start();
                        _ = Sort.Sort.InsertionSort(dataIS);
                        stopWatch.Stop();
                        results.InsertionSortTime = stopWatch.Elapsed.Milliseconds;

                        var dataSS = DataGenerator.GetData(dataType, numberOfElements);
                        stopWatch.Start();
                        _ = Sort.Sort.SelectionSort(dataSS);
                        stopWatch.Stop();
                        results.SelectionSortTime = stopWatch.Elapsed.Milliseconds;

                        var dataHS = DataGenerator.GetData(dataType, numberOfElements);
                        stopWatch.Start();
                        _ = Sort.Sort.HeapSort(dataHS);
                        stopWatch.Stop();
                        results.HeapSortTime = stopWatch.Elapsed.Milliseconds;

                        var dataQS = DataGenerator.GetData(dataType, numberOfElements);
                        stopWatch.Start();
                        _ = Sort.Sort.QuickSortMain(dataQS);
                        stopWatch.Stop();
                        results.QuickSortTime = stopWatch.Elapsed.Milliseconds;

                        csv.NextRecord();
                        csv.WriteRecord(results);
                    }

                    numberOfElements += step;
                } 
            }
        }

        public static void Exc2(int numberOfElements, int step)
        {
            var pivots = new List<string>() { "random", "right", "mid" };
            var stopWatch = new Stopwatch();

            using (StreamWriter output = File.CreateText("results2.csv"))
            using (CsvWriter csv = new CsvWriter(output, System.Globalization.CultureInfo.CurrentCulture))
            {
                csv.WriteHeader(typeof(Results2));
                csv.Configuration.NewLine = NewLine.LF;
                for (int i = 0; i < 15; i++)
                {
                    foreach (var pivot in pivots)
                    {
                        var results = new Results2();
                        results.NumberOfElements = numberOfElements;
                        results.Pivot = pivot;

                        var dataIS = DataGenerator.GetData("AShape", numberOfElements);
                        stopWatch.Start();
                        _ = Sort.Sort.QuickSortIterative(dataIS, pivot);
                        stopWatch.Stop();
                        results.Time = stopWatch.Elapsed.Milliseconds;

                        csv.NextRecord();
                        csv.WriteRecord(results);
                    }

                    numberOfElements += step;
                }
            }
        }

        static void Main(string[] args)
        {
            Exc1(1000, 250);
            Exc2(5000, 500);
        }
    }
}
