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
            Console.Write("Do you want to use data from file? [y/n]: ");
            var r = Console.ReadKey();
            Console.WriteLine();
            switch (r.Key.ToString())
            {
                case "Y":
                    CreateReportFromFile();
                    break;
                case "N":
                    CreateRaport(6, 1, 15, 0.3, FIRST);
                    CreateRaport(6, 1, 15, 0.7, FIRST);
                    CreateRaport(6, 2, 10, 0.5, SECOND);
                    break;
                default:
                    break;
            }
            
        }

        public static void CreateReportFromFile()
        {
            int[][] matrix = File.ReadAllLines("a.txt")
                   .Select(l => l.Split(' ').Select(i => int.Parse(i)).ToArray())
                   .ToArray();
            var graph = new EulerGraph(matrix.Length);

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (matrix[i][j] != 0)
                        graph.AddEdge(i, j);
                }
            }
            var cycle = new int[graph._numberOfVertices];
            for (int i = 0; i < cycle.Length; i++)
            {
                cycle[i] = -1;
            }

            Console.WriteLine($"All Hamilton cycles");
            HamiltonCycle.FindAllHamiltonCycles(graph, cycle, true);

            Console.WriteLine($"Euler cycle: ");
            var eulerCycle = EulerCycle.FindEulerCycle(graph, 0);
            foreach (var item in eulerCycle)
            {
                Console.Write(item + " ");
            }
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
                            var graphHamilton = new EulerGraph(start + (i * step));
                            graphHamilton.MeetSaturationGoal(saturation);
                            hamiltonTimes[j] = graphHamilton.MeasureTime(EulerGraph.HAMILTON_CYCLE);
                        }
                        Array.Sort(hamiltonTimes);
                        Console.WriteLine(string.Join(", ", hamiltonTimes));
                        var graph = new EulerGraph(start + (i * step));
                        graph.MeetSaturationGoal(saturation);
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
                        var graph = new EulerGraph(start + (i * step));
                        graph.MeetSaturationGoal(saturation);
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
