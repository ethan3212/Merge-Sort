using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testArray = { 1, 0, 2, 9, 3, 8, 4, 7, 5, 6 };
            int N = testArray.Length;

            // display unsorted list
            WriteLine("Unsorted: ");

            foreach (int i in testArray)
            {
                Write(i + " ");
            }

            WriteLine();

            // call sort routine        
            MergeSort(testArray, 0, N-1);

            // display sorted list
            WriteLine("Sorted: ");
            foreach (int i in testArray)
            {
                Write(i + " ");
            }

            WriteLine();
            ReadLine();
        }

        static void MergeSort(int[] list, int first, int last)
        // list: the elements to be put into order
        // first: the index of the first element in the part of the list to sort
        // last: the index of the last element in the part of the list to sort
        {
            if (first < last)
            {
                int middle = (first + last) / 2;
                MergeSort(list, first, middle);
                MergeSort(list, (middle + 1), last);
                MergeLists(list, first, middle, (middle + 1), last);
            }   // end if
        }

        static void MergeLists(int[] list, int start1, int end1, int start2, int end2)
        // list: the elements to be put into order
        // start1: the beginning of "list" A
        // end1: end of "list" A
        // start2: beginning of "list" B
        // end2: beginning of "list" B
        // assumes that the elements of A and B are contiguous
        {
            int[] result = new int[list.Length];
            int finalStart = start1;
            int finalEnd = end2;
            int indexC = 0;

            while((start1 <= end1) && (start2 <= end2))
            {
                if(list[start1] < list[start2])
                {
                    result[indexC] = list[start1];
                    start1++;
                }

                else
                {
                    result[indexC] = list[start2];
                    start2++;   
                }   // end if/else

                indexC++;
            }   // end while

            // move the part of the list that is left over
            if(start1 <= end1)
            {
                for(int i = start1; i <= end1; i++)
                {
                    result[indexC] = list[i];
                    indexC++;
                }   // end for

            }

            else
            {
                for(int i = start2; i <= end2; i++)
                {
                    result[indexC] = list[i];
                    indexC++;
                }
            }   // end if/else

            // now put the result back into the list
            indexC = 0;

            for(int i = finalStart; i <= finalEnd; i++)
            {
                list[i] = result[indexC];
                indexC++;
            }   // end for
        }
    }
}
