/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung
*--------------------------------------------------------------
* Description: RomanNumerals
*--------------------------------------------------------------
*/

namespace Roman;

using System.Text;

public static class RomanNumerals
{
    private struct RomanValue
    {
        public RomanValue(int value, string literal)
        {
            Value   = value;
            Literal = literal;
        }

        public int    Value;
        public string Literal;
    }

    private static RomanValue[] GetRomanLiteralParts()
    {
        return new RomanValue[]
        {
            new RomanValue(1000, "M"),
            new RomanValue(900,  "CM"),
            new RomanValue(500,  "D"),
            new RomanValue(400,  "CD"),
            new RomanValue(100,  "C"),
            new RomanValue(90,   "XC"),
            new RomanValue(50,   "L"),
            new RomanValue(40,   "XL"),
            new RomanValue(10,   "X"),
            new RomanValue(9,    "IX"),
            new RomanValue(5,    "V"),
            new RomanValue(4,    "IV"),
            new RomanValue(1,    "I"),
        };
    }

    #region ConvertTo

    public static string? ConvertToRomanLiteral(int number)
    {
        if (!IsValidLiteral(number))
        {
            return null;
        }

        return ConvertValidRomanLiteralEx(number);
    }

    private static bool IsValidLiteral(int number)
    {
        return number > 0 && number < 4000;
    }

    private static string ConvertValidRomanLiteralEx(int number)
    {
        var romanLiteral = new StringBuilder();
        var literalParts = GetRomanLiteralParts();

        int remaining = number;

        foreach (var part in literalParts)
        {
            remaining = AppendLiteral(remaining, romanLiteral, part.Value, part.Literal);
        }

        return romanLiteral.ToString();
    }

    private static int AppendLiteral(int number, StringBuilder romanLiteral, int value, string literal)
    {
        int remaining = number;
        while (remaining >= value)
        {
            romanLiteral.Append(literal);
            remaining -= value;
        }

        return remaining;
    }

    #endregion

    #region ConvertFrom

    public static int ConvertFromRomanLiteral(string roman)
    {
        var literalParts = GetRomanLiteralParts();

        int idx   = 0;
        int value = 0;

        while (idx < roman.Length)
        {
            int i = FindLiteralPart(roman, idx, literalParts);

            if (i == -1)
            {
                return -1;
            }

            idx   += literalParts[i].Literal.Length;
            value += literalParts[i].Value;
        }

        return value;
    }

    private static int FindLiteralPart(string roman, int idx, RomanValue[] literalParts)
    {
        for (int i = 0; i < literalParts.Length; i++)
        {
            if (IsLiteral(roman, idx, literalParts[i].Literal))
            {
                return i;
            }
        }

        return -1;
    }

    private static bool IsLiteral(string roman, int idx, string literal)
    {
        int count;
        for (count = 0; count < literal.Length && count + idx < roman.Length; count++)
        {
            if (roman[idx + count] != literal[count])
            {
                return false;
            }
        }

        return count == literal.Length;
    }

    #endregion
}