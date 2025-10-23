/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung
*--------------------------------------------------------------
* Description: RomanNumerals
*--------------------------------------------------------------
*/

namespace Roman;

using System;
using System.Collections.Generic;
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

        public int AppendLiteral(int number, StringBuilder romanLiteral)
        {
            int remaining = number;
            while (remaining >= Value)
            {
                romanLiteral.Append(Literal);
                remaining -= Value;
            }

            return remaining;
        }
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

    public static string ConvertToRomanLiteral(int number)
    {
        if (!IsValidLiteral(number))
        {
            throw new ArgumentException("Cannot covert to a roman literal");
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
        int remaining    = number;

        foreach (var part in GetRomanLiteralParts())
        {
            remaining = part.AppendLiteral(remaining, romanLiteral);
        }

        return romanLiteral.ToString();
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
            var literal = FindLiteralPart(roman, idx, literalParts);

            if (string.IsNullOrEmpty(literal.Literal))
            {
                throw new ArgumentException("Is not a roman literal", nameof(roman));
            }

            idx   += literal.Literal.Length;
            value += literal.Value;
        }

        return value;
    }

    private static RomanValue FindLiteralPart(string roman, int idx, IEnumerable<RomanValue> literalParts)
    {
        foreach (var part in literalParts)
        {
            if (IsLiteral(roman, idx, part.Literal))
            {
                return part;
            }
        }

        return default;
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