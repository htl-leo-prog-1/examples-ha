/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung
*--------------------------------------------------------------
* Description: RomanNumerals
*--------------------------------------------------------------
*/

namespace Roman;

public static class RomanNumeralsExtensions
{
    public static string ConvertToRomanLiteral(this int number)
    {
        return RomanNumerals.ConvertToRomanLiteral(number);
    }

    public static int ConvertFromRomanLiteral(this string roman)
    {
        return RomanNumerals.ConvertFromRomanLiteral(roman);
    }
}