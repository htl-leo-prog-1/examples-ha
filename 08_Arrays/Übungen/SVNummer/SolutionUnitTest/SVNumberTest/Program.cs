/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: Test a SV Number
 *--------------------------------------------------------------
 */

using System;

using SVNummerTest;

Console.WriteLine("Check a SV Number");
Console.WriteLine("**********************");

string svNumber;
do
{
    Console.Write("Please enter a SV Number: ");
    svNumber = Console.ReadLine();

    if (!string.IsNullOrEmpty(svNumber))
    {
        var result = SVNummer.IsSvNumberValid(svNumber) ? "valid" : "invalid";
        Console.WriteLine($"The SV Number \"{svNumber}\" is {result}");
    }
} while (!string.IsNullOrEmpty(svNumber));