/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
 * Beschreibung:
 * Das Programm wandelt eine positve Ganzzahl aus dem Dezimalsystem
 * in das Binärsystem um.
*--------------------------------------------------------------
*/

using System;

Console.Write("Please enter a decimal value [0..] (-1 for exit): ");
int decimalValue = int.Parse(Console.ReadLine());

while (decimalValue != -1)
{
    int remaining = decimalValue;
    string binaryString = "";

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
            int rem = remaining % 2;
            remaining /= 2;

            binaryString = rem + binaryString;
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