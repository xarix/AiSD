using System.Diagnostics;
using System;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

namespace Lab4
{
    public class ShipLoadRaport
    {
        public int loadedContainersValue { get; set; }
        public int loadingTime { get; set; }
    }

    public class Ship
    {
        private readonly int _maxLoad;

        public Ship(int maxLoad) {
            _maxLoad = maxLoad;
        }

        public ShipLoadRaport OptimalLoadGreedy(List<Container> containers)
        {
            var result = new ShipLoadRaport();
            var stopwatch = new Stopwatch();
            var loadedWeight = 0;
            stopwatch.Start();
            containers = containers.OrderBy(c => (float)c.Weight / c.Value).ToList();
            foreach (var container in containers)
            {
                if (loadedWeight + container.Weight <= _maxLoad)
                {
                    loadedWeight += container.Weight;
                    result.loadedContainersValue += container.Value;
                }
                else
                {
                    break;
                }
            }
            stopwatch.Stop();
            result.loadingTime = (int)stopwatch.ElapsedMilliseconds;
            return result;
        }

        // Todo it is not working, needs to be fixed
        public ShipLoadRaport OptimalLoadDinamically(List<Container> containers)
        {
            var result = new ShipLoadRaport();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var maxLoadTable = new int[containers.Count + 1, _maxLoad + 1];
            for (var i = 0; i <= containers.Count; i++)
            {
                maxLoadTable[i, 0] = 0;
            }
            for (var j = 0; j <= _maxLoad; j++)
            {
                maxLoadTable[0, j] = 0;
            }
            for (var i = 1; i <= containers.Count; i++)
            {
                for (var j = 1; j <= _maxLoad; j++)
                {
                    if (containers[i - 1].Weight > j)
                    {
                        maxLoadTable[i, j] = maxLoadTable[i - 1, j];
                    }
                    else
                    {
                        if (maxLoadTable[i - 1, j] > containers[i - 1].Value + maxLoadTable[i - 1, j - containers[i - 1].Weight])
                        {
                            maxLoadTable[i, j] = maxLoadTable[i - 1, j];
                        }
                        else
                        {
                            maxLoadTable[i, j] = containers[i - 1].Value + maxLoadTable[i - 1, j - containers[i - 1].Weight];
                        }
                    }
                }
            }
            stopwatch.Stop();
            result.loadingTime = (int)stopwatch.ElapsedMilliseconds;
            return result;
        }
    }
}