/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Beschreibung: Demo for stringloop
*--------------------------------------------------------------
*/

using System;

string myString   = "Hallo Welt";
string obfuscated = "";

for (int idx = 0; idx < myString.Length; idx++)
{
    char ch = myString[idx];

    if (idx % 2 == 0)
    {
        obfuscated += ch;
    }
    else
    {
        obfuscated += '*';
    }
}

Console.WriteLine($"Obfuscate {myString} to {obfuscated}");

int countBlank = 0;
for (int idx = 0; idx < myString.Length; idx++)
{
    char ch = myString[idx];

    if (ch == ' ')
    {
        countBlank++;
    }
}

Console.WriteLine($"The string {myString} has {countBlank} blanks");

char lastChar = '!';
for (int idx = 0; idx < myString.Length; idx++)
{
    char ch = myString[idx];

    if (ch == lastChar)
    {
        Console.WriteLine($"found two '{ch}' at index {idx}");
    }

    lastChar = ch;
}

myString = "Hallo Welt ! hhhhh xx";
lastChar = '!';
int  charCount =0;
char charCounted= lastChar;
for (int idx = 0; idx < myString.Length; idx++)
{
    char ch = myString[idx];

    if (ch == lastChar)
    {
        charCounted = ch;
        charCount++;
    }
    else if (charCount > 0)
    {
        Console.WriteLine($"found {charCount+1} '{charCounted}' at index {idx}");
        charCount = 0;
    }
    else
    {
        charCount = 0;
    }

    lastChar = ch;
}

if (charCount > 0)
{
    Console.WriteLine($"found {charCount + 1} '{charCounted}' at end of string");
    charCount = 0;
}
