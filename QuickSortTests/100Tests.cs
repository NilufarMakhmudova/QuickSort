using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSortTests
{
    [TestClass]
    public class _100Tests
    {
        [TestMethod]
        public void TestQuickSortFirstElementAsPivot()
        {
            int expected = 615;
            QuickSort.QuickSort sort = new QuickSort.QuickSort();
            int[] arrayToBeSorted = QuickSort.QuickSortHelper.ReadFiles(@"C:\Users\Nilufar\Source\Repos\QuickSort\100.txt");
            int numberOfComparisons = 0;
            sort.QuickSortAlgorithmWithFirstElementAsPivot(arrayToBeSorted, ref numberOfComparisons, 0, 99);
            Assert.AreEqual(expected, numberOfComparisons);
        }

                [TestMethod]
        public void TestQuickSortLastElementAsPivot()
        {
            int expected = 587;
            QuickSort.QuickSort sort = new QuickSort.QuickSort();
            int[] arrayToBeSorted = QuickSort.QuickSortHelper.ReadFiles(@"C:\Users\Nilufar\Source\Repos\QuickSort\100.txt");
            int numberOfComparisons = 0;
            sort.QuickSortAlgorithmWithLastElementAsPivot(arrayToBeSorted, ref numberOfComparisons, 0, 99);
            Assert.AreEqual(expected, numberOfComparisons);
        }

        [TestMethod]
        public void TestQuickSortMiddleElementAsPivot()
        {
            int expected = 518;
            QuickSort.QuickSort sort = new QuickSort.QuickSort();
            int[] arrayToBeSorted = QuickSort.QuickSortHelper.ReadFiles(@"C:\Users\Nilufar\Source\Repos\QuickSort\100.txt");
            int numberOfComparisons = 0;
            sort.QuickSortAlgorithmWithMedianElementAsPivot(arrayToBeSorted, ref numberOfComparisons, 0, 99);
            Assert.AreEqual(expected, numberOfComparisons);
        }

    }
}
