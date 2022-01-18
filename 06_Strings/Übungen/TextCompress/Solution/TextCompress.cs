/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Textcompress - remove unnecessary Blanks
*--------------------------------------------------------------
*/

using System;

Console.Write("Please enter a sentence: ");

string input = Console.ReadLine();
string output = "";

int startIdx=0;

while (startIdx < input.Length && input[startIdx] == ' ')
{
    startIdx++;
}

int idx = startIdx;

while (idx < input.Length)
{
    if (!string.IsNullOrEmpty(output))
    {
        output += ' ';
    }

    while (idx < input.Length && input[idx] != ' ')
    {
        output += input[idx];
        idx++;
    }

    while (idx < input.Length && input[idx] == ' ')
    {
        idx++;
    }
}

Console.WriteLine($"Compressed sentence: \"{output}\"");
