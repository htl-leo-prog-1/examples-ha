/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: xAHIF
 *--------------------------------------------------------------
 *                Musterlösung 
 *--------------------------------------------------------------
 * Description:
 * Tells you, when you are grown up
 *--------------------------------------------------------------
*/

using System;

Console.WriteLine("How old are you? ");
string userInput = Console.ReadLine();
int    age       = Convert.ToInt32(userInput);

if (age > 18 && age < 21)
{
    Console.WriteLine("You are grown up");
}
else if (age <= 18)
{
    var diff = 18 - age;
    Console.WriteLine("In approx. " + diff + " years you will be grown-up");
}
else if (age is (>= 65 and <= 120))
{
    Console.WriteLine("Hallo Senior");
}
else if (age > 120)
{
    Console.WriteLine("Hallo Zombi");
}
else
{
    Console.WriteLine("Hallo");
}