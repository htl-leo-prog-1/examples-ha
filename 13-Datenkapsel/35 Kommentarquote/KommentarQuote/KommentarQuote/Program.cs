using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace KommentarQuote
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kommentarquote für c#-Datei");
            Console.WriteLine("===========================");
            Console.Write("Dateiname ohne Endung: ");
            // Namen einer existierenden c#-Datei einlesen
            string filename = ReadFilename();
            //// Datei als Text einlesen
            //string text = File.ReadAllText(filename, Encoding.Default);
            //int sizeAllLetters = CountLettersAndDigits(text);
            // Datei in Array of Zeilen einlesen
            string[] lines = File.ReadAllLines(filename, Encoding.Default);
            int sizeAllLetters = CountLettersAndDigits(lines);
            int sizeCommendletters = CountComment(lines);
            Console.WriteLine("Von {0} Zeichen waren {1} Kommentar, das ergibt {2:0.00}% Kommentarquote",
                                sizeAllLetters, sizeCommendletters, ((double)sizeCommendletters) * 100 / sizeAllLetters);
            Console.Write("Beenden mit Eingabetaste ...");
            Console.ReadLine();
        }

        /// <summary>
        /// Gesamtzahl der Buchstaben und Ziffern aus Text einlesen
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Anzahl der Zeichen und Ziffern</returns>
        private static int CountLettersAndDigits(string text)
        {
            int count = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetterOrDigit(text[i]))
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Gesamtanzahl der zu zählenden Zeichen einlesen
        /// </summary>
        /// <param name="lines"></param>
        /// <returns>Anzahl von Buchstaben und Ziffern</returns>
        private static int CountLettersAndDigits(string[] lines)
        {
            int count = 0;
            for (int line = 0; line < lines.Length; line++)
            {
                for (int column = 0; column < lines[line].Length; column++)
                {
                    if (char.IsLetterOrDigit(lines[line][column]))
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// Zählt die Kommentarzeichen (Buchstaben und Ziffern)
        /// </summary>
        /// <param name="lines"></param>
        /// <returns>Anzahl der Kommentarzeichen</returns>
        private static int CountComment(string[] lines)
        {
            bool inBlockComment = false;
            bool inLineComment = false;
            int count = 0;
            string line;
            for (int lineNr = 0; lineNr < lines.Length; lineNr++)
            {
                line = lines[lineNr];
                for (int column = 0; column < line.Length; column++)  // zeile abarbeiten
                {
                    if (line.Length > column + 1 && line[column] == '/')  // eventuell Kommentarbeginn und es kommt noch ein Zeichen
                    {
                        if (line[column + 1] == '/')  // Zeilenkommentar oder XML-Kommentar
                        {
                            inLineComment = true;
                        }
                        else
                        {
                            if (line[column + 1] == '*')
                            {
                                inBlockComment = true;
                            }
                        }
                    }
                    else  // Ende des Blockkommentars prüfen
                    {
                        if (line.Length > column + 1 && line[column] == '*')  // eventuell Kommentarbeginn und es kommt noch ein Zeichen
                        {
                            if (line[column + 1] == '/')  // Ende des Blockkommentars
                            {
                                inBlockComment = false;
                            }
                        }
                    }
                    if ((inLineComment || inBlockComment) && char.IsLetterOrDigit(lines[lineNr][column]))
                    {
                        count++;
                    }
                }
                inLineComment = false;  // Neue Zeile
            }
            return count;
        }


        /// <summary>
        /// Gültigen Dateinamen von der Konsole einlesen. Die Datei liegt
        /// im \bin\debug-Verzeichnis der Anwendung
        /// </summary>
        /// <returns></returns>
        static string ReadFilename()
        {
            string filename = Console.ReadLine();
            filename += ".cs";
            while (!File.Exists(filename))
            {
                Console.Write("Dateiname ohne Endung (im Anwendungsverzeichnis \\bin\\debug): ");
                filename = Console.ReadLine();
                filename += ".cs";
            }
            return filename;
        }
    }
}
