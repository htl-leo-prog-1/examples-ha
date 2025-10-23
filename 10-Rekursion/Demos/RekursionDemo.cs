/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung
*--------------------------------------------------------------
* Description: Rekursion Demo
*--------------------------------------------------------------
*/

using System;

Console.WriteLine($"5!={Fibonacci(10)}");

int x = ReadNumber("Please enter x: ", 1000, 1);
int y = ReadNumber("Please enter y: ", 1000, 1);

Console.WriteLine($"Euklid: {GGT(x,y)},{GGTIteratively(x, y)} ");

for (int n = -1 ; n < 10; n++)
{
    Console.Write($"{Fibonacci(n)},");
}
Console.WriteLine();


static int Fibonacci(int n)
{
    if (n <= 0)
    {
        return 0;
    }

    if (n == 1)
    {
        return 1;
    }

    return Fibonacci(n - 1) + Fibonacci(n - 2);
}

static long Factorial(int n)
{
    if (n <= 0)
    {
        return 1;
    }

    return n * Factorial(n - 1);
}

static long FactorialIteratively(int n)
{
    long factorial = 1;
    for (int i = 2; i <= n; i++)
    {
        factorial = factorial * i;
    }

    return factorial;
}


int GGT(int a, int b)
{
    if (b!= 0)
    {
        return GGT(b, a%b);
    }

    return a;
}

int GGTIteratively(int a, int b)
{
    if (b != 0)
    {
        int c;
        do
        {
            c = a % b;
            a = b;
            b = c;
        } while (c != 0);
    }
    return a;
}

int ReadNumber(string message, int max, int min)
{
    int number;
    bool isOk;
    do
    {
        Console.Write($"{message} [{min}..{max}]: ");
        isOk = int.TryParse(Console.ReadLine(), out number) && number >= min && number <= max;
    } while (!isOk);

    return number;
}
