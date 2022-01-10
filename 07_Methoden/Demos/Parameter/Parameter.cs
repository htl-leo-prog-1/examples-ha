/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Eingabe Verarbeitung Ausgabe, Parameterübergabe
*--------------------------------------------------------------
*/

using System;

string userInput;
int countOfA = 0;
int countOfB = 0;

void Eingabe()
{
    Console.Write("Please enter string: ");
    userInput = Console.ReadLine();
}

int CountOf(string str, char ch)
{
    int countOf = 0;
    for (int i = 0; i < str.Length; i++)
    {
        if (userInput[i] == ch)
        {
            countOf++;
        }
    }

    return countOf;
}

void Verarbeitung()
{
    /*
    for (int i = 0; i < userInput.Length; i++)
    {
        if (userInput[i] == 'A')
        {
            countOfA++;
        }
    }
    
    for (int i = 0; i < userInput.Length; i++)
    {
        if (userInput[i] == 'B')
        {
            countOfB++;
        }
    }
    */
    countOfA = CountOf(userInput, 'A');
    countOfB = CountOf(userInput, 'B');
}

void OutputCountOf(char ch, int countOf)
{
    Console.WriteLine($"Count of '{ch}': {countOf} ");
}

void Ausgabe()
{
    /*
    Console.WriteLine($"Count of 'A': {countOfA} ");
    Console.WriteLine($"Count of 'B': {countOfB} ");
    */
    OutputCountOf('A',countOfA);
    OutputCountOf('B', countOfB);
}

Eingabe();
Verarbeitung();
Ausgabe();