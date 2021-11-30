/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
 * Beschreibung:
 * Das Programm wandelt eine positve Ganzzahl in einern Term um.
 * Bei der Eingabe von z.B. der Zahl 11 durckt das Programm:
 * 2^3 + 2^1 + 2^0
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Convert decimal to binary");
Console.WriteLine("======================================");
Console.WriteLine();

bool isOk;
int number;

do
{
    Console.Write("Please enter number [1..]: ");
    isOk = int.TryParse(Console.ReadLine(), out number);
} while (!isOk || number < 1);


var remainingNumber = number;
string termString = "";

for (int bit = 0; remainingNumber > 0; bit++)
{
    var remaining = remainingNumber % 2;
    remainingNumber = remainingNumber / 2;

    if (remaining > 0)
    {
        if (!string.IsNullOrEmpty(termString!))
        {
            termString = " + " + termString;
        }
        termString = $"2^{bit}" + termString;
    }
}

Console.WriteLine();
Console.WriteLine($"The number {number} can be written as: {termString}");