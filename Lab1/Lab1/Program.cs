using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Lab1
{
    class Program
    {
        const string RESULTS_DIRECTORY = "../results/";

        private static int MeasureSortingTime(int[] data, string algorithm)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            _ = Sort.SortArray(data, algorithm);
            stopWatch.Stop();
            return (int)stopWatch.ElapsedMilliseconds;
        }

        static void CompareByDataType(int start, int step, int stop)
        {
            int numberOfElements;
            var dataTypes = new List<string>()
            {
                Sort.DESCENDING,
                Sort.ASCENDING,
                Sort.ASHAPED,
                Sort.VSHAPED,
                Sort.RANDOM,
                Sort.CONSTANT
            };
            foreach (var dataType in dataTypes)
            {
                numberOfElements = start;
                using (StreamWriter output = File.CreateText(RESULTS_DIRECTORY + "by_data_type/" + dataType.ToLower() + ".csv"))
                using (CsvWriter csv = new CsvWriter(output, System.Globalization.CultureInfo.CurrentCulture))
                {
                    csv.WriteHeader(typeof(CompareByDataTypeResults));
                    csv.Configuration.NewLine = NewLine.LF;
                    csv.Configuration.Delimiter = ",";
                    while (numberOfElements <= stop)
                    {
                        var data = DataGenerator.GetData(dataType, numberOfElements);
                        var results = new CompareByDataTypeResults()
                        {
                            NumberOfElements = numberOfElements,
                            SelectionSortTime = MeasureSortingTime(data, Sort.SELECTION),
                            InsertionSortTime = MeasureSortingTime(data, Sort.INSERTION),
                            HeapSortTime = MeasureSortingTime(data, Sort.HEAP),
                            QuickSortRecursiveTime = MeasureSortingTime(data, Sort.QUICKSORT_RECURSIVE)
                        };
                        csv.NextRecord();
                        csv.WriteRecord(results);
                        numberOfElements += step;
                    }
                }
            }
        }

        static void CompareByAlgorithm(int start, int step, int stop)
        {
            int numberOfElements;
            var algorithms = new List<string>()
            {
                Sort.INSERTION,
                Sort.SELECTION,
                Sort.HEAP,
                Sort.QUICKSORT_RECURSIVE
            };
            foreach (var algorithm in algorithms)
            {
                numberOfElements = start;
                using (StreamWriter output = File.CreateText(RESULTS_DIRECTORY + "by_algorithm/" + algorithm.ToLower() + ".csv"))
                using (CsvWriter csv = new CsvWriter(output, System.Globalization.CultureInfo.CurrentCulture))
                {
                    csv.WriteHeader(typeof(CompareByAlgorithmResults));
                    csv.Configuration.NewLine = NewLine.LF;
                    csv.Configuration.Delimiter = ",";
                    while (numberOfElements <= stop)
                    {
                        var results = new CompareByAlgorithmResults()
                        {
                            NumberOfElements = numberOfElements,
                            Ascending = MeasureSortingTime(DataGenerator.GetData(Sort.ASCENDING, numberOfElements), algorithm),
                            Descending = MeasureSortingTime(DataGenerator.GetData(Sort.DESCENDING, numberOfElements), algorithm),
                            AShaped = MeasureSortingTime(DataGenerator.GetData(Sort.ASHAPED, numberOfElements), algorithm),
                            VShaped = MeasureSortingTime(DataGenerator.GetData(Sort.VSHAPED, numberOfElements), algorithm),
                            Random = MeasureSortingTime(DataGenerator.GetData(Sort.RANDOM, numberOfElements), algorithm),
                            Constant = MeasureSortingTime(DataGenerator.GetData(Sort.CONSTANT, numberOfElements), algorithm),
                        };
                        csv.NextRecord();
                        csv.WriteRecord(results);
                        numberOfElements += step;
                    }
                }
            }
        }

        static void CompareQuickSortPivotTypesForAShapedData(int start, int step, int stop) {
            int numberOfElements = start;
            using (StreamWriter output = File.CreateText(RESULTS_DIRECTORY + "quicksort/quicksort_pivots.csv"))
            using (CsvWriter csv = new CsvWriter(output, System.Globalization.CultureInfo.CurrentCulture))
            {
                csv.WriteHeader(typeof(CompareQuicSortResults));
                csv.Configuration.NewLine = NewLine.LF;
                csv.Configuration.Delimiter = ",";
                while (numberOfElements <= stop)
                {
                    var data = DataGenerator.GetData(Sort.ASHAPED, numberOfElements);
                    var results = new CompareQuicSortResults()
                    {
                        NumberOfElements = numberOfElements,
                        Right = MeasureSortingTime(data, Sort.QUICKSORT_RIGHT),
                        Middle = MeasureSortingTime(data, Sort.QUICKSORT_MIDDLE),
                        Random = MeasureSortingTime(data, Sort.QUICKSORT_RANDOM),
                    };
                    csv.NextRecord();
                    csv.WriteRecord(results);
                    numberOfElements += step;
                }
            }
        }

        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();

            stopWatch.Reset();
            stopWatch.Start();
            CompareByAlgorithm(1000, 1000, 10000);
            stopWatch.Stop();
            Console.WriteLine("CompareByAlgorithm(): " + stopWatch.Elapsed);

            stopWatch.Reset();
            stopWatch.Start();
            CompareByDataType(1000, 1000, 10000);
            stopWatch.Stop();
            Console.WriteLine("CompareByDataType(): "+stopWatch.Elapsed);

            stopWatch.Reset();
            stopWatch.Start();
            CompareQuickSortPivotTypesForAShapedData(1000, 1000, 10000);
            stopWatch.Stop();
            Console.WriteLine("CompareQuickSortPivotTypesForAShapedData(): " + stopWatch.Elapsed);
        }
    }
}
