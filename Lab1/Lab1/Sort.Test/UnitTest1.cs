using NUnit.Framework;
using System;

namespace Sort.Test
{
    public class Tests
    {
 
        [TestCase(1000)]
        public void InsertionSortTest(int n)
        {
            var data = DataGenerator.Descending(n);
            var data2 = (int[])data.Clone();
            
            var sortedByIS = Sort.InsertionSort(data);
            Array.Sort(data2);

            Assert.AreEqual(sortedByIS, data2);
        }

        [TestCase(1000)]
        public void SelectionSortTest(int n)
        {
            var data = DataGenerator.Random(n);
            var data2 = (int[])data.Clone();

            var sortedByIS = Sort.SelectionSort(data);
            Array.Sort(data2);

            Assert.AreEqual(sortedByIS, data2);

        }

        [TestCase(1000)]
        public void HeapSortTest(int n)
        {
            var data = DataGenerator.Random(n);
            var data2 = (int[])data.Clone();

            var sortedByHS = Sort.HeapSort(data);
            Array.Sort(data2);

            Assert.AreEqual(sortedByHS, data2);
        }

        [TestCase(1000)]
        public void QuickSortTest(int n)
        {
            var data = DataGenerator.Random(n);
            var data2 = (int[])data.Clone();

            var sortedByQS = Sort.QuickSortMain(data);
            Array.Sort(data2);

            Assert.AreEqual(sortedByQS, data2);
        }
    }
}