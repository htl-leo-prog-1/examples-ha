/*--------------------------------------------------------------
 *				HTBLA-Leonding / Klasse: 1BHIF 2015/2016
 *--------------------------------------------------------------
 * Übung: 02
 * Datei:			    Calculator.cs
 * Autor:		        Max Mustermann
 * Erstellungsdatum:    03.10.2015
 *--------------------------------------------------------------
 * Beschreibung:
 * Ein einfacher Rechner, der die vier Grundrechnungsarten 
 * beherrscht.
 * Spezialisten überprüfen auch Fehleingaben (Operator, 
 * Division durch 0)
 *--------------------------------------------------------------
*/

using System;

// Variablendefinitionen
double leftOperand;
double rightOperand;
string operatorText;
string userInput;
double result;
string errorText = "";
bool   isError   = false;

// Eingabe
Console.WriteLine("Einfacher Rechner");
Console.WriteLine("=================");
Console.WriteLine();
Console.Write("Linker Operand [double]: ");
userInput   = Console.ReadLine();
leftOperand = double.Parse(userInput);
Console.Write("Operation [+ - * /]: ");
operatorText = Console.ReadLine();
Console.Write("Rechter Operand [double]: ");
userInput    = Console.ReadLine();
rightOperand = double.Parse(userInput);

// Verarbeitung
if (operatorText == "+")
{
    result = leftOperand + rightOperand;
}
else if (operatorText == "-")
{
    result = leftOperand - rightOperand;
}
else if (operatorText == "*")
{
    result = leftOperand * rightOperand;
}
else if (operatorText == "/")
{
    if (rightOperand == 0)
    {
        isError   = true;
        errorText = "Division durch 0 ist nicht erlaubt!";
        result    = 0;
    }
    else
    {
        result = leftOperand / rightOperand;
    }
}
else
{
    isError   = true;
    errorText = "Falsche Rechenart: " + operatorText;
    result    = 0;
}

// Ausgabe
if (isError)
{
    Console.WriteLine(errorText);
}
else
{
    Console.WriteLine($"Ergebnis von {leftOperand} {operatorText} {rightOperand} = {result:f3}");
}