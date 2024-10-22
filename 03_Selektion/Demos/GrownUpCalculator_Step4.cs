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

if (age == 25 || age == 50)
{
    Console.WriteLine("Congratulations for your round birthday");
}
else
{
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
            Console.WriteLine("You to old to use this program");
        }
    }
}