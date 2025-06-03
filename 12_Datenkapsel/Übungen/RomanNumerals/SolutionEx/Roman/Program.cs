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
        static void Main(string[] args)
        {
            Console.WriteLine("Roman Numerals Adder");
            Console.WriteLine("========================");

            var number1 = ReadRoman("Please enter first roman:  ");
            var number2 = ReadRoman("Please enter second roman: ");

            Console.WriteLine($" {number1.ConvertToRomanLiteral(),15}");
            Console.WriteLine($"+{number2.ConvertToRomanLiteral(),15}");

            var sum = (number1 + number2).ConvertToRomanLiteral();

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
                var input = Console.ReadLine()!;
                if (int.TryParse(input, out number))
                {
                    isOk = true;
                }
                else
                {
                    number = input.ConvertFromRomanLiteral();
                    isOk   = number != -1;
                }
            } while (!isOk);

            return number;
        }
    }
}