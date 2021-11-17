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
var decimalNumber = Convert.ToInt32(Console.ReadLine());

var remainingNumber = decimalNumber;
string binaryString = "";

while (remainingNumber > 0)
{
    var remaining = remainingNumber % 2;
    remainingNumber = remainingNumber / 2;

    binaryString = remaining + binaryString;
}

Console.WriteLine();
Console.WriteLine($"Decimal number: {decimalNumber} as binary: {binaryString}");