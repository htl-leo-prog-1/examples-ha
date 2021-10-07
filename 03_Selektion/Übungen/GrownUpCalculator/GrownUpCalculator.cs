/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1AHIF
 *--------------------------------------------------------------
 * Exercise Number: 04
 * File:			GrownUpCalculator.cs
 * Author(s):		Peter Bauer
 * Due Date:		
 *--------------------------------------------------------------
 * Description:
 * Tells you, when you are grown up
 *--------------------------------------------------------------
*/

using System;

const int GROWN_UP_AGE = 18;

Console.WriteLine("How old are you? ");
string userInput = Console.ReadLine();
int    age       = Convert.ToInt32(userInput);

int diff = GROWN_UP_AGE - age;

if (age > 18 && age < 21)
{
    Console.WriteLine("You are grown up");
}
else
{
    if (diff > 0)
    {
        Console.WriteLine("In approx. " + diff + " years you will be grown-up");
    }
    else
    {
        Console.WriteLine("You are too old to use that program");
    }
}