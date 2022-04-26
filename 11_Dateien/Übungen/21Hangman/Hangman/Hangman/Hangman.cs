/***********************************************************************************************
 * Übungsnr:        21                                     
 * Programmname:    Hangman
 * Autor:           Michael Bucek  
 * Klasse:          1CHIF
 * Datum:           03.03.2014                               
 * ------------------------------------------------ 
 * Kurzbeschreibung:      
 * Das bekannte Spiel "Hangman" soll implementiert werden.
 ************************************************************************************************/


using System;
using System.IO;
using System.Text;

namespace Hangman
{
    class Hangman
    {
        const int MAXMISTAKES = 10;

        static Random random = new Random();

        struct WordStruct
        {
            public string Word;
            public string Hint;
        }


        static void Main(string[] args)
        {
            WordStruct[] words;
            int actIdx;
            string again="j";
            bool[] correctLetters;
            int mistakes;


            words = ReadWordsFromCsv();
            do
            {
                //Spielinitialisierung
                actIdx = random.Next(0, words.Length);
                correctLetters=new bool[words[actIdx].Word.Length];  //Richigen Buchstaben werden in einem Boolarray, der gleichen Länge wie das Wort, gespeichert.
                mistakes = 0;

                //Startbuchstabe frei setzen
                TryLetter(words[actIdx].Word[0], correctLetters, words[actIdx].Word);
                
                while ((!PrintWord(words[actIdx],correctLetters) && (mistakes<MAXMISTAKES)))
                {
                    Console.WriteLine("Aktuelle Fehler: {0}",mistakes);
                    if (!TryLetter(ReadLetter(), correctLetters, words[actIdx].Word))
                    {
                        Console.WriteLine("Dieser Buchstabe kommt nicht vor! +1 Fehler!");
                        mistakes++;
                    }  
                }

                if (mistakes == MAXMISTAKES)
                {
                    Console.WriteLine("Sie haben verloren! Das Wort lautet " + words[actIdx].Word);
                }
                else
                {
                    Console.WriteLine("Bravo! Sie haben es geschafft!");
                }

                Console.WriteLine("Nochmal spielen (j/n)?");
                again = Console.ReadLine();
            } while (again.ToLower() == "j");
        }

        /// <summary>
        /// Liest einen Buchstaben ein
        /// </summary>
        /// <returns></returns>
        static char ReadLetter()
        {
            string input="";
            
            do
            {
                Console.Write("Welchen Buchstaben wollen Sie tippen? ");
                input = Console.ReadLine().ToLower();
                if (input.Length != 1)
                {
                    Console.WriteLine("Eingabe muss genau 1 Zeichen beinhalten!");
                }
            } while (input.Length != 1);
            return input[0];
        }

        /// <summary>
        /// Prüft ob ein gesuchter Buchstabe im Wort vorkommt und setzt diese Positionen im Array
        /// correctLetters auf true.
        /// </summary>
        /// <param name="newChar"></param>
        /// <param name="correctLetters"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        static bool TryLetter(char newChar, bool[] correctLetters, string word)
        {
            bool found=false;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == newChar)
                {
                    correctLetters[i] = true;
                    found = true;
                }
            }
            return found;
        }

        /// <summary>
        /// Gibt den Hinweis aus und das derzeitige Wort mit den erratenen Buchstaben.
        /// Nicht erratene Buchstaben werden als '.' ausgegeben.
        /// Prüft zusätzlich, ob das Wort gesamt erraten wurde!
        /// </summary>
        /// <param name="word"></param>
        /// <param name="correctLetters"></param>
        static bool PrintWord(WordStruct wordStruct, bool[] correctLetters)
        {
            bool allFound = true;


            Console.WriteLine("Hinweis: " + wordStruct.Hint);
            Console.WriteLine();
            for (int i = 0; i < wordStruct.Word.Length; i++)
            {
                if (correctLetters[i] == true)
                {
                    Console.Write(wordStruct.Word[i] + " ");
                }
                else
                {
                    Console.Write(". ");
                    allFound = false;
                }
            }
            Console.WriteLine("\n");
            return allFound;
        }

        /// <summary>
        /// Liest die Wörter und Hinweise aus der csv-Datei in ein Strukturarray
        /// </summary>
        /// <returns></returns>
        static WordStruct[] ReadWordsFromCsv()
        {
            string[] lines = File.ReadAllLines("words.csv",Encoding.Default);
            WordStruct[] words = new WordStruct[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] cols = lines[i].Split(';');
                words[i].Word = cols[0].ToLower();
                words[i].Hint = cols[1];
            }
            return words;

        }
    }
}
