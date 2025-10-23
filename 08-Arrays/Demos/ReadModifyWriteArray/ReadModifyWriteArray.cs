/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: ReadModifyWriteAray
*--------------------------------------------------------------
*/

namespace ReadModifyWriteAray
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ReadModifyWriteArray");
            Console.WriteLine("**********************");

            var numbers = ReadArray();
            var numbersCopy = CopyArray(numbers);
            ModifyArray(numbers);
            WriteArray(numbersCopy);
            WriteArray(numbers);
        }

        public static int[] ReadArray()
        {
            Console.Write("Please enter the count of numbers: ");
            int countOfNumbers = int.Parse(Console.ReadLine());
            
            int[] intNumbers = new int[countOfNumbers];

            for (int i = 0; i < countOfNumbers; i++)
            {
                Console.Write($"Please enter {i + 1}. number: ");
                intNumbers[i] = int.Parse(Console.ReadLine());
            }

            return intNumbers;
        }

        public static void ModifyArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = numbers[i] * 2; 
            }
        }

        public static void WriteArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"{i + 1}. number: {numbers[i]}");
            }
        }

        public static int[] CopyArray(int[] numbers)
        {
			var newNumbers = new int[numbers.Length];
			
            for (int i = 0; i < numbers.Length; i++)
            {
                newNumbers[i] = numbers[i]; 
            }
			return newNumbers;
        }
    }
}
