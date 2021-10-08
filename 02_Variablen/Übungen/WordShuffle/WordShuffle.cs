/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: xAHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description:
* Drei strings einspeichern und sie in den 6 möglichen reihenfolgen
* wieder ausgeben.
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Word Shuffle");
Console.WriteLine("============");
Console.WriteLine();

Console.Write("Please enter 1st word:");
string word1 = Console.ReadLine();

Console.Write("Please enter 2st word: ");
string word2 = Console.ReadLine();

Console.Write("Please enter 3st word: ");
string word3 = Console.ReadLine();

Console.WriteLine();
Console.WriteLine($"{word1} {word2} {word3}");
Console.WriteLine($"{word2} {word3} {word1}");
Console.WriteLine($"{word3} {word1} {word2}");
Console.WriteLine($"{word1} {word3} {word2}");
Console.WriteLine($"{word2} {word1} {word3}");
Console.WriteLine($"{word3} {word2} {word1}");