/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Beschreibung: Demo for
*--------------------------------------------------------------
*/

using System;

bool isOk;
int  number;

do
{
    Console.Write("Please enter a value: ");
    isOk = int.TryParse(Console.ReadLine(), out number);
} while (!isOk || number < 0);

for (int i = 0; i < number; i++)
{
    Console.WriteLine($"i={i}");
}

Console.WriteLine($"================");

for (int i = 0; i < number; i += 2)
{
    Console.WriteLine($"i={i}");
}

Console.WriteLine($"================");

for (int i = number; i >= 0; i--)
{
    Console.WriteLine($"i={i}");
}

Console.WriteLine($"================");

for (uint i = 10; i >= 0; i--)
{
    Console.WriteLine($"i={i}");
}

for (ulong i = 10; i >= 0; i--)
{
    Console.WriteLine($"i={i}");
}