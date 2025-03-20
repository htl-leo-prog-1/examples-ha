/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: Method for Union and Expect between two arrays
 *--------------------------------------------------------------
 */

using System;

namespace UnionExpect
{
    public class SetTools
    {
        /// <summary>
        /// Calculates a union from two set.
        /// The result set (array) only contains distinct values.
        /// </summary>
        /// <param name="numbersA"></param>
        /// <param name="numbersB"></param>
        /// <returns>The array containing all numbers of numbersA and numbersB (distinct)</returns>
        public static int[] Union(int[] numbersA, int[] numbersB)
        {
            int[] union = new int[numbersA.Length + numbersB.Length];
            int length = 0;

            for (int i = 0; i < numbersA.Length; i++)
            {
                if (!Contains(union, numbersA[i], length))
                {
                    union[length] = numbersA[i];
                    length++;
                }
            }

            for (int i = 0; i < numbersB.Length; i++)
            {
                if (!Contains(union, numbersB[i], length))
                {
                    union[length] = numbersB[i];
                    length++;
                }
            }

            return Copy(union, length);
        }

        /// <summary>
        /// Calculates a new array containing all numbers of numbersA without the numbers of numbersB. 
        /// </summary>
        /// <param name="numbersA"></param>
        /// <param name="numbersB"></param>
        /// <returns>Distinct array of all numbers of A without B</returns>
        public static int[] Expect(int[] numbersA, int[] numbersB)
        {
            int[] union = new int[numbersA.Length];
            int length = 0;

            for (int i = 0; i < numbersA.Length; i++)
            {
                if (!Contains(union, numbersA[i], length) && !Contains(numbersB, numbersA[i], numbersB.Length))
                {
                    union[length] = numbersA[i];
                    length++;
                }
            }

            return Copy(union, length);
        }

        private static int[] Copy(int[] numbers, int length)
        {
            int[] newNumbers = new int[length];

            for (int i = 0; i < Math.Min(length, numbers.Length); i++)
            {
                newNumbers[i] = numbers[i];
            }

            return newNumbers;
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