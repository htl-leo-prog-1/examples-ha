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
            Console.WriteLine("Roman Numerals Converter");
            Console.WriteLine("========================");

            var numberToConvert = Tools.ReadNumber("Please enter first number to convert: ");

            var romanLiteral = RomanNumerals.ConvertToRomanLiteral(numberToConvert);
            Console.WriteLine($"'{numberToConvert}' converted to roman: '{romanLiteral}'");

        }
    }
}