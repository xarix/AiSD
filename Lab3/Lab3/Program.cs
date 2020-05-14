using System.Linq;
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
            CreateRaport(10, EulerGraph.EULER_CYCLE);
            CreateRaport(10, EulerGraph.HAMILTON_CYCLE);
        }

        public static void CreateRaport(int verticeNumberMultiplier, string cycleType)
        {
            using (StreamWriter output = File.CreateText(RESULTS_DIRECTORY + cycleType + "Results" + DateTime.Now.ToString() + ".csv"))
            using (CsvWriter csv = new CsvWriter(output, System.Globalization.CultureInfo.CurrentCulture))
            {
                csv.Configuration.NewLine = NewLine.LF;
                csv.Configuration.Delimiter = ",";
                csv.WriteHeader(typeof(Results));
                for (int i = 1; i <= 15; i++)
                {
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();
                    var graph30 = new EulerGraph(i * verticeNumberMultiplier, 0.3);
                    var graph70 = new EulerGraph(i * verticeNumberMultiplier, 0.7);
                    var result = new Results
                    {
                        NumberOfVertices = verticeNumberMultiplier * i,
                        Graph30 = graph30.MeasureTime(cycleType),
                        Graph70 = graph70.MeasureTime(cycleType),
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
