/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: TextJustify - add as many ' ' between words to fill line.
 *--------------------------------------------------------------
 */

namespace TextJustify
{
    public class TextJustifyTools
    {
        static int SkipSpaces(string str, int idx)
        {
            while (idx < str.Length && str[idx] == ' ')
            {
                idx++;
            }

            return idx;
        }

        static string DuplicateChar(char ch, int count)
        {
            return new string(ch, count);
        }

        static string TextCompress(string input)
        {
            string output = "";

            int idx = SkipSpaces(input, 0);

            while (idx < input.Length)
            {
                if (!string.IsNullOrEmpty(output))
                {
                    output += ' ';
                }

                while (idx < input.Length && input[idx] != ' ')
                {
                    output += input[idx];
                    idx++;
                }

                idx = SkipSpaces(input, idx);
            }

            return output;
        }

        static int WordCount(string input)
        {
            int count = 0;
            int idx   = SkipSpaces(input, 0);

            while (idx < input.Length)
            {
                count++;

                while (idx < input.Length && input[idx] != ' ')
                {
                    idx++;
                }

                idx = SkipSpaces(input, idx);
            }

            return count;
        }

        /// <summary>
        /// Bei einem Blocksatz werden so viel Leerzeichen zwischen den Wörtern eingefügt, bis eine
        /// gewünschte Gesamtlänge erreicht wird.
        /// </summary>
        /// <param name="sentence">Text, der aus Wörtern besteht.</param>
        /// <param name="charPerLine">Anzahl der Zeichen, auf die die Textlänge ausgerichtet werden soll.</param>
        /// <returns>Neuer Text mit der gewünschten Anzahl von Zeichen.</returns>
        public static string TextJustify(string sentence, int charPerLine)
        {
            sentence = TextCompress(sentence);
            int wordCount = WordCount(sentence);

            if (wordCount < 2 || sentence.Length > charPerLine)
            {
                return sentence;
            }

            int addBlanks        = charPerLine - sentence.Length;
            int addBlanksPerWord = addBlanks / (wordCount - 1);
            int addBlankRest     = addBlanks - (addBlanksPerWord * (wordCount - 1));

            string output = "";

            int idx = 0;

            while (idx < sentence.Length)
            {
                if (!string.IsNullOrEmpty(output))
                {
                    int addRounded = addBlankRest > 0 ? 1 : 0;
                    output += DuplicateChar(' ', 1 + addBlanksPerWord + addRounded);
                    addBlankRest--;
                }

                while (idx < sentence.Length && sentence[idx] != ' ')
                {
                    output += sentence[idx];
                    idx++;
                }

                idx++;
            }

            return output;
        }
    }
}