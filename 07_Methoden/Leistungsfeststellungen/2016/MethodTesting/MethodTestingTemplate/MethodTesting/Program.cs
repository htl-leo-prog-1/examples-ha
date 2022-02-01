/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1AHIF
 *--------------------------------------------------------------
 *              <NAME> 
 *--------------------------------------------------------------
 * Description:
 * Quiz related to MethodTesting
 * 3. 3. 2016
 *--------------------------------------------------------------
*/
using System;

namespace MethodTesting
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] test1 = {0, 1, 2, 3, 4};
            Assert(Average(test1) == 2, "Average: returns 2");
            int[] test2 = { 20, 15, 28, 77, 34, 12 }; 
            Assert(Average(test2) == 31, "Average: returns 31");
            int[] test3 = { -20, 15, 20, 22}; 
            Assert(Average(test3) == 9.25, "Average: returns 9,25");
            Assert(Double.IsNaN(Average(new int[] { })), "Average: empty returns not a number");
            Assert(Double.IsNaN(Average(null)), "Average: nothing returns not a number");

            Assert(HexCharToInt('c') == 12, "HexCharToInt: Lower c in hex is 12 in decimal");
            Assert(HexCharToInt('C') == 12, "HexCharToInt: Upper C in hex is 12 in decimal");
            Assert(HexCharToInt('0') == 0, "HexCharToInt: Zero is zero");
            Assert(HexCharToInt('!') == -1, "HexCharToInt: ! is not a hex character");
            Assert(HexCharToInt('G') == -1, "HexCharToInt: G is not a hex character");
            Assert(HexCharToInt('f') == 15, "HexCharToInt: F in hex is 15 in decimal");

            Assert(ReOrder("") == "", "ReOrder: empty string must be empty");
            Assert(ReOrder("aa") == "aa", "ReOrder: only a's");
            Assert(ReOrder("bbb") == "bbb", "ReOrder: only b's");
            Assert(ReOrder("bbaa") == "aabb", "ReOrder: bbaa");
            Assert(ReOrder("bababab") == "aaabbbb", "ReOrder: alternating bababab");

            Assert( IsCreditCardValid("2718281828458567"), "CreditCard: valid");
            Assert(!IsCreditCardValid("2718281828458566"), "CreditCard: invalid");
            Assert(!IsCreditCardValid("27182818284585666"), "CreditCard: too long");
            Assert(!IsCreditCardValid("2718281828X58566"), "CreditCard: contains a letter");
            Assert( IsCreditCardValid("2418281828458560"), "CreditCard: valid!");
            Assert(!IsCreditCardValid(""), "CreditCard: too short!");   
                    
            PrintSummary();
            Console.ReadKey();
        }

        /// <summary>
        /// Calculates the average from a given integer array
        /// </summary>
        /// <param name="array"></param>
        /// <returns>Average or Double.NaN in case no average could be calculated</returns>
        static double Average(int[] array)
        {
            return Double.NegativeInfinity;
        }

        /// <summary>
        /// The character passed as parameter is first checked,
        /// if it is a valid hexadecimal character. If yes,
        /// it is converted to the corresponding decimal value.
        /// In case of an invalid character, -1 is returned.
        /// </summary>
        /// <param name="hexChar"></param>
        /// <returns>Decimal value of the hex character 
        /// or -1 in case of an error.</returns>
        static int HexCharToInt(char hexChar)
        {
            return Int32.MinValue;
        }

        /// <summary>
        /// Re-order a string consisting only of characters a and b
        /// so that the re-ordered string starts with all a's followed by all b's
        /// </summary>
        /// <param name="abString">a string consisting of characters a and b
        /// in arbitrary order</param>
        /// <returns>the string ordered so that all a's come first and only then all b's</returns>
        static String ReOrder(string abString)
        {
            return "NotYetImplemented";
        }

        /// <summary>
        /// A creditCardNumber, which must contain 16 digits, is checked for
        /// correctness according to the specified algorithm.
        /// </summary>
        /// <param name="creditCardNumber"></param>
        /// <returns></returns>
        static bool IsCreditCardValid(string creditCardNumber)
        {
            return false; 
        }

        /// <summary>
        /// Assert the specified condition and reports message.
        /// </summary>
        /// <param name="condition">If set to <c>true</c> condition.</param>
        /// <param name="message">Message.</param>
        private static void Assert(bool condition, string message)
        {
            ConsoleColor originalColor = Console.ForegroundColor;

            if (condition)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message + " ... OK");
                passCount++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message + " ... Fail");
                failCount++;
            }
            Console.ForegroundColor = originalColor;
        }

        private static void PrintSummary()
        {
            Console.WriteLine("Total number of " + (passCount + failCount) + " test cases");
            Console.WriteLine(passCount + " tests passed");
            Console.WriteLine(failCount + " tests failed");
        }

        private static int passCount;
        private static int failCount;

    }
}
