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

        [TestCase(10000, "Random", "Random")]
        [TestCase(10000, "Random", "Mid")]
        [TestCase(10000, "Random", "Right")]
        [TestCase(10000, "Asc", "Random")]
        [TestCase(10000, "Asc", "Mid")]
        [TestCase(10000, "Asc", "Right")]
        [TestCase(10000, "Desc", "Random")]
        [TestCase(10000, "Desc", "Right")]
        [TestCase(10000, "Desc", "Mid")]
        [TestCase(10000, "AShape", "Random")]
        [TestCase(10000, "AShape", "Right")]
        [TestCase(10000, "AShape", "Mid")]
        [TestCase(10000, "VShape", "Random")]
        [TestCase(10000, "VShape", "Right")]
        [TestCase(10000, "VShape", "Mid")]
        [TestCase(10000, "Const", "Random")]
        [TestCase(10000, "Const", "Mid")]
        [TestCase(10000, "Const", "Right")]
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