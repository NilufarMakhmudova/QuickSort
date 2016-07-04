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
            sort.QuickSortAlgorithmWithMedianElementAsPivot(_10integers, ref numberOfComparisons, 0, 9);
            foreach (int a in _10integers)
            {
                Console.WriteLine(a);
            }
            Console.ReadKey();
        }


    }

    public class QuickSort
    {
        public void QuickSortAlgorithmWithFirstElementAsPivot(int[] integerArray, ref int numbOfComparisons, int begin, int end)
        {
            if (begin >= end) return;
            else
            {
                int pivot = integerArray[begin];
                //partition

                numbOfComparisons += end - begin;
                //last index of integers that are less than pivot
                int j = begin + 1;

                for (int i = begin; i <= end;)
                {
                    if (integerArray[i] < pivot)
                    {
                        //swap with unsortedArray[i] j+1
                        int takeMeInt = integerArray[j];
                        integerArray[j] = integerArray[i];
                        integerArray[i] = takeMeInt;
                        j++;
                        i++;
                    }
                    else
                    {
                        i++;
                    }
                }
                //swap pivot with last in less part
                int toComeFirst = integerArray[j - 1];
                integerArray[begin] = toComeFirst;
                integerArray[j - 1] = pivot;

                QuickSortAlgorithmWithFirstElementAsPivot(integerArray, ref numbOfComparisons, begin, j - 2);
                QuickSortAlgorithmWithFirstElementAsPivot(integerArray, ref numbOfComparisons, j, end);
            }
        }

        public void QuickSortAlgorithmWithLastElementAsPivot(int[] integerArray, ref int numbOfComparisons, int begin, int end)
        {
            if (begin >= end) return;
            else
            {
                //swap last element with first
                int first = integerArray[begin];
                integerArray[begin] = integerArray[end];
                integerArray[end] = first;

                int pivot = integerArray[begin];
                //partition

                numbOfComparisons += end - begin;
                //last index of integers that are less than pivot
                int j = begin + 1;

                for (int i = begin; i <= end;)
                {
                    if (integerArray[i] < pivot)
                    {
                        //swap with unsortedArray[i] j+1
                        int takeMeInt = integerArray[j];
                        integerArray[j] = integerArray[i];
                        integerArray[i] = takeMeInt;
                        j++;
                        i++;
                    }
                    else
                    {
                        i++;
                    }
                }
                //swap pivot with last in less part
                int toComeFirst = integerArray[j - 1];
                integerArray[begin] = toComeFirst;
                integerArray[j - 1] = pivot;

                QuickSortAlgorithmWithLastElementAsPivot(integerArray, ref numbOfComparisons, begin, j - 2);
                QuickSortAlgorithmWithLastElementAsPivot(integerArray, ref numbOfComparisons, j, end);

            }
        }

        public void QuickSortAlgorithmWithMedianElementAsPivot(int[] integerArray, ref int numbOfComparisons, int begin, int end)
        {
            if (begin >= end) return;
            else if (end - begin == 1) {
                QuickSortAlgorithmWithFirstElementAsPivot(integerArray, ref numbOfComparisons, begin, end);
            }
            else
            {
                int pivot;
                int arraylenght = end - begin + 1;

                double arrayLenghtInDouble = (double)arraylenght;
                
                int halfLength =(int)Math.Ceiling( arrayLenghtInDouble/ 2);
                int first = integerArray[begin];
                int last = integerArray[end];
                int middle =integerArray[begin + halfLength-1];

                if (first > middle)
                {
                    if (first > last)
                    {
                        if (middle > last)
                        {
                            pivot = middle;
                            integerArray[begin] = middle;
                            integerArray[halfLength] = first;
                        }
                        else
                        {
                            pivot = last;
                            integerArray[begin] = last;
                            integerArray[end] = first;
                        }
                    }
                    else pivot = first;

                }
                else
                {
                    if (middle > last)
                    {
                        if (first > last)
                        {
                            pivot = first;
                        }
                        else
                        {
                            pivot = last;
                            integerArray[begin] = last;
                            integerArray[end] = first;
                        }
                    }
                    else
                    {
                        pivot = middle;
                        integerArray[begin] = middle;
                        integerArray[halfLength] = first;
                    }

                }

                numbOfComparisons += end - begin;
                //last index of integers that are less than pivot
                int j = begin + 1;

                for (int i = begin; i <= end;)
                {
                    if (integerArray[i] < pivot)
                    {
                        //swap with unsortedArray[i] j+1
                        int takeMeInt = integerArray[j];
                        integerArray[j] = integerArray[i];
                        integerArray[i] = takeMeInt;
                        j++;
                        i++;
                    }
                    else
                    {
                        i++;
                    }
                }
                //swap pivot with last in less part
                int toComeFirst = integerArray[j - 1];
                integerArray[begin] = toComeFirst;
                integerArray[j - 1] = pivot;

                QuickSortAlgorithmWithMedianElementAsPivot(integerArray, ref numbOfComparisons, begin, j - 2);
                QuickSortAlgorithmWithMedianElementAsPivot(integerArray, ref numbOfComparisons, j, end);


            }
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
