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
string containingDigits;

do
{
    Console.Write("Please enter all digits if a row/col/3x3 (empty to exit): ");
    containingDigits = Console.ReadLine();

    if (!string.IsNullOrEmpty(containingDigits))
    {
        string allUserDigits = "";
        bool   isValid       = true;
        for (int n = 0; n < containingDigits.Length && isValid; n++)
        {
            char ch = containingDigits[n];
            if (char.IsDigit(ch) && ch != '0')
            {
                for (int i = 0; i < allUserDigits.Length && isValid; i++)
                {
                    isValid = ch != allUserDigits[i];
                }

                allUserDigits += ch;
            }
            else if (ch != ' ')
            {
                isValid = false;
            }
        }

        if (isValid)
        {
            bool nothingFound = true;

            for (int j = 0; j < allDigits.Length; j++)
            {
                char chForTest = allDigits[j];
                bool found     = false;

                for (int i = 0; i < allUserDigits.Length; i++)
                {
                    found |= chForTest == allUserDigits[i];
                }

                if (!found)
                {
                    nothingFound = false;
                    Console.Write($"{chForTest}");
                }
            }

            if (nothingFound)
            {
                Console.Write("nothing");
            }

            Console.WriteLine(" is possible");
        }

        if (!isValid)
        {
            Console.WriteLine("invalid input");
        }
    }
} while (!string.IsNullOrEmpty(containingDigits));