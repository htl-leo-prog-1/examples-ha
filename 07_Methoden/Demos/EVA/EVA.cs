/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Eingabe Verarbeitung Ausgabe
*--------------------------------------------------------------
*/

using System;

string containingDigits;
string missing="";

void Eingabe()
{
    Console.Write("Please enter all digits if a row/col/3x3: ");
    containingDigits = Console.ReadLine();
}

void Verarbeitung()
{
    for (char digit = '0'; digit <= '9'; digit++)
    {
        bool found = false;
        for (int i = 0; !found && i < containingDigits.Length; i++)
        {
            found = containingDigits[i] == digit;
        }

        if (!found)
        {
            missing += digit;
        }
    }
}

void Ausgabe()
{
        Console.Write(containingDigits.Length == 0 ? "nothing " : missing);
}

Eingabe();
Verarbeitung();
Ausgabe();