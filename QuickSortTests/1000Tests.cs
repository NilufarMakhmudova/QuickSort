using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSortTests
{
    [TestClass]
    public class _1000Tests
    {

        [TestMethod]
        public void TestQuickSortFirstElementAsPivot()
        {
            int expected = 10297;
            QuickSort.QuickSort sort = new QuickSort.QuickSort();
            int[] arrayToBeSorted = QuickSort.QuickSortHelper.ReadFiles(@"C:\Users\Nilufar\Source\Repos\QuickSort\1000.txt");
            int numberOfComparisons = 0;
            sort.QuickSortAlgorithmWithFirstElementAsPivot(arrayToBeSorted, ref numberOfComparisons);
            Assert.AreEqual(expected, numberOfComparisons);
        }

        [TestMethod]
        public void TestQuickSortLastElementAsPivot()
        {
            int expected = 10184;
            QuickSort.QuickSort sort = new QuickSort.QuickSort();
            int[] arrayToBeSorted = QuickSort.QuickSortHelper.ReadFiles(@"C:\Users\Nilufar\Source\Repos\QuickSort\1000.txt");
            int numberOfComparisons = 0;
            sort.QuickSortAlgorithmWithLastElementAsPivot(arrayToBeSorted, ref numberOfComparisons);
            Assert.AreEqual(expected, numberOfComparisons);
        }

        [TestMethod]
        public void TestQuickSortMiddleElementAsPivot()
        {
            int expected = 8921;
            QuickSort.QuickSort sort = new QuickSort.QuickSort();
            int[] arrayToBeSorted = QuickSort.QuickSortHelper.ReadFiles(@"C:\Users\Nilufar\Source\Repos\QuickSort\1000.txt");
            int numberOfComparisons = 0;
            sort.QuickSortAlgorithmWithMedianElementAsPivot(arrayToBeSorted, ref numberOfComparisons);
            Assert.AreEqual(expected, numberOfComparisons);
        }

    }
}
