/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: (Array-)Distinct with UnitTests
*--------------------------------------------------------------
*/

namespace Distinct
{
    public static class DistinctTools
    {
        /// <summary>
        /// Check, if arry contains distinct values.
        /// </summary>
        /// <param name="ar"></param>
        /// <returns>true if array contains distinct values.</returns>
        public static bool IsDistinct(int[] ar)
        {
            for (int i = 0; i < ar.Length; i++)
            {
                for (int j = i + 1; j < ar.Length; j++)
                {
                    if (ar[j] == ar[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Create a distinct array.
        /// </summary>
        /// <param name="ar"></param>
        /// <returns>Array with distinct values.</returns>
        public static int[] Distinct(int[] ar)
        {
            int[] result = new int[ar.Length];
            int resultLength = 0;

            for (int i = 0; i < ar.Length; i++)
            {
                if (!Contains(result, ar[i], 0, resultLength))
                {
                    result[resultLength++] = ar[i];
                }
            }

            return Copy(result, resultLength);
        }

        /// <summary>
        /// Calculate all duplicate entries in an array.
        /// </summary>
        /// <param name="ar"></param>
        /// <returns>The array with the duplicate values.</returns>
        public static int[] Duplicate(int[] ar)
        {
            int[] result = new int[ar.Length];
            int resultLength = 0;

            for (int i = 0; i < ar.Length; i++)
            {
                if (!Contains(result, ar[i], 0, resultLength) && 
                    Contains(ar, ar[i], i+1, ar.Length))
                {
                    result[resultLength++] = ar[i];
                }
            }
            return Copy(result, resultLength);
        }

        private static bool Contains(int[] ar, int value, int startIdx, int length)
        {
            for (int i = startIdx; i < length; i++)
            {
                if (value == ar[i])
                {
                    return true;
                }
            }

            return false;
        }

        private static int[] Copy(int[] ar, int length)
        {
            var result = new int[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = ar[i];
            }

            return result;
        }
    }
}