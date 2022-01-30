/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: TextJustify - add as many ' ' between words to fill line.
*--------------------------------------------------------------
*/

using System;

int ReadNumber(string message, int max, int min)
{
    int number;
    bool isOk;
    do
    {
        Console.Write($"{message} [{min}..{max}]: ");
        isOk = int.TryParse(Console.ReadLine(), out number) && number >= min && number <= max;
    } while (!isOk);

    return number;
}

int SkipSpaces(string str, int idx)
{
    while (idx < str.Length && str[idx] == ' ')
    {
        idx++;
    }

    return idx;
}

string DuplicateChar(char ch, int count)
{
    return new string(ch, count);
}

string TextCompress(string input)
{
    string output = "";

    int idx = SkipSpaces(input, 0);

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

        idx = SkipSpaces(input, idx);
    }

    return output;
}

int WordCount(string input)
{
    int count = 0;
    int idx = SkipSpaces(input, 0);

    while (idx < input.Length)
    {
        count++;

        while (idx < input.Length && input[idx] != ' ')
        {
            idx++;
        }

        idx = SkipSpaces(input, idx);
    }

    return count;
}

string TextJustify(string sentence, int charPerLine)
{
    sentence = TextCompress(sentence);
    int wordCount = WordCount(sentence);

    if (wordCount < 2 || sentence.Length > charPerLine)
    {
        return sentence;
    }

    int addBlanks = charPerLine - sentence.Length;
    int addBlanksPerWord = addBlanks / (wordCount-1);
    int addBlankRest = addBlanks - (addBlanksPerWord * (wordCount - 1));

    string output = "";

    int idx = 0;

    while (idx < sentence.Length)
    {
        if (!string.IsNullOrEmpty(output))
        {
            int addRounded = addBlankRest > 0 ? 1 : 0;
            output += DuplicateChar(' ', 1+ addBlanksPerWord+ addRounded);
            addBlankRest--;
        }

        while (idx < sentence.Length && sentence[idx] != ' ')
        {
            output += sentence[idx];
            idx++;
        }

        idx++;
    }

    return output;
}

Console.WriteLine("Text justify");
Console.WriteLine("************");

int charPerLine = ReadNumber("Please enter the number of char per line: ",200,1);

Console.Write("InputText: ");
string sentence = Console.ReadLine();

while (!string.IsNullOrEmpty(sentence)) 
{
    Console.WriteLine($"Justified: {TextJustify(sentence, charPerLine)}");
    Console.Write(     "InputText: ");
    sentence = Console.ReadLine();
}
