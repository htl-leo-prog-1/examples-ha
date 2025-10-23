/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description:
 * FactorizeNumber
 *--------------------------------------------------------------
 */

using System;

string input;
int number; 
int divideBy = 2; 
int power = 0;
string resultText = "1";

Console.WriteLine("Primfaktorzerlegung");
Console.WriteLine("===================");
Console.Write("Geben Sie eine Zahl > 1 ein, die dann in Primfaktoren zerlegt wird: ");
input = Console.ReadLine();
number = int.Parse(input);


Console.WriteLine();
while (number > 1)
{
    if (number % divideBy == 0)
    {
        power++;
        Console.WriteLine($"{number,5} : {divideBy,3} = {number / divideBy,3}");
        number = number / divideBy;
    }
    else
    {
        if (power >= 1)
        {
            resultText = $"{resultText}*{divideBy}";
            if (power > 1)
            {
                resultText += $"^{power}";
            }
        }

        divideBy++;
        power = 0;
    }
}

resultText = $"{resultText}*{divideBy}";
if (power > 1)
{
    resultText += $"^{power}";
}

Console.WriteLine();
Console.WriteLine($"{input}={resultText}");