/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: ChristmasTree
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Christmas Tree");
Console.WriteLine("**************");

int height;
bool isOk;

do
{
    Console.Write("Please enter the height: ");
    isOk = int.TryParse(Console.ReadLine(), out height);
} while (!isOk || height < 0);


int starCount = 0;

for (var y = 0; y < height - 1; y++)
{
    for (var x = 0; x < height-y-2; x++)
    {
        Console.Write(" ");
    }

    for (var x = 0; x <y*2+1; x++)
    {
        starCount++;
        Console.Write(starCount % 7 == 0 ? "Q" : "x");
    }

    Console.WriteLine();
}

if (height > 0)
{
    for (var x = 0; x < height - 2; x++)
    {
        Console.Write(" ");
    }
    Console.Write("x");
}
