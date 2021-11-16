/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Beschreibung:
* Der Benutzer wird solange gefragt, bis ein gültiger Wert eingegeben wird.
* Die Eingabe kann mit 0 abgebrochen werden.
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Enter value");
Console.WriteLine("====================");
Console.WriteLine();

Console.Write("Please enter value: [1..100] (0 for exit): ");
var userValue = Convert.ToInt32(Console.ReadLine());

while ((userValue < 1 || userValue > 100) && userValue != 0)
{
    Console.WriteLine("Wrong input!");
    Console.Write("Please enter value: [1..100] (0 for exit): ");
    userValue = Convert.ToInt32(Console.ReadLine());
}

if (userValue == 0)
{
    Console.WriteLine($"0 for Exit");
}
else
{
    Console.WriteLine($"Your value is {userValue}");
}