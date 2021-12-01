/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Beschreibung:
* Demo: Der Benutzer wird solange gefragt, bis ein gültiger Wert eingegeben wird.
* Mit TryParse wird zusätzlich geprüft, ob die Zahl gültig ist
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Enter value");
Console.WriteLine("====================");
Console.WriteLine();

int userValue;

Console.Write("Please enter a number: [0..100]: ");
var isValueOk = int.TryParse(Console.ReadLine(), out userValue) &&
                userValue >= 0 &&
                userValue <= 100;

while (!isValueOk)
{
    Console.WriteLine("Wrong input!");
    Console.Write("Please enter a number: [0..100]: ");
    isValueOk = int.TryParse(Console.ReadLine(), out userValue) &&
                userValue >= 0 &&
                userValue <= 100;
}

Console.WriteLine($"Your have entered: {userValue}");