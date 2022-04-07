using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLE
{
    public class RunLengthEncoding
    {
        /// <summary>
        /// Die Grundidee der Lauflängenkodierung ist, jede Sequenz von identischen Zeichen durch deren Anzahl und das Zeichen zu ersetzen.
        /// Beispiel: AAABBBBBBCDDE wird zu 3A6B1C2D1E
        /// Um wieder eindeutig dekodieren zu können, sollen maximal 10 Zeichen zusammengefasst werden können, wobei die Zahl 10 dann als '0' kodiert
        /// wird.
        /// Beispiel: aaaaaaaaaaaa wird zu 0a2a (10 a + 2 a = 12 a)
        /// </summary>
        /// <param name="input">Zu kodierender Text</param>
        /// <returns>RLE-kodierter Output</returns>
        public static string RleEncode(string input)
        {
            int i = 0;
            string output = "";
            while (i < input.Length)
            {
                char current = input[i];
                int count = 1;
                while (i + 1 < input.Length && current == input[i + 1] && count < 10)
                {
                    count++;
                    i++;
                }
                output += "" + (count % 10) + current;
                i++;
            }
            return output;
        }

        /// <summary>
        /// Bei der Dekodierung muss ein RLE-kodierter Input-String in die Ausgangszeichenkette zurückgewandelt werden.
        /// Beispiel: Aus 0a2a wird wieder aaaaaaaaaaaa

        /// </summary>
        /// <param name="input">RLE-kodierter Input</param>
        /// <returns>Ursprüngliche Zeichenkette als Output</returns>
        public static string RleDecode(string input)
        {
            string output = "";
            for (int i = 0; i < input.Length; i = i + 2)
            {
                int count = input[i] - '0';
                if (count == 0)
                {
                    count = 10;
                }
                char character = input[i + 1];
                for (int j = 0; j < count; j++)
                {
                    output += character;
                }
            }
            return output;
        }
    }
}
