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
            int[] arrayToBeSorted = QuickSort.QuickSortHelper.ReadFiles(@"D:\Video\Stanford Algorithms\AlgoW2\QuickSort\10.txt");
            QuickSort.SortResult result = sort.QuickSortAlgorithmWithFirstElementAsPivot(new SortResult() { Array = arrayToBeSorted, numberOfComparisons = 0 });
            int actual = result.numberOfComparisons;
            Assert.AreEqual(expected, actual);
        }
    }
}
