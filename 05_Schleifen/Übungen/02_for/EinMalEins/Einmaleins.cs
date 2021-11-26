/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: EinMalEins
* Tabelle aller x * y (für x und y [1..31])
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Basic multiplication table");
Console.WriteLine("==========================");
Console.WriteLine();

const int MAXCOLUMNS = 31;

int columnCount;
bool isOk;

do
{
    Console.Write($"Please enter column/row count [0..{MAXCOLUMNS}]: ");
    isOk = int.TryParse(Console.ReadLine(), out columnCount);

} while (!isOk || columnCount < 0 || columnCount > MAXCOLUMNS);

Console.WriteLine();

var sepLine = "+";
for (var i = 1; i <= columnCount; i++)
{
    sepLine += "---+";
}

Console.WriteLine(sepLine);

for (var y = 1; y <= columnCount; y++)
{
    Console.Write("|");
    for (var x = 1; x <= columnCount; x++)
    {
        Console.Write($"{x*y,3}|");
    }
    Console.WriteLine();
    Console.WriteLine(sepLine);
}