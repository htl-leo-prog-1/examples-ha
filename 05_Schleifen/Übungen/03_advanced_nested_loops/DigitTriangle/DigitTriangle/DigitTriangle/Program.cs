/*-----------------------------------------------------------------------------
 *				HTBLA-Leonding / Class: <your class name here>
 *-----------------------------------------------------------------------------
 * Exercise Number: #exercise_number#
 * Author(s):		Birgit Schroeder
 * Due Date:		#due#
 *-----------------------------------------------------------------------------
 * Description:
 * The program DigitTriangle reads a digit between 1 and 9 from the console
 * and prints a triangle consisting of all the digits within this range
 * to the console. Starting with 1, each digit is printed into a single line
 * whereby the number of digits in a line depends on the digit itself.
 * The output shall be right-aligned, depending on the longest line.
 * Example for '3':
 *    1
 *   22
 *  333
 *-----------------------------------------------------------------------------
*/
using System;

namespace DigitTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a number (< 10): ");
            int topNumber = Convert.ToInt32(Console.ReadLine());
            for (int numberToPrint = 1; numberToPrint <= topNumber; numberToPrint++)
            {
                for (int spacecounter = 1; spacecounter <= (topNumber - numberToPrint); spacecounter++)
                {
                    Console.Write(" ");
                }
                for (int digitCounter = 1; digitCounter <= numberToPrint; digitCounter++)
                {
                    Console.Write(numberToPrint);

                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
