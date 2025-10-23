using System;

namespace BinaryAdder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Binary Adder");
            Console.WriteLine("============");

            string dual1 = ReadDualNumber("Geben Sie die erste Dualzahl ein: ");
            string dual2 = ReadDualNumber("Geben Sie die zweite Dualzahl ein: ");
            string result = AddDualNumbers(dual1, dual2);
            Console.WriteLine($"Result = {result}");
        }

        private static string AddDualNumbers(string dual1, string dual2)
        {
            int diff = dual1.Length - dual2.Length;
            if (diff > 0)
            {
                dual2 = AddLeadingZeros(dual2, diff);
            }
            else if (diff < 0)
            {
                dual1 = AddLeadingZeros(dual1, diff);
            }
            return Add(dual1, dual2);
        }

        private static string Add(string dual1, string dual2)
        {
            int carry = 0;
            string result = "";
            for (int i = 0; i < dual1.Length; i++)
            {
                int sum = dual1[i] - '0' + dual2[i] - '0' + carry;
                int digit = sum % 2;
                carry = sum / 2;
                result = digit + result;
            }
            if (carry > 0)
            {
                result = carry + result;
            }

            return result;
        }

        private static string AddLeadingZeros(string dual, int count)
        {
            for (int i = 0; i < count; i++)
            {
                dual = '0' + dual;
            }
            return dual;
        }

        private static string ReadDualNumber(string prompt)
        {
            string input = "";
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
            }
            while (!IsDual(input));
            return input;
        }

        private static bool IsDual(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsDigit(input[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
