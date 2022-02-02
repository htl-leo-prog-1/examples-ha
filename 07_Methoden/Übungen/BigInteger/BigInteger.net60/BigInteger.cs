/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: BigInteger
*--------------------------------------------------------------
*/

using System;

bool IsValidBigInteger(string str)
{
    for (int i = 0; i < str.Length; i++)
    {
        if (!char.IsDigit(str[i]))
        {
            return false;
        }
    }

    return true;
}

string ReadBigInteger(string inputRequestMessage)
{
    string input;
    bool isOk;

    do
    {
        Console.Write(inputRequestMessage);
        input = Console.ReadLine();
        isOk = IsValidBigInteger(input);

        if (!isOk)
        {
            Console.WriteLine("Illegal number!");
        }
    } while (!isOk);

    return input;
}

int GetDigit(string a, int idxFromLast)
{
    return (a.Length - idxFromLast >= 0) ? a[^idxFromLast] - '0' : 0;
}

string AddBigIntegers(string a, string b)
{
    int maxLength = Math.Max(a.Length, b.Length);

    int carry = 0;
    string result = string.Empty;

    for (int i = 1; i <= maxLength; i++)
    {
        int sumOfCurrentDigits = GetDigit(a,i) + GetDigit(b, i) + carry;

        result = (sumOfCurrentDigits % 10) + result;
        carry = sumOfCurrentDigits / 10;
    }

    if (carry > 0)
    {
        result = carry + result;
    }

    return result;
}

string MultiplyBigIntegerWithDigit(string multiplicand, int digit)
{
    string result = string.Empty;
    int carry = 0;
    for (int i = multiplicand.Length - 1; i >= 0; i--)
    {
        int productOfCurrentDigits = (multiplicand[i] - '0') * digit + carry;
        result = (productOfCurrentDigits % 10) + result;
        carry = productOfCurrentDigits / 10;
    }

    if (carry > 0)
    {
        result = carry + result;
    }

    return result;
}

string MultiplyBigIntegers(string multiplicand, string multiplier)
{
    string result = string.Empty;
    for (int i = 0; i < multiplier.Length; i++)
    {
        string product = MultiplyBigIntegerWithDigit(multiplicand, multiplier[i] - '0');
        result = AddBigIntegers(result + "0", product);
    }

    return result;
}

Console.WriteLine("Big integer");
Console.WriteLine("***********");

string proceed;
do
{
    string number1 = ReadBigInteger("Please enter 1. number: ");
    string number2 = ReadBigInteger("Please enter 2. number: ");
    Console.WriteLine();
    Console.WriteLine("Sum:     " + AddBigIntegers(number1, number2));
    Console.WriteLine("Product: " + MultiplyBigIntegers(number1, number2));
    Console.WriteLine();
    Console.Write("Continue with \"y\": ");
    proceed = Console.ReadLine();
} while (proceed == "y");