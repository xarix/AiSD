using NUnit.Framework;
using System;

namespace Sort.Test
{
    public class Tests
    {
 
        [TestCase(10000, Sort.RANDOM)]
        [TestCase(10000, Sort.ASCENDING)]
        [TestCase(10000, Sort.DESCENDING)]
        [TestCase(10000, Sort.ASHAPED)]
        [TestCase(10000, Sort.VSHAPED)]
        [TestCase(10000, Sort.CONSTANT)]
        public void InsertionSortTest(int n, string dataType)
        {
            var data = DataGenerator.GetData(dataType, n);
            var data2 = (int[])data.Clone();
            
            var sortedByIS = Sort.InsertionSort(data);
            Array.Sort(data2);

            Assert.AreEqual(sortedByIS, data2);
        }

        [TestCase(10000, Sort.RANDOM)]
        [TestCase(10000, Sort.ASCENDING)]
        [TestCase(10000, Sort.DESCENDING)]
        [TestCase(10000, Sort.ASHAPED)]
        [TestCase(10000, Sort.VSHAPED)]
        [TestCase(10000, Sort.CONSTANT)]
        public void SelectionSortTest(int n, string dataType)
        {
            var data = DataGenerator.GetData(dataType, n);
            var data2 = (int[])data.Clone();

            var sortedByIS = Sort.SelectionSort(data);
            Array.Sort(data2);

            Assert.AreEqual(sortedByIS, data2);

        }

        [TestCase(10000, Sort.RANDOM)]
        [TestCase(10000, Sort.ASCENDING)]
        [TestCase(10000, Sort.DESCENDING)]
        [TestCase(10000, Sort.ASHAPED)]
        [TestCase(10000, Sort.VSHAPED)]
        [TestCase(10000, Sort.CONSTANT)]
        public void HeapSortTest(int n, string dataType)
        {
            var data = DataGenerator.GetData(dataType, n);
            var data2 = (int[])data.Clone();

            var sortedByHS = Sort.HeapSort(data);
            Array.Sort(data2);

            Assert.AreEqual(sortedByHS, data2);
        }

        [TestCase(10000, Sort.RANDOM)]
        [TestCase(10000, Sort.ASCENDING)]
        [TestCase(10000, Sort.DESCENDING)]
        [TestCase(10000, Sort.ASHAPED)]
        [TestCase(10000, Sort.VSHAPED)]
        [TestCase(10000, Sort.CONSTANT)]
        public void QuickSortTest(int n, string dataType)
        {
            var data = DataGenerator.GetData(dataType ,n);
            var data2 = (int[])data.Clone();

            var sortedByQS = Sort.QuickSortMain(data);
            Array.Sort(data2);

            Assert.AreEqual(sortedByQS, data2);
        }

        [TestCase(10000, Sort.RANDOM, Sort.RANDOM)]
        [TestCase(10000, Sort.RANDOM, Sort.MIDDLE)]
        [TestCase(10000, Sort.RANDOM, Sort.RIGHT)]
        [TestCase(10000, Sort.ASCENDING, Sort.RANDOM)]
        [TestCase(10000, Sort.ASCENDING, Sort.MIDDLE)]
        [TestCase(10000, Sort.ASCENDING, Sort.RIGHT)]
        [TestCase(10000, Sort.DESCENDING, Sort.RANDOM)]
        [TestCase(10000, Sort.DESCENDING, Sort.RIGHT)]
        [TestCase(10000, Sort.DESCENDING, Sort.MIDDLE)]
        [TestCase(10000, Sort.ASHAPED, Sort.RANDOM)]
        [TestCase(10000, Sort.ASHAPED, Sort.RIGHT)]
        [TestCase(10000, Sort.ASHAPED, Sort.MIDDLE)]
        [TestCase(10000, Sort.VSHAPED, Sort.RANDOM)]
        [TestCase(10000, Sort.VSHAPED, Sort.RIGHT)]
        [TestCase(10000, Sort.VSHAPED, Sort.MIDDLE)]
        [TestCase(10000, Sort.CONSTANT, Sort.RANDOM)]
        [TestCase(10000, Sort.CONSTANT, Sort.MIDDLE)]
        [TestCase(10000, Sort.CONSTANT, Sort.RIGHT)]
        public void QuickSortIterativeTest(int n, string dataType, string pivot)
        {
            var data = DataGenerator.GetData(dataType, n);
            var data2 = (int[])data.Clone();

            var sortedByQSI = Sort.QuickSortIterative(data, pivot);
            Array.Sort(data2);

            Assert.AreEqual(sortedByQSI, data2);
        }
    }
}