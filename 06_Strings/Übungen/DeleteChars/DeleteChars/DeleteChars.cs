using System;

string input;
string eliminatorText;
string result = "";
int searchIndex;

Console.WriteLine("DeleteChars");
Console.WriteLine("===========");
Console.WriteLine();
Console.Write("Eingabetext: ");
input = Console.ReadLine();
Console.Write("Eliminatortext: ");
eliminatorText = Console.ReadLine();

for (int i = 0; i < input.Length; i++)
{
    searchIndex = 0;
    while (searchIndex < eliminatorText.Length &&
           input[i] != eliminatorText[searchIndex])
    {
        searchIndex++;
    }

    if (searchIndex == eliminatorText.Length)
    {
        result += input[i];
    }
}

Console.WriteLine("Ausgabetext: " + result);