/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Method for intersection between two arrays  
*--------------------------------------------------------------
*/

using System;

namespace Intersect
{
    public class IntersectTools
    {
        public static int[] Intersect(int[] numbersA, int[] numbersB)
        {
            var isInBoth = new bool[numbersA.Length];
            int count = 0;

            for (int i = 0; i < numbersA.Length; i++)
            {
                if (!Contains(numbersA, numbersA[i], i) && Contains(numbersB, numbersA[i], numbersB.Length))
                {
                    isInBoth[i] = true;
                    count++;
                }
            }

            int index = 0;
            var result = new int[count];
            for (int i = 0; i < isInBoth.Length; i++)
            {
                if (isInBoth[i])
                {
                    result[index] = numbersA[i];
                    index++;
                }
            }

            return result;
        }

        private static bool Contains(int[] numbers, int value, int length)
        {
            length = Math.Min(length, numbers.Length);

            for (int i = 0; i < length; i++)
            {
                if (numbers[i] == value)
                {
                    return true;
                }
            }

            return false;
        }
    }
}