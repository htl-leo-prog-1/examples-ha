/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Mirp
*--------------------------------------------------------------
*/

using System;

static bool IsPrim(int number)
{
    int i;
    for (i = 2; i < number; i++)
    {
        if (number % i == 0)
            return false;
    }

    return true;
}

static int Reverse(int number)
{
    int reverseNumber = 0;

    while (number > 0)
    {
        int digit = number % 10;
        number = number / 10;

        reverseNumber = reverseNumber * 10 + digit;
    }

    return reverseNumber;
}

static bool IstMirp(int number)
{
    int reverseNumber = Reverse(number);

    return number != reverseNumber && IsPrim(number) && IsPrim(reverseNumber);
}


Console.WriteLine("Find Mirp Numbers ");
Console.WriteLine("****************************");

int count = 0;

for (int i = 10; i <= 1000; i++)
{
    if (IstMirp(i))
    {
        if (count != 0)
        {
            Console.Write(",");
        }
        if (count != 0 && count % 10 == 0)
        {
            Console.WriteLine();
        }
        Console.Write(i);
        count++;
    }
}