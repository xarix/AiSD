﻿using System.Collections;
using CsvHelper;
using CsvHelper.Configuration;
using System.Diagnostics;
using System;
using System.IO;
using System.Collections.Generic;

namespace Lab2
{
    class Program
    {
        const string RESULTS_DIRECTORY = "../Results/";

        static void Main(string[] args)
        {
            Console.Write(
                "\n" +
                "================================================================\n" +
                "BST and Linked List comparison raport program\n" +
                "made by Maciej Frel and Marcin Duda\n" +
                "\n" +
                "Do you want to use data from file? [y/n]: "
                );
            if (Console.Read() == (int)'y')
            {
                var data = new List<int>();
                using (StreamReader sr = File.OpenText("../Input/bst.txt"))
                {
                    string s = String.Empty;
                    while ((s = sr.ReadLine()) != null)
                    {
                        data.Add(int.Parse(s));
                    }
                }
                ShowResultsUsingFileData(data);
            }
            else
            {
                uint start = ReadNumberFromConsole("Starting point number");
                uint step = ReadNumberFromConsole("Step number");
                uint stop = ReadNumberFromConsole("End point number");
                Console.Write(
                    "\n" +
                    "================================================================\n" +
                    "BST and Sorted Linked List speed comparison\n" +
                    "\n"
                    );

                CompareInsertSearchDestroy(start, step, stop);

                Console.Write(
                    "\n" +
                    "================================================================\n" +
                    "Regular BST and AVL tree height comparison\n" +
                    "\n"
                    );
                
                CompareTreeHeights(start, step, stop);

                Console.Write(
                "\n" +
                "================================================================\n" +
                "\n"
                );
            }
        }

        static void ShowResultsUsingFileData(List<int> data)
        {
            Console.Write(
                "\n" +
                "================================================================\n" +
                "Data: "
                );
            for (int i = 0; i < data.Count; i++)
            {
                Console.Write(data[i] + ", ");
            }
            Console.Write("\n");
            var bst = new BST(data);
            var linkedList = new SortedLinkedList(data);
            Console.Write(
                "================================================================\n" +
                "Height: " + bst.Height().ToString() + "\n" +
                "Postorder: "
            );
            bst.PrintPostorder();
            Console.Write(
                "\n" +
                "Far right element value: "
            );
            bst.PrintFarRightElement();
            Console.Write(
                "================================================================\n"
            );
        }

        static void CompareInsertSearchDestroy(uint start, uint step, uint stop)
        {
            uint numberOfElements = start;

            using (StreamWriter output = File.CreateText(RESULTS_DIRECTORY + "BST_LinkedList_Speed.csv"))
            using (CsvWriter csv = new CsvWriter(output, System.Globalization.CultureInfo.CurrentCulture))
            {
                csv.Configuration.NewLine = NewLine.LF;
                csv.Configuration.Delimiter = ",";
                csv.WriteHeader(typeof(AccessTimeComparisonResults));
                Console.WriteLine(AccessTimeComparisonResults.HeaderToString());
                while (numberOfElements <= stop)
                {
                    // var stopwatch = new Stopwatch();
                    // stopwatch.Start();
                    var data = DataGenerator.UniqueArray(numberOfElements);
                    var bst = new BST();
                    var linkedList = new SortedLinkedList();
                    var result = new AccessTimeComparisonResults
                    {
                        NumberOfElements = numberOfElements,
                        BSTInsert = bst.MeasureInsertTime(data),
                        LinkedListInsert = linkedList.MeasureInsertTime(data),
                        BSTSearch = bst.MeasureSearchTime(data),
                        LinkedListSearch = linkedList.MeasureSearchTime(data),
                        BSTDestroy = bst.MeasureDestroyTime(),
                        LinkedListDestroy = linkedList.MeasureDestroyTime()
                    };
                    Console.WriteLine(result.DataToString());
                    csv.NextRecord();
                    csv.WriteRecord(result);
                    // stopwatch.Stop();
                    // Console.WriteLine("raport row #" + (((numberOfElements - start) / step) + 1) + stopwatch.Elapsed);
                    numberOfElements += step;
                }
            }
        }

        static void CompareTreeHeights(uint start, uint step, uint stop)
        {
            uint numberOfElements = start;

            using (StreamWriter output = File.CreateText(RESULTS_DIRECTORY + "BST_AVL_Tree_Height.csv"))
            using (CsvWriter csv = new CsvWriter(output, System.Globalization.CultureInfo.CurrentCulture))
            {
                csv.Configuration.NewLine = NewLine.LF;
                csv.Configuration.Delimiter = ",";
                csv.WriteHeader(typeof(TreeHeightComparisonResults));
                Console.WriteLine(TreeHeightComparisonResults.HeaderToString());
                while (numberOfElements <= stop)
                {
                    // var stopwatch = new Stopwatch();
                    // stopwatch.Start();
                    var data = DataGenerator.UniqueArray(numberOfElements);
                    var bst = new BST(data);
                    var bstHeight = bst.Height();
                    bst.BuildAVL();
                    var avlHeight = bst.Height();
                    var result = new TreeHeightComparisonResults
                    {
                        NumberOfElements = numberOfElements,
                        BSTHeight = bstHeight,
                        AVLHeight = avlHeight
                    };
                    Console.WriteLine(result.DataToString());
                    csv.NextRecord();
                    csv.WriteRecord(result);
                    // stopwatch.Stop();
                    // Console.WriteLine("raport row #" + (((numberOfElements - start) / step) + 1) + stopwatch.Elapsed);
                    numberOfElements += step;
                }
            }
        }
       
        private static uint ReadNumberFromConsole(string consoleMessage) {
            Console.Write(consoleMessage + ": ");
            return ReadNumberFromConsole();
        }

        private static uint ReadNumberFromConsole()
        {
            uint result;
            while (!uint.TryParse(Console.ReadLine(), out result) || result == 0) {
                Console.Write("Invalid value, type a number: ");
            }
            return result;
        }
    }
}
