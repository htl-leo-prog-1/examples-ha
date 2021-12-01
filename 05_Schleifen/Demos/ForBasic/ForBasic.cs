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
int  count;

do
{
    Console.Write("Please enter a value: ");
    isOk = int.TryParse(Console.ReadLine(), out count);
} while (!isOk || count < 0);

///////////////////////////
/*
int i = 0;
while (i < count)
{
    Console.WriteLine($"i={i}");
    i = i+1; >= i++
}
*/
///////////////////////////
/*
for (int i = 0; i < count; i++)
{
    Console.WriteLine($"i={i}");
}

for (int i = count - 1; i >= 0; i--)
{
    Console.WriteLine($"i={i}");
}
*/

for (var x = 0; x < count; x++)
{
    for (var y = 0; y < count; y++)
    {
        Console.Write("*");
    }
    Console.WriteLine();
}