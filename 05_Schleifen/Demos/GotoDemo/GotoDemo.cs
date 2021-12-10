/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Beschreibung:
* Goto Demo => bitte NIEMALS verwenden
*--------------------------------------------------------------
*/

// Das ist ein Beispiel wie man es NICHT machen soll!

// Das ist ein Beispiel wie man es NICHT machen soll!

// Das ist ein Beispiel wie man es NICHT machen soll!

// Das ist ein Beispiel wie man es NICHT machen soll!

// Das ist ein Beispiel wie man es NICHT machen soll!

// Das ist ein Beispiel wie man es NICHT machen soll!

using System;

Console.WriteLine("Goto Demo");
Console.WriteLine("====================");
Console.WriteLine();

RepeateInput:

Console.Write("Please enter a number: [1..100]: ");
int number;

if (!int.TryParse(Console.ReadLine(), out number))
{
    Console.Write("wrong format. ");
    goto PleaseTryAgain;
}

if (number > 100)
{
    Console.WriteLine("Number to big. ");
    goto PleaseTryAgain;
}
else if (number < 1)
{
    Console.WriteLine("Number to small.");
    goto PleaseTryAgain;
}

goto Continue;

PleaseTryAgain:
Console.WriteLine("Please try again");
goto RepeateInput;

Continue:
bool first = true;

DoAgain:
Console.WriteLine("We start");
for (int i= 0; i < number; i++)
{
    if (i == number/2 && first)
    {
        Console.WriteLine("We have reached the middle");
        goto AfterLoop;
    }
}

Console.WriteLine("We finished without first");

AfterLoop:
Console.WriteLine("We finished");

if (first)
{
    first = false;
    goto DoAgain;
}

Console.WriteLine("Now the imput is OK");