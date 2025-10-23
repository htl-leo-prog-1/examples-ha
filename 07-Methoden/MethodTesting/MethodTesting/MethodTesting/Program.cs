using System;

namespace MethodTesting
{
    class Program
    {
        static void Main(string[] args)
        {

            Assert(GetSplittingLine('-', 5) == "-----", "Trennlinie mit 5 Bindestrichen");
            Assert(GetSplittingLine('*', 3) == "***", "Trennlinie mit 3 Sternen");

            int[] test1 = {0, 1, 2, 3, 4};
            int[] test2 = {0, 1, 2, 3, 4};
            Assert(Compare(test1, test2), "Compare: Zwei gleiche Int-Arrays");
            int[] test3 = { 0 };
            Assert(!Compare(test1, test3), "Compare: Zwei ungleiche Int-Arrays");

            Assert(GetMaximum(test1) == 4, "GetMaximum liefert 4");
            Assert(!(GetMaximum(test1) == 0), "GetMaximum darf nicht 0 liefern");
            Assert((GetMaximum(test3) == 0), "GetMaximum liefert 0");

            Assert(IsElementOf("abcdefg", 'd'), "IsElementOf: 'd' ist in 'abcdefg' enthalten");
            Assert(!IsElementOf("abcdefg", 'h'), "IsElementOf: 'h' ist in 'abcdefg' nicht enthalten");

            PrintSummary();
            Console.ReadKey();

        }

        /// <summary>
        /// Returns a string of the given length
        /// filled with the given character.
        /// </summary>
        static string GetSplittingLine(char c, int length)
        {
            string s = "";
            // TODO: Implement
            return s;
        }

        /// <summary>
        /// Returns if the two given integer arrays have the same size and content.
        /// </summary>
        static bool Compare(int[] intArray1, int[] intArray2)
        {
            // TODO: Implement
            return false;
        }

        /// <summary>
        /// Returns if the given character is part of the given string
        /// </summary>
        static bool IsElementOf(string s, char c)
        {
            // TODO: Implement
            return false;
        }

        /// <summary>
        /// Returns the maximum number from the given integer array
        /// </summary>
        static int GetMaximum(int[] intArray)
        {
            // TODO: Implement
            return Int32.MinValue;
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
                Console.WriteLine(message + "... OK");
                passCount++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message + "... Fail");
                failCount++;
            }
            Console.ForegroundColor = originalColor;
        }

        private static void PrintSummary()
        {
            Console.WriteLine(GetSplittingLine('_', 80));
            Console.WriteLine("Total number of " + (passCount + failCount) + " test cases");
            Console.WriteLine(passCount + " tests passed");
            Console.WriteLine(failCount + " tests failed");
        }

        private static int passCount;
        private static int failCount;

    }
}
