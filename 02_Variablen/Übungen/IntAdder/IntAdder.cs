/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: xAHIF
 *--------------------------------------------------------------
 *                Musterlösung 
 *--------------------------------------------------------------
 * Description: IntAdder, ein Programm zum addieren von Ganzzahlen
 *--------------------------------------------------------------
*/

using System;

// Variablendefinitionen
int leftOperand;
int rightOperand;
int result;
string userInput;

// Eingabe
Console.WriteLine("Einfacher Addierer für ganze Zahlen");
Console.WriteLine("===================================");
Console.WriteLine();
Console.Write("Linker Operand [int]: ");
userInput = Console.ReadLine();
leftOperand = Convert.ToInt32(userInput);
Console.Write("Rechter Operand [int]: ");
userInput = Console.ReadLine();
rightOperand = Convert.ToInt32(userInput);

// Verarbeitung
result = leftOperand + rightOperand;

// Ausgabe
Console.WriteLine("Ergebnis von {0} + {1} = {2}", leftOperand, rightOperand, result);
