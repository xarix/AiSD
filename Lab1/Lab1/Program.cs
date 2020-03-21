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
        const string RESULTS_DIRECTORY = "../results/";
        private static int MeasureSortingTime(string dataType, string algorithm, int numberOfElements) {
            var stopWatch = new Stopwatch();
            var data = DataGenerator.GetData(dataType, numberOfElements);
            stopWatch.Start();
            _ = Sort.Sort.SortArray(data, algorithm);
            stopWatch.Stop();
            return stopWatch.Elapsed.Milliseconds;
        }
        static void CompareByDataType(int start, int step, int stop) {
            int numberOfElements;
            var dataTypes = new List<string>() {"Desc", "Asc", "AShape", "VShape", "Random", "Const"};
            foreach (var dataType in dataTypes)
            {
                numberOfElements = start;
                using (StreamWriter output = File.CreateText(RESULTS_DIRECTORY + "by_data_type/" + dataType.ToLower() + ".csv"))
                using (CsvWriter csv = new CsvWriter(output, System.Globalization.CultureInfo.CurrentCulture))
                {
                    csv.WriteHeader(typeof(CompareByDataTypeResults));
                    csv.Configuration.NewLine = NewLine.LF;
                    csv.Configuration.Delimiter = ",";
                    while (numberOfElements <= stop) {
                        var results = new CompareByDataTypeResults() {
                            NumberOfElements = numberOfElements,
                            SelectionSortTime = MeasureSortingTime(dataType, Sort.Sort.SELECTION, numberOfElements),
                            InsertionSortTime = MeasureSortingTime(dataType, Sort.Sort.INSERTION, numberOfElements),
                            HeapSortTime = MeasureSortingTime(dataType, Sort.Sort.HEAP, numberOfElements),
                            QuickSortTime = MeasureSortingTime(dataType, Sort.Sort.QUICKSORT_RANDOM, numberOfElements)
                        };
                        csv.NextRecord();
                        csv.WriteRecord(results);
                        numberOfElements += step;
                    }
                }
            }
        }

        static void CompareByAlgorithm(int start, int step, int stop) {
            int numberOfElements;
            var algorithms = new List<string>() {"Insertion", "Selection", "Heap", "QuickMiddle"};
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
                            Ascending = MeasureSortingTime("Asc", algorithm, numberOfElements),
                            Descending = MeasureSortingTime("Desc", algorithm, numberOfElements),
                            AShaped = MeasureSortingTime("AShape", algorithm, numberOfElements),
                            VShaped = MeasureSortingTime("VShape", algorithm, numberOfElements),
                            Random = MeasureSortingTime("Random", algorithm, numberOfElements),
                            Constant = MeasureSortingTime("Const", algorithm, numberOfElements),
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
                    var results = new CompareQuicSortResults()
                    {
                        NumberOfElements = numberOfElements,
                        Right = MeasureSortingTime("AShape", "QuickRight", numberOfElements),
                        Middle = MeasureSortingTime("AShape", "QuickMiddle", numberOfElements),
                        Random = MeasureSortingTime("AShape", "QuickRandom", numberOfElements),
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
            CompareByAlgorithm(1000, 1000, 20000);
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);

            stopWatch.Reset();
            stopWatch.Start();
            CompareByDataType(1000, 1000, 20000);
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);

            stopWatch.Reset();
            stopWatch.Start();
            CompareQuickSortPivotTypesForAShapedData(1000, 1000, 20000);
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
        }
    }
}
