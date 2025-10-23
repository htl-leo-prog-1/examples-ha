/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Read and evaluate term like 2 * 6 + 2 
*--------------------------------------------------------------
*/

using System;

int SkipSpaces(string str, int idx)
{
    while (idx < str.Length && str[idx] == ' ')
    {
        idx++;
    }

    return idx;
}

int ReadInt(string str, ref int idx)
{
    int result = 0;
    int mult = 1;

    if (str[idx] == '-')
    {
        mult = -1;
        idx++;
    }

    while (idx < str.Length && char.IsDigit(str[idx]))
    {
        result *= 10;
        result += str[idx] - '0';
        idx++;
    }

    return mult * result;
}

int Evaluate(string str)
{
    int idx = SkipSpaces(str, 0);
    int result = ReadInt(str, ref idx);
    idx = SkipSpaces(str, idx);

    while (idx < str.Length)
    {
        char oper = str[idx];
        idx++;
        idx = SkipSpaces(str, idx);
        int op2 = ReadInt(str, ref idx);
        idx = SkipSpaces(str, idx);

        result = Calculate(result, op2, oper);
    }

    return result;
}

int Calculate(int op1, int op2, char oper)
{
    switch (oper)
    {
        case '+':
            op1 += op2;
            break;
        case '-':
            op1 -= op2;
            break;
        case '*':
            op1 *= op2;
            break;
        case '/':
            op1 /= op2;
            break;
    }

    return op1;
}

Console.WriteLine("Read and evaluate term");
Console.WriteLine("**********************");

string term;
do
{
    Console.Write("Please enter a term: ");
    term = Console.ReadLine();

    if (!string.IsNullOrEmpty(term))
    {
        int result = Evaluate(term);
        Console.WriteLine($"Term \"{term}\" evaluates to: {result}");
    }
} while (!string.IsNullOrEmpty(term));