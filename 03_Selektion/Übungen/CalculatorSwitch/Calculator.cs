/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Beschreibung:
* Ein einfacher Rechner, der die vier Grundrechnungsarten beherscht.
* Für die Auswahl der Operation verwenden wir ein switch.
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Calculator with Switch");
Console.WriteLine("====================");
Console.WriteLine();

Console.Write("Please enter left operand [double]: ");
var leftOperand = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Please enter operator: [+,-,*,/]: ");
var operatorInput = Console.ReadLine();

Console.Write("Please enter right operand [double]: ");
var rightOperand = Convert.ToDouble(Console.ReadLine());

switch (operatorInput)
{
    case "+":
        var plus = leftOperand + rightOperand;
        Console.WriteLine($"{leftOperand} + {rightOperand} = {plus}");
        break;

    case "-":
        var minus = leftOperand - rightOperand;
        Console.WriteLine($"{leftOperand} - {rightOperand} = {minus}");
        break;

    case "*":
        var mult = leftOperand * rightOperand;
        Console.WriteLine($"{leftOperand} * {rightOperand} = {mult}");
        break;

    case "/":
        if (rightOperand == 0.0)
        {
            Console.WriteLine("Division by 0.0!");
        }
        else
        {
            var div = leftOperand / rightOperand;
            Console.WriteLine($"{leftOperand} / {rightOperand} = {div}");
        }

        break;

    default:
        Console.WriteLine($"Illegal operator {operatorInput}!");
        break;
}
