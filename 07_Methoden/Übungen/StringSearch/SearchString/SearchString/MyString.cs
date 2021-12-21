using System;
using System.Collections.Generic;
using System.Text;

namespace SearchString
{
    public class MyString
    {
        /// <summary>
        /// Wenn searchText in text vorkommt, wird die Position des ersten Vorkommens zurückgeliefert.
        /// </summary>
        /// <param name="text">Text, in dem gesucht wird</param>
        /// <param name="searchText">Text, der gesucht wird</param>
        /// <returns>Position des ersten Vorkommens, sonst -1</returns>
        public static int SearchString(string text, string searchText)
        {
            int posText = 0;
            int possearchText = 0;
            while (posText + searchText.Length <= text.Length && possearchText < searchText.Length)  // Ende nicht erreicht und nicht gesamter searchText gefunden
            {
                possearchText = 0;
                while (possearchText < searchText.Length && text[posText + possearchText] == searchText[possearchText])
                {
                    possearchText++;
                }
                posText++;
            }
            if (possearchText == searchText.Length)
            {
                return posText - 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
