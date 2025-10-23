/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Beschreibung:
* Ein einfacher Rechner, der die vier Grundrechnungsarten beherscht.
* Es wird solange gerechnet bis der Benutzer X eingibt.
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Continues Calculator");
Console.WriteLine("====================");
Console.WriteLine();

Console.Write("Please enter operator: [+,-,*,/,X for exit]: ");
var operatorInput = Console.ReadLine();

while (operatorInput != "X")
{
    Console.Write("Please enter left operand [double]: ");
    var leftOperand = Convert.ToDouble(Console.ReadLine());

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

    Console.Write("Please enter operator: [+,-,*,/,X for exit]: ");
    operatorInput = Console.ReadLine();
}