using System;
using System.IO;
using System.Text;

namespace LinesStatistics
{
    public class LinesStatistics
    {
        static void Main(string[] args)
        {
            string fileName;
            LineInfo[] lineInfos;
            int sumOfWords; // Summe aller Wörter im text
            double avgWordsPerLine;
            Console.WindowWidth = 120;
            // Dateinamen einlesen
            Console.WriteLine("Zeilenanalyse");
            Console.WriteLine();
            Console.Write("Dateiname im Ordner bin\\debug: ");
            fileName = Console.ReadLine();
            if (!File.Exists(fileName))
            {
                Console.WriteLine("Datei {0} existiert nicht", fileName);
            }
            else
            {
                // Zeilen einlesen
                string[] lines = File.ReadAllLines(fileName, Encoding.Default);
                // Ergebnisarray anlegen
                lineInfos = new LineInfo[lines.Length];
                // Zeilen parsen und Worte zählen
                sumOfWords = InitializeLineInfos(lineInfos, lines);
                avgWordsPerLine = (double)sumOfWords / lines.Length;  // Mittelwert ermitteln
                // Analyse durchführen
                CalculateAllLineInfoResults(lineInfos, avgWordsPerLine);
                // Ausgabe
                Console.WriteLine("Durchschnittliche Wortanzahl je Zeile: {0,5:f2} ", avgWordsPerLine);
                Console.WriteLine();
                WriteLineInfos(lineInfos, avgWordsPerLine);
            }
            Console.Write("Beenden mit Eingabetaste ...");
            Console.ReadLine();
        }

        /// <summary>
        /// Das Ergebnis der Analyse wird ausgegeben.
        /// </summary>
        /// <param name="lineInfos"></param>
        /// <param name="averageWordsPerLine"></param>
        static void WriteLineInfos(LineInfo[] lineInfos, double averageWordsPerLine)
        {
            string lineText;
            string text = "";
            // Zeilen ausgeben
            for (int i = 0; i < lineInfos.Length; i++)
            {
                Console.WriteLine("{0:000} {1}", i + 1,
                    lineInfos[i].GetResultText());
                // Zeile an Text anhängen und Umbruch hinzufügen \r\n  \\
                lineText = string.Format("{0,3} {1}", i + 1,
                    lineInfos[i].GetResultText());
                text += lineText;
                text += "\r\n";
            }
            File.WriteAllText("Output.txt", text, Encoding.Default);
        }

        /// <summary>
        /// Für alle Zeilen werden die Wörter gezählt und in die zur
        /// Zeile gehörige Info eingetragen.
        /// </summary>
        /// <param name="lines"></param>
        /// <returns>Gesamtanzahl an Wörtern im text</returns>
        static int InitializeLineInfos(LineInfo[] lineInfos, string[] lines)
        {
            int allWordsCounter = 0;
            for (int i = 0; i < lineInfos.Length; i++)
            {
                lineInfos[i] = new LineInfo();
                lineInfos[i].SetOriginalText(lines[i]);
                lineInfos[i].SetWordsCounter(CountLineWords(lines[i]));
                allWordsCounter += lineInfos[i].GetWordsCounter();  // Wortanzahl aufsummieren
            }
            return allWordsCounter;
        }

        /// <summary>
        /// Nachdem die mittlere Wortanzahl ermittelt wurde, können
        /// alle Ergebnisse der Zeileninfos ermittelt werden.
        /// </summary>
        /// <param name="lineInfos"></param>
        /// <param name="avgWords">Mittlere Wortanzahl je Zeile für die gesamte Datei</param>
        static void CalculateAllLineInfoResults(LineInfo[] lineInfos, double avgWords)
        {
            for (int i = 0; i < lineInfos.Length; i++)
            {
                CalculateLineInfoResult(ref lineInfos[i], avgWords);
            }
        }

        /// <summary>
        /// Eine Zeile wird analysiert, ob sie mehr oder weniger Worte als
        /// der Durchschnitt in der Datei enthält. Im text wird dann der Zeile
        /// entweder ein + oder ein - vorangestellt.
        /// </summary>
        /// <param name="lineInfo"></param>
        /// <param name="avgWords"></param>
        static void CalculateLineInfoResult(ref LineInfo lineInfo, double avgWords)
        {
            string plusOrMinusText;
            lineInfo.SetHasMoreWordsThanAverage(lineInfo.GetWordsCounter() >= avgWords);
            if (lineInfo.GetHasMoreWordsThanAverage())
            {
                plusOrMinusText = "+";
            }
            else
            {
                plusOrMinusText = "-";
            }
            lineInfo.SetResultText(string.Format("{0} {1,3} {2}",
                plusOrMinusText, lineInfo.GetWordsCounter(), lineInfo.GetOriginalText()));
        }

        /// <summary>
        /// Die Wörter in der Zeile werden gezählt. Als Trennzeichen gelten alle
        /// Zeichen, die keinen Buchstaben und keine Ziffer darstellen.
        /// </summary>
        /// <param name="line">Zu untersuchende (parsende) Zeile</param>
        /// <returns>Wörter in der Zeile</returns>
        public static int CountLineWords(string line)
        {
            if (string.IsNullOrEmpty(line))
            {
                return 0;
            }
            int words = 0;
            bool inWord = false;
            for (int i = 0; i < line.Length; i++)
            {
                if (inWord)
                {
                    if (!char.IsLetterOrDigit(line[i]))
                    {
                        inWord = false;
                    }
                }
                else  // zwischen den Worten
                {
                    if (char.IsLetterOrDigit(line[i]))
                    {
                        inWord = true;
                        words++;
                    }
                }
            }
            return words;
        }

    }
}
