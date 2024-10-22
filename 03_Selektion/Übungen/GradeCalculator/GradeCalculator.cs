/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *                Musterlösung - HA
 *--------------------------------------------------------------
 * Description:
 * Grade Calculator
 *--------------------------------------------------------------
 */

using System;

int grade1;
int grade2;

string result = "";

Console.WriteLine("Grade Calculator!");
Console.WriteLine("=================");
Console.Write("Note 1 [1..5]: ");
grade1 = int.Parse(Console.ReadLine());

Console.Write("Note 2 [1..5]: ");
grade2 = int.Parse(Console.ReadLine());

if (grade1 < 1 || grade1 > 5)
{
    Console.WriteLine("Falsche Eingabe für Note 1, erlaubt ist [1..5]");
}
else if (grade2 < 1 || grade2 > 5)
{
    Console.WriteLine("Falsche Eingabe für Note 2, erlaubt ist [1..5]");
}
else if (grade1 == 5 || grade2 == 5)
{
    Console.WriteLine("Nicht bestanden: mindestens ein 5er");
}
else if (grade1 == 1 && grade2 == 1)
{
    Console.WriteLine("Auszeichnung: nur 1er");
}
else
{
    Console.WriteLine($"Bestanden mit {(grade1+grade2)/2.0}");
}
