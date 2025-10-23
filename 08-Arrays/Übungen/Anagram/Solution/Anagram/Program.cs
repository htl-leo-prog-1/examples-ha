/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Anagram
*--------------------------------------------------------------
*/

namespace Anagram;

using System;

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("*** Anagram Checker ***");
        Console.WriteLine();

        var firstWord = ReadText("Please enter 1. word", 1, 30);
        var secondWord = ReadText("Please enter 2. word", 1, 30);

        if (Anagram.IsAnagram(firstWord, secondWord))
        {
            var convert = Anagram.GetAnagramConversion(firstWord, secondWord);
            var result = Anagram.ConvertAnagram(firstWord, convert);
            Console.WriteLine($"Base: \"{ string.Join(" ", firstWord.ToCharArray())}\"");
            Console.WriteLine($"Idx:  \"{ string.Join(" ", convert)}\"");
            Console.WriteLine($"To:   \"{ string.Join(" ", secondWord.ToCharArray())}\"");
            Console.WriteLine($"Calc: \"{ string.Join(" ", result.ToCharArray())}\"");
        }
        else
        {
            Console.WriteLine($"\"{firstWord}\" and \"{secondWord}\" are no anagrams!");
        }
    }

    static string ReadText(string message, int minLength, int maxLength)
    {
        bool isOk;
        string text;
        do
        {
            Console.Write($"{message}, Length:{minLength}-{maxLength}): ");
            text = Console.ReadLine();

            isOk = text.Length >= minLength && text.Length <= maxLength;

            if (!isOk)
            {
                Console.WriteLine("Invalid input, try again...");
            }
        } while (!isOk);

        return text;
    }
}