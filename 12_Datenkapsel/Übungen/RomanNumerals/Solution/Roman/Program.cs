/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung
*--------------------------------------------------------------
* Description: RomanNumerals
*--------------------------------------------------------------
*/

namespace Roman
{
    using System;

    public class Program
    {
        private const int FieldSize = 10;

        static void Main(string[] args)
        {
            Console.WriteLine("Roman Numerals Adder");
            Console.WriteLine("========================");

            var number1 = ReadRoman("Please enter first roman:  ");
            var number2 = ReadRoman("Please enter second roman: ");

            Console.WriteLine($" {RomanNumerals.ConvertToRomanLiteral(number1),15}");
            Console.WriteLine($"+{RomanNumerals.ConvertToRomanLiteral(number2),15}");

            var sum = RomanNumerals.ConvertToRomanLiteral(number1 + number2);

            if (string.IsNullOrEmpty(sum))
            {
                Console.WriteLine("to big");
            }
            else
            {
                Console.WriteLine($"={sum,15}");
            }
        }

        static int ReadRoman(string message)
        {
            int  number;
            bool isOk;
            do
            {
                Console.Write(message);
                var input = Console.ReadLine();
                if (int.TryParse(input, out number))
                {
                    isOk = true;
                }
                else
                {
                    number = RomanNumerals.ConvertFromRomanLiteral(input);
                    isOk   = number != -1;
                }
            } while (!isOk);

            return number;
        }
    }
}