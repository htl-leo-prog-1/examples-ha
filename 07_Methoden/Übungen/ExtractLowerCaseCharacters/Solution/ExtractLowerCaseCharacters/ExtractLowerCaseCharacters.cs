/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: ExtractLowerCaseCharacters with UnitTests
*--------------------------------------------------------------
*/
using System;

namespace ExtractLowerCaseCharacters;

public class Program
{
    static void Main()
    {
        Console.WriteLine("Extract lower case characters");
        Console.WriteLine("=============================");

        Console.Write("Text eingeben: ");
        string text = Console.ReadLine();
        
        Console.Write("Startindex: ");
        string input = Console.ReadLine();
        int startIndex = Convert.ToInt32(input);
        
        Console.Write("Länge: ");
        input = Console.ReadLine();
        
        var length = Convert.ToInt32(input);
        var result = ExtractLowerCaseCharacters(text, startIndex, length);
        Console.WriteLine($"Der Ergebnistext lautet \"{result}\"");
        Console.WriteLine();
    }


    /// <summary>
    /// Liefert aus dem übergebenen Text ab der Position startPosition (0-basiert) count 
    /// Kleinbuchstaben zurück. Gibt es nicht mehr so viele Kleinbuchstaben bis zum Textende,
    /// werden die verfügbaren Kleinbuchstaben zurückgegeben.
    /// Die ermittelten Kleinbuchstaben werden zu einem Ergebnisstring konkateniert!
    /// </summary>
    /// <param name="text">zu analysierender Text</param>
    /// <param name="startPosition"> ab wo werden die Kleinbuchstaben ermittelt</param>
    /// <param name="count">Anzahl der gewünschten Kleinbuchstaben</param>
    /// <returns>Text, der die ermittelten Kleinbuchstaben enthält</returns>
    public static string ExtractLowerCaseCharacters(string text, int startPosition, int count)
    {
        string result = "";
        int position = startPosition;
        while (count > 0 && position < text.Length)
        {
            char ch = text[position];
            if (ch >= 'a' && ch <= 'z')
            {
                result += ch;
                count--;
            }

            position++;
        }

        return result;
    }
}
