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

        private static bool HamiltonCycleUtil(EulerGraph graph, int[] cycle, int position)
        {
            if (position == cycle.Length)
            {
                if (graph.IsEdgeExists(cycle[0], cycle[position - 1])) return true;
                else return false;
            }

            for (int i = 1; i < graph.nbrOfVertices; i++)
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
