/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung
*--------------------------------------------------------------
* Description: Count the unique words in a word array 
*--------------------------------------------------------------
*/

using System;

const int MAX_INPUT = 255;

Console.WriteLine("Word Count");
Console.WriteLine("==========");
Console.WriteLine();

var inputWords = new string[MAX_INPUT];
int i = 0;

Console.WriteLine($"Please enter words (maximum {MAX_INPUT} words, finish input with the word 'fertig' or 'ready')");
Console.WriteLine();

do
{
    inputWords[i] = Console.ReadLine();
    i++;
} while (i < MAX_INPUT && (inputWords[i - 1] != "fertig" && inputWords[i - 1] != "ready"));

int totalNumberOfWords = i - 1;

var wordTable = new string[totalNumberOfWords];
var wordCountTable = new int[totalNumberOfWords];
int numberOfWordsInTable = 0;

for (i = 0; i < totalNumberOfWords; i++)
{
    int j = 0;
    while (j < numberOfWordsInTable && wordTable[j] != inputWords[i])
    {
        j++;
    }

    if (j == numberOfWordsInTable)
    {
        wordTable[numberOfWordsInTable] = inputWords[i];
        wordCountTable[numberOfWordsInTable] = 1;
        numberOfWordsInTable++;
    }
    else
    {
        wordCountTable[j]++;
    }
}

Console.WriteLine();
Console.WriteLine("Words Count Statistics");
Console.WriteLine();

for (i = 0; i < numberOfWordsInTable; i++)
{
    Console.WriteLine($"{wordTable[i],-20}{wordCountTable[i]}");
}