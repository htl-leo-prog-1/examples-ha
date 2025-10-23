/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: ReadModifyWriteAray
*--------------------------------------------------------------
*/

namespace SomeLinq
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Some Linq");
            Console.WriteLine("**********************");

            var a = new[] {1, 2, 3, 4};

            if (a.Contains(3))
            {

            }
        }

        public static int Min(int[] ar)
        {
            var min = int.MaxValue;

            foreach (var val in ar)
            {
                if (val < min)
                {
                    min = val;
                }
            }

            return min;
        }

        public static int Max(int[] ar)
        {
            var max = int.MinValue;

            foreach (var val in ar)
            {
                if (val > max)
                {
                    max = val;
                }
            }

            return max;
        }

        public static int Count(int[] ar, int value)
        {
            var count = 0;

            foreach (var val in ar)
            {
                if (value == val)
                {
                    count++;
                }
            }

            return count;
        }

        public static bool Contains(int[] ar, int value)
        {
            foreach (var val in ar)
            {
                if (value == val)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
