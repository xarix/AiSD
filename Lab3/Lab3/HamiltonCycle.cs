using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public static class HamiltonCycle
    {

        /// <summary>
        /// Values in a cycle should be different than any vertex in a given graph
        /// </summary>
        public static bool FindHamiltonCycle(EulerGraph graph, int[] cycle)
        {
            cycle[0] = 0;
            if (!HamiltonCycleUtil(graph, cycle, 1))
            {
                return false;
            }
            return true;
        }

        public static int FindAllHamiltonCycles(EulerGraph graph, int[] cycle)
        {
            cycle[0] = 0;
            int numberOfCycles = 0;
            HamiltonAllCycles(graph, cycle, 1, ref numberOfCycles);
            return numberOfCycles;
        }

        private static int HamiltonAllCycles(EulerGraph graph, int[] cycle, int position, ref int numberOfCycles)
        {
            if (position == cycle.Length)
            {
                if (graph.IsEdgeExists(cycle[0], cycle[position - 1]))
                {
                    // Console.WriteLine(string.Join(", ", cycle));
                    return 1;
                }
            }

            for (int i = 1; i < graph._numberOfVertices; i++)
            {
                if (IsSafe(i, position, cycle, graph))
                {
                    cycle[position] = i;
                    if (HamiltonAllCycles(graph, cycle, position + 1, ref numberOfCycles) == 1)
                    {
                        numberOfCycles++;
                    }
                    cycle[position] = -1;
                }
            }

            return 0;
        }

        private static bool HamiltonCycleUtil(EulerGraph graph, int[] cycle, int position)
        {
            if (position == cycle.Length)
            {
                if (graph.IsEdgeExists(cycle[0], cycle[position - 1])) return true;
                else return false;
            }

            for (int i = 1; i < graph._numberOfVertices; i++)
            {
                if (IsSafe(i, position, cycle, graph))
                {
                    cycle[position] = i;
                    if (HamiltonCycleUtil(graph, cycle, position + 1))
                    {
                        return true;
                    }
                    cycle[position] = -1;
                }
            }

            return false;
        }

        private static bool IsSafe(int v, int position, int[] cycle, EulerGraph graph)
        {
            if (!graph.IsEdgeExists(v, position - 1))
            {
                return false;
            }
            foreach (var vertex in cycle)
            {
                if (vertex == v)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
