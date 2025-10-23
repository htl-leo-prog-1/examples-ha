/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
 * Beschreibung:
 * Das Programm wandelt eine positve Ganzzahl aus dem Dezimalsystem
 * in das Binärsystem um
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Convert decimal to binary");
Console.WriteLine("======================================");
Console.WriteLine();
Console.Write("Please enter decimal value [int, >=0]: ");
int decimalNumber = int.Parse(Console.ReadLine());

int remainingNumber = decimalNumber;
string binaryString = "";

while (remainingNumber > 0)
{
    int remaining = remainingNumber % 2;
    remainingNumber /= 2;

    binaryString = remaining + binaryString;
}

Console.WriteLine();
Console.WriteLine($"Decimal number: {decimalNumber} as binary: {binaryString}");