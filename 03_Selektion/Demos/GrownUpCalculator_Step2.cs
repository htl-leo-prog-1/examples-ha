/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: xABIF
 *--------------------------------------------------------------
 *              Herbert Aitenbichler 
 *--------------------------------------------------------------
 * Description:
 * Tells you, when you are grown up
 *--------------------------------------------------------------
*/

using System;

const int GROWN_UP_AGE = 18;

Console.Write("How old are you? ");
string userInput = Console.ReadLine();
int age       = int.Parse(userInput);

if (age <= GROWN_UP_AGE)
{
    var diff = GROWN_UP_AGE - age;
    Console.WriteLine($"In approx. {diff} years you will be grown-up");
}
else
{
    Console.WriteLine("You to old to use this program");
}