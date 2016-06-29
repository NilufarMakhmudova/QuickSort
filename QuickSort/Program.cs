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
            int[] _10integers = QuickSortHelper.ReadFiles(@"D:\Video\Stanford Algorithms\AlgoW2\10.txt");
            QuickSort sort = new QuickSort();
            //fix running totals
        }


    }

    public  class QuickSort {
        public int[] QuickSortAlgorithmWithFirstElementAsPivot(int[] integerArray) {
            if (integerArray.Length == 1) return integerArray;
            else {
                int pivot = integerArray[0];
                PartitionResult partitionResult = DoPartition(integerArray, pivot);
                QuickSortAlgorithmWithFirstElementAsPivot(partitionResult.FirstPart);
                QuickSortAlgorithmWithFirstElementAsPivot(partitionResult.SecondPart);
                return integerArray;
            }
        }

        private PartitionResult DoPartition(int[] integerArray, int pivot)
        {
            int numbOfComparisons = integerArray.Length-1;
            //last index of integers that are less than pivot
            int j = 0;

            for (int i =1; i<integerArray.Length;) {
                if (integerArray[i] < pivot)
                {
                    //swap with unsortedArray[i] j+1
                    int takeMeInt = integerArray[j];
                    integerArray[j] = integerArray[i];
                    integerArray[i] = takeMeInt;
                    j++;
                    i++;
                }
                else {
                    i++;
                }
            }
            //swap pivot with last in less part
            int toComeFirst = integerArray[j];
            integerArray[0] = toComeFirst;
            integerArray[j] = pivot;

            PartitionResult result = new PartitionResult() { FirstPart = integerArray.Take(j).ToArray(), SecondPart = integerArray.Skip(j + 1).ToArray(), numberOfComparisons= numbOfComparisons};
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
        public int[] FirstPart { get; set; }
        public int[] SecondPart { get; set; }
        public int numberOfComparisons { get; set; }
    }


}
