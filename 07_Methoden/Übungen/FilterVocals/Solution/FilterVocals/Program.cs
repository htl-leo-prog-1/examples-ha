/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: FilterVocals with UnitTests
*--------------------------------------------------------------
*/

using System;

namespace FilterVocals
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Vokale aus Text extrahieren");
            Console.WriteLine("===========================");
            Console.Write("Text: ");
            var input = Console.ReadLine();
            Console.WriteLine();
            var result = FilterVocals(input);
            Console.WriteLine($"Der Text \"{input}\" enthält {result.Length} Vokale: {result}");
            Console.Write("Beenden mit Eingabetaste ...");
            Console.ReadLine();
        }


        /// <summary>
        /// Aus einem Text sind alle Vokale a,e,i,o,u zu filtern.
        /// Kommt ein Vokal öfter vor, ist nur das erste Auftreten zu
        /// berücksichtigen!
        /// Die Vokale können sowohl groß als auch klein geschrieben
        /// werden.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Text, der die Vokale enthält</returns>
        public static string FilterVocals(string text)
        {
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];
                if (ch == 'A' || ch == 'E' || ch == 'I' || ch == 'O' || ch == 'U' ||
                    ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
                {
                    var searchIndex = 0;
                    while (searchIndex < result.Length && char.ToLower(result[searchIndex]) != char.ToLower(ch))
                    {
                        searchIndex++;
                    }
                    if (searchIndex == result.Length)
                    {
                        result += ch;
                    }
                }
            }
            return result;
        }
    }
}
