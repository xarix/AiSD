﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Lab3
{
    public class EulerGraph
    {
        public const string EULER_CYCLE = "EulerCycle";
        public const string HAMILTON_CYCLE = "HamiltonCycle";
        public const string ALL_HAMILTON_CYCLES = "AllHamiltonCycles";
        private int[][] matrix;
        private Dictionary<int, int> deg = new Dictionary<int, int>();
        public readonly int _numberOfVertices;

        public EulerGraph(int numberOfVertices)
        {
            matrix = new int[numberOfVertices][];
            for (int i = 0; i < numberOfVertices; i++)
            {
                matrix[i] = new int[numberOfVertices];
            }

            _numberOfVertices = numberOfVertices;
        }

        

        public int MeasureTime(string algorithm)
        {
            int[] visitedVertices = new int[_numberOfVertices];
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            switch (algorithm)
            {
                case EulerGraph.EULER_CYCLE:
                    EulerCycle.FindEulerCycle(this, 1);
                    break;
                case EulerGraph.HAMILTON_CYCLE:
                    visitedVertices.Select(vertice => vertice = -1);
                    HamiltonCycle.FindHamiltonCycle(this, visitedVertices);
                    break;
                case EulerGraph.ALL_HAMILTON_CYCLES:
                    visitedVertices.Select(vertice => vertice = -1);
                    HamiltonCycle.FindAllHamiltonCycles(this, visitedVertices);
                    break;
            }
            stopwatch.Stop();
            return (int)stopwatch.ElapsedMilliseconds;
        }
        public void MeetSaturationGoal(double saturation)
        {
            CreateCycle(_numberOfVertices);
            var currentSaturation = (double)_numberOfVertices / (_numberOfVertices * (_numberOfVertices - 1) / 2);
            //use 3 as in every step 3 edges are being added 
            double saturationStep = 3 / ((double)_numberOfVertices * (_numberOfVertices - 1) / 2);
            while (currentSaturation < saturation)
            {
                var triplet = FindTriplet();

                AddEdge(triplet.Item1, triplet.Item2);
                AddEdge(triplet.Item2, triplet.Item3);
                AddEdge(triplet.Item3, triplet.Item1);

                currentSaturation += saturationStep;
            }
        }

        /// <summary>
        /// Returns 3 vertices between a cycle can be created, if such group doesn't exist expception will be thrown
        /// </summary>
        public Tuple<int, int, int> FindTriplet()
        {
            var list = deg.OrderBy(x => x.Value)
                       .Select(x => x.Key)
                       .ToList();
            int a = 0, b = 0, c = 0;
            var found = false;
            foreach (var curr in list)
            {
                if (found)
                    break;

                for (int i = 0; i < _numberOfVertices; i++)
                {
                    if (found)
                        break;
                    if (!found && i != curr && !IsEdgeExists(curr, i))
                    {
                        for (int j = 0; j < _numberOfVertices; j++)
                        {
                            if (j != curr && j != i && !IsEdgeExists(i, j) && !IsEdgeExists(j, curr))
                            {
                                a = curr;
                                b = i;
                                c = j;
                                found = true;
                                break;
                            }
                        }
                    }
                }
            }
            
            if (!found)
            {

                throw new InvalidOperationException("Graph doesn't contain 3 vertices which can be combained into a cycle");
            }

            return new Tuple<int, int, int>(a, b, c);
        }

        public void CreateCycle(int numberOfVertices)
        {
            var vertices = new List<int>();
            for (int i = 0; i < numberOfVertices; i++)
            {
                vertices.Add(i);
            }
            Shuffle(vertices);

            for (int i = 0; i < numberOfVertices - 1; i++)
            {
                AddEdge(vertices[i], vertices[i + 1]);
            }
            AddEdge(vertices[0], vertices[numberOfVertices - 1]);
        }

        public void AddEdge(int a, int b)
        {
            if (matrix[a][b] == 1)
                throw new Exception("Edge exists");
            matrix[a][b] = 1;
            matrix[b][a] = 1;
            if (!deg.ContainsKey(a))
                deg.Add(a, 0);
            if (!deg.ContainsKey(b))
                deg.Add(b, 0);
            deg[a]++;
            deg[b]++;
        }

        public void RemoveEdge(int a, int b)
        {
            matrix[a][b] = 0;
            matrix[b][a] = 0;
            deg[a]--;
            deg[b]--;
        }
        
        public bool IsEdgeExists(int a, int b)
        {
            return matrix[a][b] == 1;
        }

        public List<int> GetNeighbours(int vertex)
        {
            return matrix[vertex].Select((v, i) => new { v, i })
                    .Where(x => x.v == 1)
                    .Select(x => x.i)
                    .ToList();
        }

        public void Print()
        {
            for (int i = 0; i < _numberOfVertices; i++)
            {
                for (int j = 0; j < _numberOfVertices; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }
                Console.WriteLine();
            }
        }

        private void Shuffle(List<int> list)
        {
            var rand = new Random();
            var index = 0;
            var tmp = 0;
            for (var i = 0; i < list.Count; i++)
            {
                index = rand.Next(0, list.Count);
                tmp = list[i];
                list[i] = list[index];
                list[index] = tmp;
            }
        }
    }
}
