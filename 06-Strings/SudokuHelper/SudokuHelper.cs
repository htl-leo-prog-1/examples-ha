/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: CharCount
 * Sudoku Helper - calculates all possibilities of a row/col
 *--------------------------------------------------------------
 */

using System;

Console.WriteLine("Sudoku row/column helper");
Console.WriteLine("************************");

string allDigits = "123456789";

Console.Write("Please enter all digits if a row/col/3x3 (empty to exit): ");
string containingDigits = Console.ReadLine();

while (!string.IsNullOrEmpty(containingDigits))
{
    bool isValid = true;

    for (int n = 0; n < containingDigits.Length && isValid; n++)
    {
        char ch = containingDigits[n];

        if (char.IsDigit(ch) && ch != '0')
        {
            for (int i = n + 1; i < containingDigits.Length && isValid; i++)
            {
                isValid = ch != containingDigits[i];
            }
        }
        else if (ch != ' ' && ch != '0')
        {
            isValid = false;
        }
    }

    if (isValid)
    {
        string missingDigits = "";

        for (int j = 0; j < allDigits.Length; j++)
        {
            char ch = allDigits[j];
            bool found = false;

            for (int i = 0; i < containingDigits.Length && !found; i++)
            {
                found |= ch == containingDigits[i];
            }

            if (!found)
            {
                missingDigits += ch;
            }
        }

        if (string.IsNullOrEmpty(missingDigits))
        {
            Console.Write("nothing");
        }
        else
        {
            Console.Write(missingDigits);
        }

        Console.WriteLine(" is possible");
    }
    else
    {
        Console.WriteLine("invalid input");
    }

    Console.Write("Please enter all digits if a row/col/3x3 (empty to exit): ");
    containingDigits = Console.ReadLine();
}