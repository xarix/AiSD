using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    public static class EulerCycle
    {
        public static List<int> FindEulerCycle(EulerGraph graph, int start)
        {
            var cycle = new Stack<int>();
            var stack = new Stack<int>();
            var vertex = start;
            stack.Push(vertex);

            while (stack.Count > 0)
            {
                var neighbours = graph.GetNeighbours(vertex);
                if (neighbours.Count == 0)
                {
                    cycle.Push(stack.Pop());
                    if (stack.Count == 0)
                        break;
                    vertex = stack.Peek();
                    continue;
                }
                var minVertex = neighbours.Min();
                graph.RemoveEdge(vertex, minVertex);
                stack.Push(minVertex);
                vertex = minVertex;
            }

            return cycle.ToList();
        }
    }
}
