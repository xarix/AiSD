using System;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

namespace Lab4
{
    public class Ship
    {
        private readonly int _maxLoad;

        public Ship(int maxLoad) {
            _maxLoad = maxLoad;
        }

        public int OptimalLoadGreedy(List<Container> containers)
        {
            var loadedWeight = 0;
            containers = containers.OrderBy(c => (float)c.Weight / c.Value).ToList();
            foreach (var container in containers)
            {
                if (loadedWeight + container.Weight <= _maxLoad)
                {
                    loadedWeight += container.Weight;
                }
                else
                {
                    break;
                }
            }
            // Console.WriteLine(JsonSerializer.Serialize(containers));
            return loadedWeight;
        }

        // Todo it is not working, needs to be fixed
        public int OptimalLoadDinamically(List<Container> containers)
        {
            var maxLoadTable = new int[containers.Count + 1, _maxLoad + 1];
            for (var i = 0; i <= containers.Count; i++)
            {
                maxLoadTable[i, 0] = 0;
            }

            for (var j = 0; j <= _maxLoad; j++)
            {
                maxLoadTable[0, j] = 0;
            }

            for (var i = 0; i <= containers.Count; i++)
            {
                for (var j = 0; j <= _maxLoad; j++)
                {
                    if (containers[i].Weight > j)
                    {
                        maxLoadTable[i, j] = maxLoadTable[i - 1, j];
                    }
                    else
                    {
                        if (maxLoadTable[i - 1, j] > containers[i].Value + maxLoadTable[i - 1, j - containers[i].Weight])
                        {
                            maxLoadTable[i, j] = maxLoadTable[i - 1, j];
                        }
                        else
                        {
                            maxLoadTable[i, j] = containers[i].Value + maxLoadTable[i - 1, j - containers[i].Weight];
                        }
                    }
                }
            }
            return maxLoadTable[containers.Count, _maxLoad];
        }
    }
}