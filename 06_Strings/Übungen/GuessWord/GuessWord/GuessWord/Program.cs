using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWord
{
    class Program
    {
        static void Main(string[] args)
        {
            string searchedWord;
            string patternOld;
            string patternNew = "";
            int countFailures = 0;
            string input;
            char letter;
            Console.WriteLine("Wort erraten");
            Console.WriteLine("============");
            Console.Write("Spieler1, zu erratendes Wort eingeben: ");
            searchedWord = Console.ReadLine();
            searchedWord = searchedWord.ToUpper();
            patternOld = "";
            for (int i = 0; i < searchedWord.Length; i++)
            {
                patternOld = patternOld + '?';
            }
            Console.Clear();
            // Raten
            do
            {
                Console.Write("Wort: {0}, Fehler: {1}, Buchstaben eingeben (Aufgeben mit *): ", patternOld, countFailures);
                input = Console.ReadLine();
                input = input.ToUpper();
                letter = input[0];
                patternNew = "";
                for (int i = 0; i < searchedWord.Length; i++)
                {
                    if (searchedWord[i] == letter && patternOld[i] == '?')
                    {  // neuer Buchstabe erraten
                        patternNew = patternNew + letter;
                    }
                    else  // alter Status bleibt erhalten
                    {
                        patternNew = patternNew + patternOld[i];
                    }
                }
                if (patternNew == patternOld)
                {
                    countFailures++;
                }
                patternOld = patternNew;
            }
            while (patternOld != searchedWord.ToUpper() && letter != '*');
            Console.WriteLine();
            if (patternOld == searchedWord.ToUpper())
            {
                Console.WriteLine("Erraten: {0}", searchedWord);
                Console.WriteLine("Du hast {0} Fehlversuche gehabt!", countFailures);
            }
            else
            {
                Console.WriteLine("Gesuchtes Wort: {0}", searchedWord);
                Console.WriteLine("War wohl nichts, du hast aufgegeben!");
            }
            Console.Write("Beenden, Eingabetaste drücken ...");
            Console.ReadLine();

        }
    }
}
