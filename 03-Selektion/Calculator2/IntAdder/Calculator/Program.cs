using System;

// Variablendefinitionen
int    leftOperand;
int    rightOperand;
int    result;
string userInput;

// Eingabe
Console.WriteLine("Einfacher Addierer für ganze Zahlen");
Console.WriteLine("===================================");
Console.WriteLine();

Console.Write("Linker Operand [int]: ");
userInput   = Console.ReadLine();
leftOperand = int.Parse(userInput);

Console.Write("Rechter Operand [int]: ");
userInput    = Console.ReadLine();
rightOperand = int.Parse(userInput);

// Verarbeitung
result = leftOperand + rightOperand;

// Ausgabe
Console.WriteLine($"Ergebnis von {leftOperand} + {rightOperand} = {result}");