/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: <CLASSNAME>
 *--------------------------------------------------------------
 *              Robert Reder 
 *--------------------------------------------------------------
 * Description:
 * The program Coffee2Go lets one buy a cup of coffee
 *--------------------------------------------------------------
*/

using System;

const int PRICE = 50;
int       sumThrownIn;
int       throwIn;
int       centsToReturn;

Console.WriteLine("**********************************************");
Console.WriteLine("*          Willkommen bei Coffee2Go          *");
Console.WriteLine("*  Der Preis einer Tasse Kaffee ist 50 Cent  *");
Console.WriteLine("*  Folgende Muenzen werden akzeptiert:       *");
Console.WriteLine("*  5, 10, 20, 50, 100, 200 Cent              *");
Console.WriteLine("**********************************************");

// Loop to get more than one coffee
do
{
    sumThrownIn = 0;
    Console.WriteLine();
    Console.WriteLine("**********************************************");

    // Loop to enter enough coins
    do
    {
        Console.Write("Bisher eingeworfen {0}, Einwurf in Cent: ", sumThrownIn);
        throwIn = Convert.ToInt32(Console.ReadLine());

        if (throwIn == 5 || throwIn == 10 || throwIn == 20 || throwIn == 50 || throwIn == 100 || throwIn == 200)
        {
            sumThrownIn = sumThrownIn + throwIn;
        }
        else
        {
            Console.WriteLine("Bitte geben sie gültige Münzen ein!");
        }
    } while (sumThrownIn < PRICE);

    centsToReturn = sumThrownIn - PRICE;
    Console.WriteLine("\n. . . .  K A F F E E -- A U S G A B E  . . . .\n\nEinwurf: {0} Cent ==> Retourgeld: {1} Cent", sumThrownIn, centsToReturn);
    Console.Write("Wollen Sie noch eine Tasse Kaffee? (j/J): ");
} while (Console.ReadLine().ToUpper() == "J");