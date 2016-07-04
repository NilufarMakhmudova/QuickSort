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
            int[] _10integers = QuickSortHelper.ReadFiles(@"C:\Users\Nilufar\Source\Repos\QuickSort\10000.txt");
            int[] _100integers = QuickSortHelper.ReadFiles(@"C:\Users\Nilufar\Source\Repos\QuickSort\10000.txt");
            int[] _1000integers = QuickSortHelper.ReadFiles(@"C:\Users\Nilufar\Source\Repos\QuickSort\10000.txt");
            QuickSort sort = new QuickSort();
            //fix running totals
            int numberOfComparisons1 = 0;
            int numberOfComparisons2 = 0;
            int numberOfComparisons3 = 0;
            sort.QuickSortAlgorithmWithMedianElementAsPivot(_10integers, ref numberOfComparisons3, 0, 9999);
            sort.QuickSortAlgorithmWithFirstElementAsPivot(_1000integers, ref numberOfComparisons1, 0, 9999);
            sort.QuickSortAlgorithmWithLastElementAsPivot(_100integers, ref numberOfComparisons2, 0, 9999);
            Console.WriteLine(numberOfComparisons1);
            Console.WriteLine(numberOfComparisons2);
            Console.WriteLine(numberOfComparisons3);
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
            else
            {
                int pivot;
                int arraylenght = end - begin + 1;

                int middleIndex = (end+begin)/2;
                int firstNumber = integerArray[begin];
                int lastNumber = integerArray[end];
                int middleNumber =integerArray[middleIndex];

                if (firstNumber > middleNumber)
                {
                    if (firstNumber > lastNumber)
                    {
                        if (middleNumber > lastNumber)
                        {
                            pivot = middleNumber;
                            integerArray[begin] = middleNumber;
                            integerArray[middleIndex] = firstNumber;
                        }
                        else
                        {
                            pivot = lastNumber;
                            integerArray[begin] = lastNumber;
                            integerArray[end] = firstNumber;
                        }
                    }
                    else pivot = firstNumber;

                }
                else
                {
                    if (middleNumber > lastNumber)
                    {
                        if (firstNumber > lastNumber)
                        {
                            pivot = firstNumber;
                        }
                        else
                        {
                            pivot = lastNumber;
                            integerArray[begin] = lastNumber;
                            integerArray[end] = firstNumber;
                        }
                    }
                    else
                    {
                        pivot = middleNumber;
                        integerArray[begin] = middleNumber;
                        integerArray[middleIndex] = firstNumber;
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
