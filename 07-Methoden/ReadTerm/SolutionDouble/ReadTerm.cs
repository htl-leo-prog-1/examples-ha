/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Read and evaluate term like 2 * 6 + 2 
*--------------------------------------------------------------
*/

using System;

bool IsChar(string str, int idx, char ch)
{
    return idx < str.Length && str[idx] == ch;
}

int SkipSpaces(string str, int idx)
{
    while (IsChar(str,idx,' '))
    {
        idx++;
    }

    return idx;
}

bool IsConstant(string str, int idx, string constName)
{
    int i = 0;
    while (idx < str.Length && i < constName.Length && str[idx] == constName[i])
    {
        idx++;
        i++;
    }

    return i >= constName.Length;
}

double ReadValue(string str, ref int idx)
{
    double result;
    if (IsConstant(str, idx, "PI"))
    {
        idx += "PI".Length;
        result = Math.PI;
    }
    else
    {
        result = ReadDouble(str, ref idx);
    }

    return result;
}

double ReadDouble(string str, ref int idx)
{
    double result = 0;
    int mult = 1;

    if (IsChar(str, idx, '-'))
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

    if (IsChar(str, idx, '.'))
    {
        idx++;
        double factor = 1;

        while (idx < str.Length && char.IsDigit(str[idx]))
        {
            factor /= 10;
            result += (str[idx] - '0')*factor;
            idx++;
        }
    }

    return mult * result;
}

double Evaluate(string str)
{
    int idx = SkipSpaces(str, 0);
    var result = ReadValue(str, ref idx);
    idx = SkipSpaces(str, idx);

    while (idx < str.Length)
    {
        char oper = str[idx];
        idx++;
        idx = SkipSpaces(str, idx);
        var op2 = ReadValue(str, ref idx);
        idx = SkipSpaces(str, idx);

        result = Calculate(result, op2, oper);
    }

    return result;
}

double Calculate(double op1, double op2, char oper)
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
        var result = Evaluate(term);
        Console.WriteLine($"Term \"{term}\" evaluates to: {result}");
    }
} while (!string.IsNullOrEmpty(term));