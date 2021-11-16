/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Beschreibung:
* Demo: Der Benutzer wird solange gefragt, bis ein gültiger Wert eingegeben wird.
* Es wird eine durchlaufende Schleife (do while) verwendet.
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Enter value");
Console.WriteLine("====================");
Console.WriteLine();

int userValue;

do
{
    Console.Write("Please enter value: [0..100]: ");
    userValue = Convert.ToInt32(Console.ReadLine());
} while (userValue < 0 || userValue > 100);

Console.WriteLine($"Your value is {userValue}");