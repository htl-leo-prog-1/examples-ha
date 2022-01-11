using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace RemoveDoubleNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] numbers;
            int[] compressedArray;
            int doublesCount;
            Console.WriteLine("Remove double numbers");
            Console.WriteLine("=====================");
            // Eingabe
            numbers = GetIntArray();
            Console.Write("Array nach der Eingabe:                 ");
            WriteArray(numbers);
            doublesCount = MarkDoublesWithZero(numbers);
            Console.Write($"Array nach der Markierung der {doublesCount} Zahlen: ");
            WriteArray(numbers);
            compressedArray = CompressArray(numbers, doublesCount);
            Console.Write("Array nach der Komprimierung:           ");
            WriteArray(compressedArray);
            Console.Write("Beenden mit Eingabetaste ...");
            Console.ReadLine();
        }


        /// <summary>
        /// Im Array numbers befindet sich doubles mal eine 0.
        /// Im Ergebnisarray werden diese 0en unterdrückt.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>Komprimiertes Array</returns>
        private static int[] CompressArray(int[] numbers, int doubles)
        {
            int[] result = new int[numbers.Length - doubles];
            int desitnationIndex = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != 0)
                {
                    result[desitnationIndex] = numbers[i];
                    desitnationIndex++;
                }

            }
            return result;
        }

        private static void WriteArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write("{0,3}", numbers[i]);
            }
            Console.WriteLine();
        }

        private static int MarkDoublesWithZero(int[] numbers)
        {
            int doublesCounter = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] != 0 && numbers[i] == numbers[j])
                    {
                        numbers[j] = 0;
                        doublesCounter++;
                    }
                }
            }
            return doublesCounter;
        }

        private static int[] GetIntArray()
        {
            int[] numbers = new int[10];
            //int[] numbers = {22, 15, 12, 15, 4, 19, 22, 3, 9, 22};
            //return numbers;
            string input;
            Console.WriteLine("10 Ganzzahlen > 0 eingeben");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"Zahl {i + 1} [>0]: ");
                input = Console.ReadLine();
                numbers[i] = Convert.ToInt32(input);
            }
            return numbers;
        }
    }
}
