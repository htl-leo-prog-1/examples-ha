/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Beschreibung:
* Demo für break
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Demo break");
Console.WriteLine("====================");
Console.WriteLine();

for (int i=0;i<10;)
{
    Console.Write($"Please enter a number {i+1}: [0..1000]: ");
    var input = Console.ReadLine();

    if (input.ToUpper() == "X")
    {
        break;
    }

    int number;
    bool isOk = int.TryParse(input, out number);

    if (!isOk || number < 0 || number > 1000)
    {
        Console.WriteLine($"Wrong input: {input}");
        continue;
    }

    Console.WriteLine($"DoSomething with number ={number}");
    i++;
}

