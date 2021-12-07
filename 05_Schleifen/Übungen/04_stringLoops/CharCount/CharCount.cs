/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: CharCount
* Zählt die Anzahl der Zeichen in einem String
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Count characters in a string");
Console.WriteLine("****************************");

Console.Write("Please enter a string: ");
string text = Console.ReadLine();

Console.Write("Please enter search-characters: ");
string countCharacters = Console.ReadLine();

for (int n = 0; n < countCharacters.Length; n++)
{
    char ch = countCharacters[n];
    int count = 0;
    for (int i = 0; i < text.Length; i++)
    {
        if (text[i] == ch)
        {
            count++;
        }
    }
    Console.WriteLine($"'{ch}' : {count}");
}
