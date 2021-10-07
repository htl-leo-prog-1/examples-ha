/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: xAHIF
 *--------------------------------------------------------------
 *                 / _)     (  _ / _-- _/_ _ 
 *                /(_) .   __)( /)/ ()(/(-/  
 *--------------------------------------------------------------
 * Description:
 * A simple pocket calculator which can add two integers
 * and prints the result to the console right-aligned.
 *--------------------------------------------------------------
*/

using System;

Console.WriteLine("************************************");
Console.WriteLine("* Calculator - Ihr Zahlenbegleiter *");
Console.WriteLine("************************************");
Console.WriteLine();

Console.Write("Erste Zahl: ");
string userInput = Console.ReadLine();
int    operand1  = Convert.ToInt32(userInput);
Console.Write("Zweite Zahl: ");
userInput = Console.ReadLine();
int operand2 = Convert.ToInt32(userInput);
Console.WriteLine();

int sum = operand1 + operand2;

Console.WriteLine("Ergebnis:");
Console.WriteLine("=========");
Console.WriteLine("{0,20:n0}",   operand1);
Console.WriteLine("+ {0,18:n0}", operand2);
Console.WriteLine("--------------------");
Console.WriteLine("{0,20:n0}", sum);
Console.WriteLine("====================");