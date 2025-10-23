/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: HexDump
 * Gibt einen String in Hex Darstellug aus
 *--------------------------------------------------------------
 */

using System;

Console.WriteLine("HexDump");
Console.WriteLine("****************************");

const int CountPerLine = 8;

string toHex = "0123456789ABCDEF";
string text = "";

Console.Write("Please enter a string (or END): ");
string input = Console.ReadLine();

while (input != null && input != "END")
{
    if (text != "")
    {
        text += "\n";
    }

    text += input;
    Console.Write("Please enter a string (or END): ");
    input = Console.ReadLine();
}

Console.WriteLine("****************************");

string asAscii = "";

for (int i = 0; i < text.Length; i++)
{
    char ch = text[i];

    asAscii += char.IsLetterOrDigit(ch) ? ch : '.';

    Console.Write($"{toHex[ch / 16]}{toHex[ch % 16]} ");

    if (i % CountPerLine == (CountPerLine - 1))
    {
        Console.WriteLine($"'{asAscii}'");
        asAscii = "";
    }
}

if (!string.IsNullOrEmpty(asAscii))
{
    for (int i = 0; i < CountPerLine - (text.Length % CountPerLine); i++)
    {
        Console.Write("   ");
    }

    Console.WriteLine($"'{asAscii}'");
}

Console.WriteLine("****************************");