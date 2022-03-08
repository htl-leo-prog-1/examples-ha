using System;

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
        }

        private static int[] CompressArray(int[] numbers, int removeCount)
        {
            var result = new int[numbers.Length - removeCount];
            var idx = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != 0)
                {
                    result[idx] = numbers[i];
                    idx++;
                }

            }
            return result;
        }

        private static void WriteArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i],3}");
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
            var numbers = new int[10];

            Console.WriteLine("10 Ganzzahlen > 0 eingeben");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"Zahl {i + 1} [>0]: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }
            return numbers;
        }
    }
}
