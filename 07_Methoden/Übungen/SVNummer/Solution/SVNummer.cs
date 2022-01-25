/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Test a SV Number 
*--------------------------------------------------------------
*/

using System;

bool IsSvNumberValid(string svNumber)
{
    int[] weight = {3, 7, 9, 0, 5, 8, 4, 2, 1, 6};

    bool isSVOk = false;

    if (svNumber.Length == 10)
    {
        int sum = 0;
        for (int i = 0; i < svNumber.Length && char.IsDigit(svNumber[i]); i++)
        {
            sum += weight[i] * (svNumber[i] - '0');
        }

        isSVOk = (svNumber[3] - '0') == sum % 11;
    }

    return isSVOk;
}

Console.WriteLine("Check a SV Number");
Console.WriteLine("**********************");

string svNumber;
do
{
    Console.Write("Please enter a SV Number: ");
    svNumber = Console.ReadLine();

    if (!string.IsNullOrEmpty(svNumber))
    {
        var result = IsSvNumberValid(svNumber) ? "valid" : "invalid";
        Console.WriteLine($"The SV Number \"{svNumber}\" is {result}");
    }
} while (!string.IsNullOrEmpty(svNumber));