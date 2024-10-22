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

Console.Write("How old are you? ");
string userInput = Console.ReadLine();
int age       = int.Parse(userInput);

if (age >= 18 && age <= 20)
{
    Console.WriteLine("Your are grownup");
}
else
{
    if (age <= 18)
    {
        int diff = 18 - age;
        Console.WriteLine($"In approx. {diff} years you will be grown-up");
    }
    else
    {
        Console.WriteLine("You are too old to use that program");
    }
}