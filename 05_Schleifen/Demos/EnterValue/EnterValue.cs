/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Beschreibung:
* Demo: Der Benutzer wird solange gefragt, bis ein gültiger Wert eingegeben wird.
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Enter value");
Console.WriteLine("====================");
Console.WriteLine();

Console.Write("Please enter a number: [0..100]: ");
var userValue = Convert.ToInt32(Console.ReadLine());

while (userValue < 0 || userValue > 100)
{
    Console.WriteLine("Wrong input!");
    Console.Write("Please enter a number: [0..100]: ");
    userValue = Convert.ToInt32(Console.ReadLine());
}

Console.WriteLine($"Your have entered: {userValue}");