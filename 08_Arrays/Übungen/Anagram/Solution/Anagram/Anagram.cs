/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Anagram
*--------------------------------------------------------------
*/

namespace Anagram;

public class Anagram
{
    /// <summary>
    /// Calculate a conversion table for to strings.
    /// e.g. "Brei" and "Bier" (are anagrams) will return 0,3,2,1
    /// B => will stay on index 0
    /// r => will become index 3
    /// e => as index 2
    /// i => as index 1
    /// </summary>
    /// <param name="text"></param>
    /// <param name="compareWith"></param>
    /// <returns>Returns a array for converting text to compareWith</returns>
    public static int[] GetAnagramConversion(string text, string compareWith)
    {
        if (!IsAnagram(text, compareWith))
        {
            return null;
        }

        text = text.ToUpper();
        compareWith = compareWith.ToUpper();

        var result = new int[text.Length];

        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];

            for (int j = 0; j < compareWith.Length; j++)
            {
                if (c == compareWith[j] && !Contains(result, j, i))
                {
                    result[i] = j;
                    break;
                }
            }
        }

        return result;
    }

    /// <summary>
    /// Calculates a anagram word based on a conversion array (created by GetAnagramConversion)
    /// </summary>
    /// <param name="anagram"></param>
    /// <param name="conversion"></param>
    /// <returns></returns>
    public static string ConvertAnagram(string anagram, int[] conversion)
    {
        var anagramAsChar = new char[conversion.Length];

        for (int i = 0; i < conversion.Length; i++)
        {
            anagramAsChar[conversion[i]] += anagram[i];
        }

        string result = "";

        foreach (char ch in anagramAsChar)
        {
            result += ch;
        }

        return result;
    }

    /// <summary>
    /// Test if two strings are anagrams.
    /// The first string contains all characters of the second one.
    /// Casing is ignored.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="compareWith"></param>
    /// <returns>Returns true, if both strings con be converted (are anagrams)</returns>
    public static bool IsAnagram(string text, string compareWith)
    {
        text = text.ToUpper();
        compareWith = compareWith.ToUpper();

        bool isAnagram =
            text.Length > 0 &&
            text.Length == compareWith.Length &&
            ContainsOnlyValidChar(text) &&
            ContainsOnlyValidChar(compareWith) &&
            text != compareWith;

        for (int i = 0; i < text.Length && isAnagram; i++)
        {
            char ch = text[i];
            if (CountOf(text, ch) != CountOf(compareWith, ch))
            {
                isAnagram = false;
            }
        }

        return isAnagram;
    }

    private static int CountOf(string text, char ch)
    {
        int count = 0;

        foreach (var c in text)
        {
            if (c == ch)
            {
                count++;
            }
        }

        return count;
    }

    private static bool IsValidChar(char ch)
    {
        return char.IsLetter(ch);
    }

    private static bool ContainsOnlyValidChar(string text)
    {
        foreach (var ch in text)
        {
            if (!IsValidChar(ch))
            {
                return false;
            }
        }

        return true;
    }

    private static bool Contains(int[] ar, int value, int length)
    {
        for (int i = 0; i < ar.Length && i < length; i++)
        {
            if (ar[i] == value)
            {
                return true;
            }
        }

        return false;
    }
}