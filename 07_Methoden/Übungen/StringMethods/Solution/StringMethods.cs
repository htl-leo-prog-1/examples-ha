/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: String methods
*--------------------------------------------------------------
*/

using System;

bool Contains(string str, char ch)
{
    for (int i = 0; i < str.Length; i++)
    {
        if (str[i] == ch)
        {
            return true;
        }
    }

    return false;
}

int IndexOf(string str, char ch, int startIdx)
{
    for (int i = startIdx; i < str.Length; i++)
    {
        if (str[i] == ch)
        {
            return i;
        }
    }

    return -1;
}

int LastIndexOf(string str, char ch)
{
    for (int i = str.Length - 1; i >= 0; i--)
    {
        if (str[i] == ch)
        {
            return i;
        }
    }

    return -1;
}

string SubString(string str, int startIdx, int count)
{
    string output = string.Empty;
    for (int i = startIdx; i < str.Length && i < startIdx + count; i++)
    {
        output += str[i];
    }

    return output;
}

string TrimStart(string str, char ch)
{
    int idx = 0;

    while (idx < str.Length && str[idx] == ch)
    {
        idx++;
    }

    return SubString(str, idx, str.Length);
}

string TrimEnd(string str, char ch)
{
    int idx = str.Length - 1;

    while (idx >= 0 && str[idx] == ch)
    {
        idx--;
    }

    return SubString(str, 0, idx + 1);
}

string Trim(string str, char ch)
{
    return TrimEnd(TrimStart(str, ch), ch);
}

string Remove(string str, int idx, int count)
{
    string result = SubString(str, 0, idx);

    if (idx + count < str.Length)
    {
        result += SubString(str, idx + count, str.Length);
    }

    return result;
}

char ReadChar(string message)
{
    char ch = (char)0;

    do
    {
        Console.Write(message);
        string read = Console.ReadLine();

        if (read.Length == 1)
        {
            ch = read[0];
        }
    } while (ch == 0);

    return ch;
}


Console.WriteLine("String Methods");
Console.WriteLine("****************************");

string input;

var findCh = ReadChar("Char for \"IndexOf\": ");
var trimCh = ReadChar("Char for \"Trim\":    ");

do
{
    Console.Write("String: ");
    input = Console.ReadLine();
    if (!string.IsNullOrEmpty(input))
    {
        int firstIdx = IndexOf(input, findCh, 0);
        Console.WriteLine($"IndexOf(\"{input}\", \'{findCh}\', 0)  = {firstIdx}");

        int lastIdx = LastIndexOf(input, findCh);
        Console.WriteLine($"LastIndexOf(\"{input}\", \'{findCh}\') = {lastIdx}");

        bool contains = Contains(input, findCh);
        Console.WriteLine($"Contains(\"{input}\", \'{findCh}\')    = {contains}");

        string trimStart = TrimStart(input, trimCh);
        Console.WriteLine($"TrimStart(\"{input}\", \'{trimCh}\')   = \"{trimStart}\"");

        string trimEnd = TrimEnd(input, trimCh);
        Console.WriteLine($"TrimEnd(\"{input}\", \'{trimCh}\')     = \"{trimEnd}\"");

        string trim = Trim(input, trimCh);
        Console.WriteLine($"Trim(\"{input}\", \'{trimCh}\')        = \"{trim}\"");

        string removed = Remove(input, 2, 2);
        Console.WriteLine($"Remove(\"{input}\", 2, 2)     = \"{removed}\"");
    }
} while (!string.IsNullOrEmpty(input));