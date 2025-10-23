/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Implemetn String.Slit and Join  
*--------------------------------------------------------------
*/

using System;

string Join(string separator, string[] strings)
{
    string result = string.Empty;

    foreach (var str in strings)
    {
        if (!string.IsNullOrEmpty(result))
        {
            result += separator;
        }

        result += str;
    }

    return result;
}

string[] Split(string str, char separator)
{
    string[] result = new string[WordCount(str, separator)];

    int wordIdx = 0;
    int idx = Skip(str, separator, 0);

    while (idx < str.Length)
    {
        // idx = begin of word
        string word = string.Empty;
        
        while (idx < str.Length && str[idx] != separator)
        {
            word += str[idx];
            idx++;
        }

        result[wordIdx] = word;
        wordIdx++;

        idx = Skip(str, separator, idx);
    }

    return result;
}

int WordCount(string str, char separator)
{
    int wordCount = 0;
    int idx = Skip(str, separator, 0);

    while (idx < str.Length)
    {
        wordCount++;

        while (idx < str.Length && str[idx] != separator)
        {
            idx++;
        }

        idx = Skip(str, separator, idx);
    }

    return wordCount;
}

int Skip(string str, char ch, int idx)
{
    while (idx < str.Length && str[idx] == ch)
    {
        idx++;
    }

    return idx;
}

char ReadChar(string message)
{
    char ch = (char) 0;

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

string ReadString(string message, int minLength, int maxLenght)
{
    string read;
    do
    {
        Console.Write(message);
        read = Console.ReadLine();
    } while (read.Length < minLength || read.Length > maxLenght);

    return read;
}

Console.WriteLine("String Split and Join");
Console.WriteLine("**********************");

string input;

var separatorSplit = ReadChar("Separator(char) \"Split\" : ");
var separatorJoin = ReadString("Separator(string) \"Join\": ", 1, int.MaxValue);


do
{
    Console.Write("String: ");
    input = Console.ReadLine();
    if (!string.IsNullOrEmpty(input))
    {
        var result = Join(separatorJoin, Split(input, separatorSplit));
        Console.WriteLine($"Result: \"{result}\"");
    }
} while (!string.IsNullOrEmpty(input));