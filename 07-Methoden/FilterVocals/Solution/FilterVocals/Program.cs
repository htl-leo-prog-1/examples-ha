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
            string input;
            do
            {
                Console.Write("Text: ");
                input = Console.ReadLine();
                var result = FilterVocals(input);
                Console.WriteLine($"Der Text \"{input}\" enthält {result.Length} Vokale: {result}");
            } while (!string.IsNullOrEmpty(input));
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
                if (IsVocal(ch) && !Contains(result,ch))
                {
                    result += ch;
                }
            }
            return result;
        }

        private static bool IsVocal(char ch)
        {
            ch = char.ToUpper(ch);
            return ch == 'A' || ch == 'E' || ch == 'I' || ch == 'O' || ch == 'U';
        }

        private static bool Contains(string text, char ch)
        {
            ch = char.ToUpper(ch);
            foreach (char textCh in text)
            {
                if (ch == char.ToUpper(textCh))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
