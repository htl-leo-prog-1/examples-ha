/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: xAHIF
 *--------------------------------------------------------------
 * Exercise Number: 04
 * File:			    PocketCalculator.cs
 * Author(s):		 Peter Bauer
 * Due Date:		    <due>
 *--------------------------------------------------------------
 * Description:
 * A simple pocket calculator (add, sub, mult, div)
 *--------------------------------------------------------------
*/

using System;

Console.WriteLine("************************************");
Console.WriteLine("*            The Calculator        *");
Console.WriteLine("*                                  *");
Console.WriteLine("************************************");
Console.WriteLine();

Console.WriteLine("Erste Zahl: ");
string userInput = Console.ReadLine();
double operand1  = Convert.ToDouble(userInput);

Console.WriteLine("Operation [+ - * /]: ");
string op = Console.ReadLine();

Console.WriteLine("Zweite Zahl: ");
userInput = Console.ReadLine();
double operand2 = Convert.ToDouble(userInput);

double result = 0.0;

switch (op)
{
    case "+":
        result = operand1 + operand2;
        break;

    case "/":
        result = operand1 / operand2;
        break;

    default:
        Console.WriteLine("Falsche Eingabe");
        break;
}

Console.WriteLine($"Ergebnis von {operand1} {op} {operand2} = {result}");