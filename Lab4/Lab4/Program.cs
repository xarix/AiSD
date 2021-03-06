﻿using System;
using System.Diagnostics;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace Lab4
{
    public class Program
    {
        const string RESULTS_DIRECTORY = "../Results/";

        static void Main(string[] args)
        {
            GenerateResults(1000, 1000, 10000);
        }

        public static void GenerateResults(int start, int step, int stop)
        {
            var shipLoad = start;
            using (StreamWriter output = File.CreateText(RESULTS_DIRECTORY + "Raport.csv"))
            using (CsvWriter csv = new CsvWriter(output, System.Globalization.CultureInfo.CurrentCulture))
            {
                csv.Configuration.NewLine = NewLine.LF;
                csv.Configuration.Delimiter = ",";
                csv.WriteHeader(typeof(Results));
                while (shipLoad <= stop)
                {
                    Console.WriteLine("...generating raport for shipload " + shipLoad);
                    var ship = new Ship(shipLoad);
                    var allRandomData = DataGenerator.AllRandom(shipLoad / 3);
                    var randomValueStaticWeightData = DataGenerator.RandomValueStaticWeight(shipLoad / 3);
                    var staticValueRandomWeightData = DataGenerator.StaticValueRandomWeight(shipLoad / 3);

                    var greedyAllRandom = ship.OptimalLoadGreedy(allRandomData);
                    var dynamicAllRandom = ship.OptimalLoadDinamically(allRandomData);
                    var greedyRandomValueStaticWeight = ship.OptimalLoadGreedy(randomValueStaticWeightData);
                    var dynamicRandomValueStaticWeight = ship.OptimalLoadDinamically(randomValueStaticWeightData);
                    var greedyStaticValueRandomWeight = ship.OptimalLoadGreedy(randomValueStaticWeightData);
                    var dynamicStaticValueRandomWeight = ship.OptimalLoadDinamically(randomValueStaticWeightData);
                    try
                    {
                        var result = new Results
                        {
                            MaxShipLoad = shipLoad,
                            GreedyAllRandomQuality = greedyAllRandom.loadedContainersValue,
                            GreedyAllRandomTime = greedyAllRandom.loadingTime,
                            DynamicAllRandomQuality = dynamicAllRandom.loadedContainersValue,
                            DynamicAllRandomTime = dynamicAllRandom.loadingTime,
                            GreedyRandomValueStaticWeightQuality = greedyRandomValueStaticWeight.loadedContainersValue,
                            GreedyRandomValueStaticWeightTime = greedyRandomValueStaticWeight.loadingTime,
                            DynamicRandomValueStaticWeightQuality = dynamicRandomValueStaticWeight.loadedContainersValue,
                            DynamicRandomValueStaticWeightTime = dynamicRandomValueStaticWeight.loadingTime,
                            GreedyStaticValueRandomWeightQuality = greedyRandomValueStaticWeight.loadedContainersValue,
                            GreedyStaticValueRandomWeightTime = greedyRandomValueStaticWeight.loadingTime,
                            DynamicStaticValueRandomWeightQuality = dynamicStaticValueRandomWeight.loadedContainersValue,
                            DynamicStaticValueRandomWeightTime = dynamicStaticValueRandomWeight.loadingTime,
                            // TODO fix division by zero problem
                            RelativeErrorAllRandom = (dynamicAllRandom.loadedContainersValue - greedyAllRandom.loadedContainersValue) / (float)dynamicAllRandom.loadedContainersValue,
                            RelativeErrorRandomValueStaticWeight = (dynamicRandomValueStaticWeight.loadedContainersValue - greedyRandomValueStaticWeight.loadedContainersValue) / (float)dynamicRandomValueStaticWeight.loadedContainersValue,
                            RelativeErrorStaticValueRandomWeight = (dynamicStaticValueRandomWeight.loadedContainersValue - greedyStaticValueRandomWeight.loadedContainersValue) / (float)dynamicStaticValueRandomWeight.loadedContainersValue,
                        };
                        csv.NextRecord();
                        csv.WriteRecord(result);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message + shipLoad);
                    }
                    shipLoad += step;
                }
            }
        }
    }
}
