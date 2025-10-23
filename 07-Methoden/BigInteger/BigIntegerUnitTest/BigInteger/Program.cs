/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: BigInteger with UnitTests
 *--------------------------------------------------------------
 */

namespace BigInteger
{
    using System;

    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Big integer");
            Console.WriteLine("***********");

            string proceed;
            do

            {
                string number1 = BigInteger.ReadBigInteger("Please enter 1. number: ");
                string number2 = BigInteger.ReadBigInteger("Please enter 2. number: ");
                Console.WriteLine();
                Console.WriteLine("Sum:     " + BigInteger.AddBigIntegers(number1, number2));
                Console.WriteLine("Product: " + BigInteger.MultiplyBigIntegers(number1, number2));
                Console.WriteLine();
                Console.Write("Continue with \"y\": ");
                proceed = Console.ReadLine();
            } while (proceed == "y");
        }
    }
}