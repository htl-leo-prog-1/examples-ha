/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Sorting Numbers
*--------------------------------------------------------------
*/

using System;

namespace SortCompare
{
    static class Sorting
    {
        public static void SortBruteForce(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public static void BubbleSort(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public static void InsertionSort(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public static void SelectionSort(int[] numbers)
        {
            throw new NotImplementedException();
        }

        static void Swap(int[] n, int indexLeft, int indexRight)
        {
            var temp = n[indexLeft];
            n[indexLeft] = n[indexRight];
            n[indexRight] = temp;
        }
    }
}
