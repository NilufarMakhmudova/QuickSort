using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] _10integers = QuickSortHelper.ReadFiles(@"D:\Video\Stanford Algorithms\AlgoW2\QuickSort\10.txt");
            QuickSort sort = new QuickSort();
            //fix running totals
            SortResult result = sort.QuickSortAlgorithmWithFirstElementAsPivot(new SortResult() { Array = _10integers, numberOfComparisons = 0 });
            Console.WriteLine(result.numberOfComparisons);
            Console.WriteLine(result.Array.ToString());
            Console.ReadKey();
        }


    }

    public  class QuickSort {
        public SortResult QuickSortAlgorithmWithFirstElementAsPivot(SortResult integerArray) {
            if (integerArray.Array.Length == 0) return new SortResult() { Array = new int[0], numberOfComparisons = integerArray.numberOfComparisons };
            else if (integerArray.Array.Length == 1) return new SortResult() { Array = integerArray.Array, numberOfComparisons = integerArray.numberOfComparisons };
            else {
                int pivot = integerArray.Array[0];
                PartitionResult partitionResult = DoPartition(integerArray, pivot);
                QuickSortAlgorithmWithFirstElementAsPivot(partitionResult.FirstPart);
                QuickSortAlgorithmWithFirstElementAsPivot(partitionResult.SecondPart);
                return integerArray;
            }
        }

        private PartitionResult DoPartition(SortResult integerArray, int pivot)
        {
            int numbOfComparisons = integerArray.Array.Length-1 + integerArray.numberOfComparisons;
            //last index of integers that are less than pivot
            int j = 1;

            for (int i =1; i<integerArray.Array.Length;) {
                if (integerArray.Array[i] < pivot)
                {
                    //swap with unsortedArray[i] j+1
                    int takeMeInt = integerArray.Array[j];
                    integerArray.Array[j] = integerArray.Array[i];
                    integerArray.Array[i] = takeMeInt;
                    j++;
                    i++;
                }
                else {
                    i++;
                }
            }
            //swap pivot with last in less part
            int toComeFirst = integerArray.Array[j-1];
            integerArray.Array[0] = toComeFirst;
            integerArray.Array[j-1] = pivot;

            PartitionResult result = new PartitionResult() { FirstPart = new SortResult() { Array = integerArray.Array.Take(j-1).ToArray(), numberOfComparisons = numbOfComparisons }, SecondPart = new SortResult() { Array = integerArray.Array.Skip(j ).ToArray(), numberOfComparisons = numbOfComparisons } };
            return result;
        }
    }

    public static class QuickSortHelper {

       public static int[] ReadFiles(string path)
        {
            string[] numbersAsString = File.ReadAllLines(path);
            int arrayLength = numbersAsString.Length;
            int[] result = new int[arrayLength];
            for (int i = 0; i < arrayLength; i++) {
                result[i] = Int32.Parse(numbersAsString[i]);
            }
            return result;
        }
    }

    public class PartitionResult {
        public SortResult FirstPart { get; set; }
        public SortResult SecondPart { get; set; }
   
    }

    public class SortResult {
        public int[] Array { get; set; }
        public int numberOfComparisons { get; set; }
    }


}
