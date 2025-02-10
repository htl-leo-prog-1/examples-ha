/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: String methods (IndexOf,Replace)
 *--------------------------------------------------------------
 */

namespace StringMethodsEx
{
    using System;

    public class StringMethods
    {
        public static int IndexOf(string str, string searchString, int startIdx)
        {
            //return str.IndexOf(searchString, startIdx);
            if (!string.IsNullOrEmpty(searchString) && startIdx >= 0)
            {
                for (int i = startIdx; i < str.Length; i++)
                {
                    bool isEqual = str.Length - i >= searchString.Length;
                    for (int j = 0; j < searchString.Length && j + i < str.Length && isEqual; j++)
                    {
                        if (str[i + j] != searchString[j])
                        {
                            isEqual = false;
                        }
                    }

                    if (isEqual)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        public static int LastIndexOf(string str, string searchString, int startIdx)
        {
            // return str.LastIndexOf(searchString, startIdx);
            if (!string.IsNullOrEmpty(searchString) && startIdx < str.Length && startIdx >= 0)
            {
                for (int i = startIdx; i >= 0; i--)
                {
                    bool isEqual = str.Length - i >= searchString.Length;
                    for (int j = 0; j < searchString.Length && j + i < str.Length && isEqual; j++)
                    {
                        if (str[i + j] != searchString[j])
                        {
                            isEqual = false;
                        }
                    }

                    if (isEqual)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }


        public static string Replace(string str, string oldValue, string newValue)
        {
            // return str.Replace(oldValue, newValue);
            string result = String.Empty;
            int    idx    = 0;

            if (!string.IsNullOrEmpty(oldValue))
            {
                int nextIdx = IndexOf(str, oldValue, idx);

                while (nextIdx >= 0)
                {
                    result += SubString(str, idx, nextIdx - idx);
                    result += newValue;

                    idx = nextIdx + oldValue.Length;

                    nextIdx = IndexOf(str, oldValue, idx);
                }
            }

            return result + SubString(str, idx, str.Length);
        }

        public static string SubString(string str, int startIdx, int count)
        {
            string output = string.Empty;
            for (int i = startIdx; i >= 0 && i < str.Length && i < startIdx + count; i++)
            {
                output += str[i];
            }

            return output;
        }
    }
}