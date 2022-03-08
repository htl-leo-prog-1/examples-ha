/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Sorting Numbers
*--------------------------------------------------------------
*/

namespace SortCompare
{
    static class Sorting
    {
        public static void SortBruteForce(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] > numbers[j])
                    {
                        Swap(numbers, i, j);
                    }
                }
            }
        }

        public static void BubbleSort(int[] numbers)
        {
            int lastUnsortedElement = numbers.Length - 1;
            bool elementsWereSwapped;
            do
            {
                elementsWereSwapped = false;
                for (int i = 0; i < lastUnsortedElement; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        Swap(numbers, i, i + 1);
                        elementsWereSwapped = true;
                    }
                }
                lastUnsortedElement--;
            } while (elementsWereSwapped);
        }

        public static void InsertionSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                var current = numbers[i];
                int j = i - 1;
                while (j >= 0 && numbers[j] > current)
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }
                numbers[j + 1] = current;
            }
        }

        public static void SelectionSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[min])
                    {
                        min = j;
                    }
                }
                Swap(numbers, i, min);
            }
        }
       
        static void Swap(int[] n, int indexLeft, int indexRight)
        {
            var temp = n[indexLeft];
            n[indexLeft] = n[indexRight];
            n[indexRight] = temp;
        }
    }
}
