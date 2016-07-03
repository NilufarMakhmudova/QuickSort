using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickSort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace QuickSortTests
{
    [TestClass]
   public  class _10Tests
    {
        [TestMethod]
        public void TestQuickSortFirstElementAsPivot() {
            int expected = 25;
            QuickSort.QuickSort sort = new QuickSort.QuickSort();
            int[] arrayToBeSorted = QuickSort.QuickSortHelper.ReadFiles(@"C:\Users\Nilufar\Source\Repos\QuickSort\10.txt");
            int numberOfComparisons = 0;
            sort.QuickSortAlgorithmWithFirstElementAsPivot(arrayToBeSorted, ref numberOfComparisons);
            Assert.AreEqual(expected, numberOfComparisons);
        }


        [TestMethod]
        public void TestQuickSortLastElementAsPivot()
        {
            int expected = 29;
            QuickSort.QuickSort sort = new QuickSort.QuickSort();
            int[] arrayToBeSorted = QuickSort.QuickSortHelper.ReadFiles(@"C:\Users\Nilufar\Source\Repos\QuickSort\10.txt");
            int numberOfComparisons = 0;
            sort.QuickSortAlgorithmWithLastElementAsPivot(arrayToBeSorted, ref numberOfComparisons);
            Assert.AreEqual(expected, numberOfComparisons);
        }

        [TestMethod]
        public void TestQuickSortMiddleElementAsPivot()
        {
            int expected = 21;
            QuickSort.QuickSort sort = new QuickSort.QuickSort();
            int[] arrayToBeSorted = QuickSort.QuickSortHelper.ReadFiles(@"C:\Users\Nilufar\Source\Repos\QuickSort\10.txt");
            int numberOfComparisons = 0;
            sort.QuickSortAlgorithmWithMedianElementAsPivot(arrayToBeSorted, ref numberOfComparisons);
            Assert.AreEqual(expected, numberOfComparisons);
        }

    }
}
