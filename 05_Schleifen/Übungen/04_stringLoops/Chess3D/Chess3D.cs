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

string[] lines = new[]
{
    "+------------------------+",
    "|   ###   ###   ###   ###| 8",
    "|###   ###   ###   ###   | 7",
    "|   ###   ###   ###   ###| 6",
    "|###   ###   ###   ###   | 5",
    "|   ###   ###   ###   ###| 4",
    "|###   ###   ###   ###   | 3",
    "|   ###   ###   ###   ###| 2",
    "|###   ###   ###   ###   | 1",
    "+------------------------+",
    "  A  B  C  D  E  F  G  H",
};

int shift;
bool isOk;

do
{
    do
    {
        Console.Write("Please enter horizontal shift: ");
        isOk = int.TryParse(Console.ReadLine(), out shift);
    } while (!isOk || shift < 0);

    int shiftLines = lines.Length - 1;    // do not count first line (A B C D E F G H) => always shift 0

    for (int currentLine = 0; currentLine < lines.Length; currentLine++)
    {
        int currentShift = ((lines.Length- currentLine-1) * shift + shiftLines / 2) / shiftLines;
        for (var x = 0; x < currentShift; x++)
        {
            Console.Write(" ");
        }
        Console.WriteLine(lines[currentLine]);
    }

} while (shift > 0);