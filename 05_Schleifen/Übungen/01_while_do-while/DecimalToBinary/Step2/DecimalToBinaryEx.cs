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

Console.Write("Please enter a decimal value [0..] (-1 for exit): ");
var decimalValue = Convert.ToInt32(Console.ReadLine());

while (decimalValue != -1)
{
    var remaining = decimalValue;
    var binaryString = "";

    if (decimalValue == 0)
    {
        binaryString = "0";
    }
    else
    {
        if (remaining < 0)
        {
            remaining = -remaining;
        }

        while (remaining != 0)
        {
            var rem = remaining % 2;
            remaining = remaining / 2;

            binaryString = rem + binaryString;
            // Console.WriteLine($"remaining: {remaining}, Rest: {rem}");
        }
    }

    if (decimalValue < 0)
    {
        binaryString = "-" + binaryString;
    }

    Console.WriteLine($"Decimal: {decimalValue} => {binaryString}");

    Console.Write("Please enter a decimal value [0..] (-1 for exit): ");
    decimalValue = Convert.ToInt32(Console.ReadLine());
}