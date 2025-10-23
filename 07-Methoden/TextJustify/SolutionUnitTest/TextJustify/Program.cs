/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: TextJustify with UnitTests
 *--------------------------------------------------------------
 */

namespace TextJustify
{
    using System;

    public class Program
    {
        static int ReadNumber(string message, int max, int min)
        {
            int  number;
            bool isOk;
            do
            {
                Console.Write($"{message} [{min}..{max}]: ");
                isOk = int.TryParse(Console.ReadLine(), out number) && number >= min && number <= max;
            } while (!isOk);

            return number;
        }

        static void Main()
        {
            Console.WriteLine("Text justify");
            Console.WriteLine("************");

            int charPerLine = ReadNumber("Please enter the number of char per line: ", 200, 1);

            Console.Write("InputText: ");
            string sentence = Console.ReadLine();

            while (!string.IsNullOrEmpty(sentence))
            {
                Console.WriteLine($"Justified: {TextJustifyTools.TextJustify(sentence, charPerLine)}");
                Console.Write("InputText: ");
                sentence = Console.ReadLine();
            }
        }
    }
}