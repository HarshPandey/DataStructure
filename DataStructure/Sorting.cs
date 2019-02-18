using System;
using System.Diagnostics;

namespace DataStructure
{
    public class Sorting
    {
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void PrintArray(int[] array)
        {
            Console.WriteLine("PrintArray :");
            foreach (int item in array) {
                Console.Write(item+" ");
            }
            Console.WriteLine("\n");
        }

        public static void TestSortingFunctions()
        {
            int[] array1 = { 8, 0, 3, 4, 7, 6, 5, 2, 1, 9 };
            int[] array2 = { 4, 0, 7, 8, 3, 6, 9, 1, 5, 2 };
            int[] array3 = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            int[] array4 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            int[] result = new int[array1.Length];

            var s1 = Stopwatch.StartNew();

            // Test Selection Sort
            Console.WriteLine("\nTest Selection Sort\n");
            array1.CopyTo(result, 0);
            SelectionSort(ref result);
            PrintArray(result);

            array2.CopyTo(result, 0);
            SelectionSort(ref result);
            PrintArray(result);

            array3.CopyTo(result, 0);
            SelectionSort(ref result);
            PrintArray(result);

            array4.CopyTo(result, 0);
            SelectionSort(ref result);
            PrintArray(result);

            // Test Bubble Sort
            Console.WriteLine("\nTest Bubble Sort\n");
            array1.CopyTo(result, 0);
            BubbleSort(ref result);
            PrintArray(result);

            array2.CopyTo(result, 0);
            BubbleSort(ref result);
            PrintArray(result);

            array3.CopyTo(result, 0);
            BubbleSort(ref result);
            PrintArray(result);

            array4.CopyTo(result, 0);
            BubbleSort(ref result);
            PrintArray(result);

            // Test Insertion Sort
            Console.WriteLine("\nTest Insertion Sort\n");
            array1.CopyTo(result, 0);
            InsertionSort(ref result);
            PrintArray(result);

            array2.CopyTo(result, 0);
            InsertionSort(ref result);
            PrintArray(result);

            array3.CopyTo(result, 0);
            InsertionSort(ref result);
            PrintArray(result);

            array4.CopyTo(result, 0);
            InsertionSort(ref result);
            PrintArray(result);

            // Test Merge Sort
            Console.WriteLine("\nTest Merge Sort\n");
            array1.CopyTo(result, 0);
            MergeSort(ref result);
            PrintArray(result);

            array2.CopyTo(result, 0);
            MergeSort(ref result);
            PrintArray(result);

            array3.CopyTo(result, 0);
            MergeSort(ref result);
            PrintArray(result);

            array4.CopyTo(result, 0);
            MergeSort(ref result);
            PrintArray(result);

            // Test Quick Sort
            Console.WriteLine("\nTest Quick Sort\n");
            array1.CopyTo(result, 0);
            QuickSort(ref result, 0, result.Length-1);
            PrintArray(result);

            array2.CopyTo(result, 0);
            QuickSort(ref result, 0, result.Length - 1);
            PrintArray(result);

            array3.CopyTo(result, 0);
            QuickSort(ref result, 0, result.Length - 1);
            PrintArray(result);

            array4.CopyTo(result, 0);
            QuickSort(ref result, 0, result.Length - 1);
            PrintArray(result);

            s1.Stop();
            Console.WriteLine("Total execution time : " +s1.Elapsed.TotalMilliseconds + " ms");
        }

        // Method to find the index of minimum value in the array.
        static int MinimumValueIndexInArray(int[] array, int startIndex)
        {
            int indexOfMinimumValue = startIndex;
            int minimumValue = array[startIndex];
            for (int i = startIndex + 1; i < array.Length; i++) {
                if (array[i] < minimumValue) {
                    minimumValue = array[i];
                    indexOfMinimumValue = i;
                }
            }
            return indexOfMinimumValue;
        }

        static void SelectionSort(ref int[] array)
        {
            for (int i = 0; i < array.Length; i++) {
                int minValueIndex = MinimumValueIndexInArray(array, i);
                if (minValueIndex != i) {
                    Swap(ref array[i], ref array[minValueIndex]);
                }
            }
        }

        static void InsertionSort(ref int[] array)
        {
            for (int i = 1; i < array.Length; i++) {
                int value = array[i];
                int hole = i;
                while (hole > 0 && array[hole - 1] > value) {
                    Swap(ref array[hole], ref array[hole - 1]);
                    hole = hole - 1;
                }
                array[hole] = value;
            }
        }
        

        // The most optimized BubbleSort
        static void BubbleSort(ref int[] array)
        {
            int length = array.Length;
            bool isSwapped = false;
            for (int i = 0; i < length; i++) {
                for (int j = 0; j < length - i - 1; j++) {
                    if (array[j] > array[j + 1]) {
                        Swap(ref array[j], ref array[j + 1]);
                        isSwapped = true;
                    }
                }
                if (!isSwapped) {
                    break;
                }
            }
        }

        static void Merge(int[] left, int[] right, ref int[] array)
        {
            int nL = left.Length;
            int nR = right.Length;

            int i = 0;
            int j = 0;
            int k = 0;

            while (i < nL && j < nR) {
                if (left[i] < right[j]) {
                    array[k] = left[i];
                    ++i;
                }
                else {
                    array[k] = right[j];
                    ++j;
                }
                ++k;
            }

            while (i < nL) {
                array[k] = left[i];
                ++i;
                ++k;
            }
            while (j < nR) {
                array[k] = right[j];
                ++j;
                ++k;
            }
        }

        static void MergeSort(ref int[] array)
        {
            if (array.Length < 2) {
                return;
            }
            int mid = array.Length / 2;

            int [] left = new int[mid];
            for (int i = 0; i < mid; i++) {
                left[i] = array[i];
            }

            int[] right = new int[array.Length - mid];
            for (int i = 0; i < array.Length - mid; i++) {
                right[i] = array[mid+i];
            }

            MergeSort(ref left); // on left
            MergeSort(ref right); // on right
            Merge(left, right, ref array);
        }

        static int Partition(ref int[] array, int start, int end)
        {
            int pivotValue = array[end];
            int pIndex = start;

            for (int i = start; i < end; i++) {
                if (array[i] < pivotValue) {
                    Swap(ref array[i], ref array[pIndex]);
                    pIndex += 1;
                }
            }
            Swap(ref array[pIndex], ref array[end]);
            return pIndex;
        }

        static void QuickSort(ref int[] array, int start, int end)
        {
            if (start < end) {
                int pivotIndex = Partition(ref array, start, end);
                QuickSort(ref array, start, pivotIndex-1);
                QuickSort(ref array, pivotIndex+1 , end);
            }
        }
    }
}
