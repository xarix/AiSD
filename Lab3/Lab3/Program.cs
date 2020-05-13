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
            // todo add a message
            Console.Write(
                "\n" +
                "================================================================\n" +
                "\n"
                );
            
            CreateRaport(10);
        }

        public static void CreateRaport(int verticeNumberMultiplier)
        {
            using (StreamWriter output = File.CreateText(RESULTS_DIRECTORY + "results.csv"))
            using (CsvWriter csv = new CsvWriter(output, System.Globalization.CultureInfo.CurrentCulture))
            {
                csv.Configuration.NewLine = NewLine.LF;
                csv.Configuration.Delimiter = ",";
                csv.WriteHeader(typeof(Results));
                for (int i = 1; i <= 15; i++)
                {
                    var stopwatch = new Stopwatch();
                    var graph30 = new EulerGraph(i * verticeNumberMultiplier, 0.3);
                    var graph70 = new EulerGraph(i * verticeNumberMultiplier, 0.7);
                    var result = new Results
                    {
                        NumberOfVertices = verticeNumberMultiplier * i,
                        Euler30 = graph30.MeasureTime(EulerGraph.EULER_CYCLE),
                        Euler70 = graph70.MeasureTime(EulerGraph.EULER_CYCLE),
                        Hamilton30 = graph30.MeasureTime(EulerGraph.HAMILTON_CYCLE),
                        Hamilton70 = graph70.MeasureTime(EulerGraph.HAMILTON_CYCLE)
                    };
                    csv.NextRecord();
                    csv.WriteRecord(result);
                }
            }
        }
    }
}
