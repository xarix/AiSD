using NUnit.Framework;
using System;

namespace Sort.Test
{
    public class Tests
    {
 
        [TestCase(10000, "Random")]
        [TestCase(10000, "Asc")]
        [TestCase(10000, "Desc")]
        [TestCase(10000, "AShape")]
        [TestCase(10000, "VShape")]
        [TestCase(10000, "Const")]
        public void InsertionSortTest(int n, string dataType)
        {
            var data = DataGenerator.GetData(dataType, n);
            var data2 = (int[])data.Clone();
            
            var sortedByIS = Sort.InsertionSort(data);
            Array.Sort(data2);

            Assert.AreEqual(sortedByIS, data2);
        }

        [TestCase(10000, "Random")]
        [TestCase(10000, "Asc")]
        [TestCase(10000, "Desc")]
        [TestCase(10000, "AShape")]
        [TestCase(10000, "VShape")]
        [TestCase(10000, "Const")]
        public void SelectionSortTest(int n, string dataType)
        {
            var data = DataGenerator.GetData(dataType, n);
            var data2 = (int[])data.Clone();

            var sortedByIS = Sort.SelectionSort(data);
            Array.Sort(data2);

            Assert.AreEqual(sortedByIS, data2);

        }

        [TestCase(10000, "Random")]
        [TestCase(10000, "Asc")]
        [TestCase(10000, "Desc")]
        [TestCase(10000, "AShape")]
        [TestCase(10000, "VShape")]
        [TestCase(10000, "Const")]
        public void HeapSortTest(int n, string dataType)
        {
            var data = DataGenerator.GetData(dataType, n);
            var data2 = (int[])data.Clone();

            var sortedByHS = Sort.HeapSort(data);
            Array.Sort(data2);

            Assert.AreEqual(sortedByHS, data2);
        }

        [TestCase(10000, "Random")]
        [TestCase(10000, "Asc")]
        [TestCase(10000, "Desc")]
        [TestCase(10000, "AShape")]
        [TestCase(10000, "VShape")]
        [TestCase(10000, "Const")]
        public void QuickSortTest(int n, string dataType)
        {
            var data = DataGenerator.GetData(dataType ,n);
            var data2 = (int[])data.Clone();

            var sortedByQS = Sort.QuickSortMain(data);
            Array.Sort(data2);

            Assert.AreEqual(sortedByQS, data2);
        }

        [TestCase(10000, "Random", "random")]
        [TestCase(10000, "Random", "mid")]
        [TestCase(10000, "Random", "right")]
        [TestCase(10000, "Asc", "random")]
        [TestCase(10000, "Asc", "mid")]
        [TestCase(10000, "Asc", "right")]
        [TestCase(10000, "Desc", "random")]
        [TestCase(10000, "Desc", "right")]
        [TestCase(10000, "Desc", "mid")]
        [TestCase(10000, "AShape", "random")]
        [TestCase(10000, "AShape", "right")]
        [TestCase(10000, "AShape", "mid")]
        [TestCase(10000, "VShape", "random")]
        [TestCase(10000, "VShape", "right")]
        [TestCase(10000, "VShape", "mid")]
        [TestCase(10000, "Const", "random")]
        [TestCase(10000, "Const", "mid")]
        [TestCase(10000, "Const", "right")]
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