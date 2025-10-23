/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: TextJustify with UnitTests
 *--------------------------------------------------------------
 */

namespace StringMethodsEx
{
    using System;

    public class Program
    {
        static void Main()
        {
            Console.WriteLine("String Methods (IndexOf,Replace)");
            Console.WriteLine("****************************");

            string input;

            Console.Write("Search-String: ");
            string searchString = Console.ReadLine();

            Console.Write("Replace-String: ");
            string replaceString = Console.ReadLine();

            do
            {
                Console.Write("String: ");
                input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    int startIdx = 0;
                    int foundIndex;
                    do
                    {
                        foundIndex = StringMethods.IndexOf(input, searchString, startIdx);
                        Console.WriteLine($"IndexOf(\"{input}\", \"{searchString}\", {startIdx})  = {foundIndex}");
                        startIdx = startIdx == foundIndex ? startIdx + 1 : foundIndex;
                    } while (foundIndex >= 0);

                    startIdx = input.Length - 1;
                    do
                    {
                        foundIndex = StringMethods.LastIndexOf(input, searchString, startIdx);
                        Console.WriteLine($"LastIndexOf(\"{input}\", \"{searchString}\", {startIdx})  = {foundIndex}");
                        startIdx = startIdx == foundIndex ? startIdx - 1 : foundIndex;
                    } while (startIdx >= 0);

                    string replaced = StringMethods.Replace(input, searchString, replaceString);
                    Console.WriteLine($"Replace(\"{input}\", \"{searchString}\", \"{replaceString}\")  = \"{replaced}\"");
                }
            } while (!string.IsNullOrEmpty(input));
        }
    }
}