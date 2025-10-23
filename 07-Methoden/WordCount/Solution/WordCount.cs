/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Count the words in a sentence (=string)
*--------------------------------------------------------------
*/

using System;

int WordCount(string sentence)
{
    int wordCount = 0;

    int startIdx = 0;
    while (startIdx < sentence.Length && sentence[startIdx] == ' ')
    {
        startIdx++;
    }

    int idx = startIdx;

    while (idx < sentence.Length)
    {
        wordCount++;

        while (idx < sentence.Length && sentence[idx] != ' ')
        {
            idx++;
        }

        while (idx < sentence.Length && sentence[idx] == ' ')
        {
            idx++;
        }
    }

    return wordCount;
}

bool IsEndWord(string word)
{
    return word == "end";
}

Console.WriteLine("Count words in a sentence");
Console.WriteLine("****************************");

string input;

do
{
    Console.Write("Sentence: ");
    input = Console.ReadLine();
    if (!IsEndWord(input))
    {
        int wordCount = WordCount(input);
        Console.WriteLine($"The sentence \"{input}\" has {wordCount} words.");
    }
} 
while (!IsEndWord(input));