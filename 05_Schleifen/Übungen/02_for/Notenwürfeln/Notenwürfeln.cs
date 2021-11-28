/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: unfaires Notenwürfeln
*--------------------------------------------------------------
*/

using System;

Random random = new Random();

for (int i = 1; i < 32; i++)
{
    int grade = random.Next(1, 6);
    Console.WriteLine($"Kat-Nr. {i}: {grade}");
}