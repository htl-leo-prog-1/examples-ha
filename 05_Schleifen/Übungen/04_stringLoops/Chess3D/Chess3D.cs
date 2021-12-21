/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Chess 3D
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Chess 3D");
Console.WriteLine("**************");

const int SIZE = 8;
const int TOTALLINES = SIZE + 3;
const int TOTALDIFF = SIZE + 2;

int shift;
bool isOk;

do
{
    do
    {
        Console.Write("Please enter horizontal shift: ");
        isOk = int.TryParse(Console.ReadLine(), out shift);
    } while (!isOk || shift < 0);

    int currentLine = TOTALLINES-1;
    int CurrentShift(int line) => (line * shift + TOTALDIFF / 2) / TOTALDIFF;

    for (var x = 0; x < CurrentShift(currentLine); x++)
    {
        Console.Write(" ");
    }

    Console.Write("+");
    for (var x = 0; x < SIZE; x++)
    {
        Console.Write("---");
    }

    Console.WriteLine("+");
    currentLine--;


    for (var y = 0; y < SIZE; y++)
    {
        for (var x = 0; x < CurrentShift(currentLine); x++)
        {
            Console.Write(" ");
        }

        Console.Write("|");
        for (var x = 0; x < SIZE; x++)
        {
            Console.Write((x + y) % 2 == 0 ? "   " : "###");
        }

        Console.Write($"| {SIZE - y}");


        Console.WriteLine();
        currentLine--;
    }

    for (var x = 0; x < CurrentShift(currentLine); x++)
    {
        Console.Write(" ");
    }

    Console.Write("+");
    for (var x = 0; x < SIZE; x++)
    {
        Console.Write("---");
    }

    Console.WriteLine("+");
    currentLine--;

    Console.Write(" ");
    for (var x = 0; x < SIZE; x++)
    {
        Console.Write($" {(char) ('A' + x)} ");
    }

    Console.WriteLine();
    currentLine--;
} while (shift >= 0);