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
            int[] _10integers = QuickSortHelper.ReadFiles(@"C:\Users\Nilufar\Source\Repos\QuickSort\10.txt");
            QuickSort sort = new QuickSort();
            //fix running totals
            int numberOfComparisons = 0;
            sort.QuickSortAlgorithmWithFirstElementAsPivot(_10integers, ref numberOfComparisons);
            foreach (int a in _10integers)
            {
                Console.WriteLine(a);
            }
            Console.ReadKey();
        }


    }

    public  class QuickSort {
        public void QuickSortAlgorithmWithFirstElementAsPivot(ref int[] integerArray, ref int numbOfComparisons) {
            if (integerArray.Length == 0) return;
            else if (integerArray.Length == 1) return;
            else {
                int pivot = integerArray[0];
                int partitionResult = DoPartition(ref integerArray, pivot, ref numbOfComparisons);
                
                QuickSortAlgorithmWithFirstElementAsPivot(ref integerArray.Take(partitionResult-1).ToArray(), ref numbOfComparisons);
                QuickSortAlgorithmWithFirstElementAsPivot(ref integerArray.Skip(partitionResult).ToArray(), ref numbOfComparisons);
                }
        }

        public void QuickSortAlgorithmWithLastElementAsPivot(int[] integerArray, ref int numbOfComparisons)
        {
            if (integerArray.Length == 0) return;
            else if (integerArray.Length == 1) return;
            else
            {
                //swap last element with first
                int first = integerArray[0];
                integerArray[0] = integerArray[integerArray.Length - 1];
                integerArray[integerArray.Length - 1]=first;

                int pivot = integerArray[0];
                int partitionResult = DoPartition(ref integerArray, pivot, ref numbOfComparisons);

                QuickSortAlgorithmWithLastElementAsPivot(integerArray.Take(partitionResult - 1).ToArray(), ref numbOfComparisons);
                QuickSortAlgorithmWithLastElementAsPivot(integerArray.Skip(partitionResult).ToArray(), ref numbOfComparisons);
            }
        }

        public void QuickSortAlgorithmWithMedianElementAsPivot(int[] integerArray, ref int numbOfComparisons)
        {
            if (integerArray.Length == 0) return;
            else if (integerArray.Length == 1) return;
            else
            {
                int pivot;
                int arraylenght = integerArray.Length;
                decimal halfLength = arraylenght / 2;
                int first = integerArray[0];
                int last = integerArray[arraylenght - 1];
                int middle = integerArray[(int)(Math.Ceiling(halfLength))];

                if (first > middle) {
                    if (first > last) {
                        if (middle > last)
                        {
                            pivot = middle;
                            integerArray[0] = middle;
                            integerArray[(int)(Math.Ceiling(halfLength))] = first;
                        }
                        else {
                            pivot = last;
                            integerArray[0] = last;
                            integerArray[arraylenght - 1] = first;
                        }
                    }
                    else pivot = first;
                        
                }
                else {
                    if (middle > last)
                    {
                        if (first > last)
                        {
                            pivot = first;
                        }
                        else
                        {
                            pivot = last;
                            integerArray[0] = last;
                            integerArray[arraylenght - 1] = first;
                        }
                    }
                    else
                    {
                        pivot = middle;
                        integerArray[0] = middle;
                        integerArray[(int)(Math.Ceiling(halfLength))] = first;
                    }

                }
                int partitionResult = DoPartition(ref integerArray, pivot, ref numbOfComparisons);

                QuickSortAlgorithmWithMedianElementAsPivot(integerArray.Take(partitionResult - 1).ToArray(), ref numbOfComparisons);
                QuickSortAlgorithmWithMedianElementAsPivot(integerArray.Skip(partitionResult).ToArray(), ref numbOfComparisons);
            }
        }



        private int DoPartition(ref int[] integerArray, int pivot, ref int numberOfComparisons)
        {
            numberOfComparisons += integerArray.Length - 1;
            //last index of integers that are less than pivot
            int j = 1;

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
            int toComeFirst = integerArray[j-1];
            integerArray[0] = toComeFirst;
            integerArray[j-1] = pivot;

            return j;
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
}
