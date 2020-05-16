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
        const string RESULTS_DIRECTORY = "../Results/";
        
        static void Main(string[] args)
        {
            CreateRaport(6, 2, 0.3);
            CreateRaport(6, 2, 0.7);
        }

        public static void CreateRaport(int start, int step, double saturation)
        {
            using (StreamWriter output = File.CreateText(RESULTS_DIRECTORY + "ResultsFor" + (saturation * 100).ToString() + "PercentSaturation" + DateTime.Now.ToString() + ".csv"))
            using (CsvWriter csv = new CsvWriter(output, System.Globalization.CultureInfo.CurrentCulture))
            {
                csv.Configuration.NewLine = NewLine.LF;
                csv.Configuration.Delimiter = ",";
                csv.WriteHeader(typeof(Results));
                for (int i = 0; i < 15; i++)
                {
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();
                    var graph = new EulerGraph(start + (i * step), saturation);
                    var result = new Results
                    {
                        NumberOfVertices = start + (i * step),
                        HamiltonCycle = graph.MeasureTime(EulerGraph.HAMILTON_CYCLE), // Euler alg removes some edges so Hamilton needs to be first
                        EulerCycle = graph.MeasureTime(EulerGraph.EULER_CYCLE),
                    };
                    stopwatch.Stop();
                    csv.NextRecord();
                    csv.WriteRecord(result);
                    Console.WriteLine(i + " " + stopwatch.Elapsed);
                }
            }
        }
    }
}
