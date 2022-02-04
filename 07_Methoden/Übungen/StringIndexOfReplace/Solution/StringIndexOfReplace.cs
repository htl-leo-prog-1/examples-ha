/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: String methods (IndexOf,Replace)
*--------------------------------------------------------------
*/

using System;


int IndexOf(string str, string searchString, int startIdx)
{
    //return str.IndexOf(searchString, startIdx);
    if (!string.IsNullOrEmpty(searchString) && startIdx >= 0)
    {
        for (int i = startIdx; i < str.Length; i++)
        {
            bool isEqual = str.Length - i >= searchString.Length;
            for (int j = 0; j < searchString.Length && j + i < str.Length && isEqual; j++)
            {
                if (str[i + j] != searchString[j])
                {
                    isEqual = false;
                }
            }

            if (isEqual)
            {
                return i;
            }
        }
    }

    return -1;
}

int LastIndexOf(string str, string searchString, int startIdx)
{
    // return str.LastIndexOf(searchString, startIdx);
    if (!string.IsNullOrEmpty(searchString) && startIdx < str.Length && startIdx >= 0)
    {
        for (int i = startIdx; i >= 0; i--)
        {
            bool isEqual = str.Length - i >= searchString.Length;
            for (int j = 0; j < searchString.Length && j + i < str.Length && isEqual; j++)
            {
                if (str[i + j] != searchString[j])
                {
                    isEqual = false;
                }
            }

            if (isEqual)
            {
                return i;
            }
        }
    }

    return -1;
}


string Replace(string str, string oldValue, string newValue)
{
    //return str.Replace(oldValue, newValue);
    string result = String.Empty;

    int idx = 0;
    int nextIdx = str.IndexOf(oldValue, idx);

    while (nextIdx >= 0)
    {
        result += SubString(str, idx, nextIdx - idx);
        result += newValue;

        idx = nextIdx + oldValue.Length;

        nextIdx = str.IndexOf(oldValue, idx);
    }

    return result + SubString(str, idx, str.Length);
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
            foundIndex = IndexOf(input, searchString, startIdx );
            Console.WriteLine($"IndexOf(\"{input}\", \"{searchString}\", {startIdx})  = {foundIndex}");
            startIdx = startIdx == foundIndex ? startIdx + 1 : foundIndex;
        } while (foundIndex >= 0);

        startIdx = input.Length-1;
        do
        {
            foundIndex = LastIndexOf(input, searchString, startIdx);
            Console.WriteLine($"LastIndexOf(\"{input}\", \"{searchString}\", {startIdx})  = {foundIndex}");
            startIdx = startIdx == foundIndex ? startIdx - 1 : foundIndex;
        } while (startIdx >= 0);

        string replaced = Replace(input, searchString, replaceString);
        Console.WriteLine($"Replace(\"{input}\", \"{searchString}\", \"{replaceString}\")  = \"{replaced}\"");
    }
} while (!string.IsNullOrEmpty(input));