/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Test a SV Number 
*--------------------------------------------------------------
*/

using System;

bool OnlyContainsDigits(string str)
{
    for (int i = 0; i < str.Length; i++)
    {
        if (str[i] < '0' || str[i] > '9')
        {
            return false;
        }
    }

    return true;
}

bool IsSvNumberValid(string svNumber)
{
    int[] weight = {3, 7, 9, 0, 5, 8, 4, 2, 1, 6};

    bool isSvOk = svNumber.Length == 10 && OnlyContainsDigits(svNumber);

    if (isSvOk)
    {
        int sum = 0;
        for (int i = 0; i < svNumber.Length; i++)
        {
            sum += weight[i] * (svNumber[i] - '0');
        }

        isSvOk = (svNumber[3] - '0') == sum % 11;
    }

    return isSvOk;
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