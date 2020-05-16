using System.Collections;
using System.Linq;
using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Diagnostics;
using System.IO;

namespace Lab3
{
    class Program
    {
        private const string FIRST = "First";
        private const string SECOND = "Fecond";
        const string RESULTS_DIRECTORY = "../Results/";
        
        static void Main(string[] args)
        {
            CreateRaport(6, 1, 15, 0.3, FIRST);
            CreateRaport(6, 1, 15, 0.7, FIRST);
            CreateRaport(6, 2, 10, 0.5, SECOND);
        }

        public static void CreateRaport(int start, int step, int numberOfSteps, double saturation, string typeOfRaport)
        {
            using (StreamWriter output = File.CreateText(RESULTS_DIRECTORY + typeOfRaport + (saturation * 100).ToString() + DateTime.Now.ToString() + ".csv"))
            using (CsvWriter csv = new CsvWriter(output, System.Globalization.CultureInfo.CurrentCulture))
            {
                
                csv.Configuration.NewLine = NewLine.LF;
                csv.Configuration.Delimiter = ",";
                if (typeOfRaport == FIRST)
                {
                    csv.WriteHeader(typeof(FirstExcerciseResults));
                    for (int i = 0; i < numberOfSteps; i++)
                    {
                        var stopwatch = new Stopwatch();
                        stopwatch.Start();
                        var hamiltonTimes = new int[11];
                        for (int j = 0; j < 11; j++)
                        {
                            hamiltonTimes[j] = new EulerGraph(start + (i * step), saturation).MeasureTime(EulerGraph.HAMILTON_CYCLE);
                        }
                        Array.Sort(hamiltonTimes);
                        Console.WriteLine(string.Join(", ", hamiltonTimes));
                        var graph = new EulerGraph(start + (i * step), saturation);
                        var result = new FirstExcerciseResults
                        {
                            NumberOfVertices = start + (i * step),
                            HamiltonCycle = hamiltonTimes[5], // Median from 11 results
                            EulerCycle = graph.MeasureTime(EulerGraph.EULER_CYCLE),
                        };
                        csv.NextRecord();
                        csv.WriteRecord(result);
                        stopwatch.Stop();
                        Console.WriteLine(stopwatch.Elapsed);
                    }
                }
                else if (typeOfRaport == SECOND)
                {
                    csv.WriteHeader(typeof(SecondExcerciseResults));
                    for (int i = 0; i < numberOfSteps; i++)
                    {
                        var stopwatch = new Stopwatch();
                        stopwatch.Start();
                        var graph = new EulerGraph(start + (i * step), saturation);
                        var result = new SecondExcerciseResults
                        {
                            NumberOfVertices = start + (i * step),
                            Time = graph.MeasureTime(EulerGraph.ALL_HAMILTON_CYCLES),
                        };
                        csv.NextRecord();
                        csv.WriteRecord(result);
                        stopwatch.Stop();
                        Console.WriteLine(stopwatch.Elapsed);
                    }
                }
            }
        }
    }
}
