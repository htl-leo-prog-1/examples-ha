/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: <CLASSNAME>
 *--------------------------------------------------------------
 *              <NAME> 
 *--------------------------------------------------------------
 * Description:
 * ...
 *--------------------------------------------------------------
*/
using System;
using System.IO;
using System.Text;

namespace VocabularyTrainer
{
    class Program
    {
        const string FILE_NAME = "vocabulary.csv";
        const int DE = 0;
        const int EN = 1;
        const int FAILS = 2;
        const int HITS = 3;
        static Random random = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("============== VOKABELTRAINER ==============\n\n");
            Console.WriteLine("Beenden mit Eingabetaste\n");
            Word[] words = ReadVocabulary(FILE_NAME);
            bool proceed = true;
            do
            {
                int wordToTest = random.Next(0, words.Length);
                proceed = TestVocable(words[wordToTest]);
            } while (proceed);
            Sort(words);
            PrintResults(words);
            WriteResultsToFile(FILE_NAME, words);
            Console.WriteLine("Drücke eine Taste zum Beenden ...");
            Console.ReadLine();
        }

        private static void Sort(Word[] words)
        {
            for (int left = 0; left < words.Length - 1; left++)
            {
                int smallest = left;
                for (int right = left + 1; right < words.Length; right++)
                {
                    if (words[right].GetFails() > words[smallest].GetFails())
                    {
                        smallest = right;
                    }
                }
                if (smallest != left)
                {
                    Word swap = words[left];
                    words[left] = words[smallest];
                    words[smallest] = swap;
                }
            }
        }

        /// <summary>
        /// Reads a given csv-file and creates an array of words
        /// with appropriate length.
        /// Each line of the csv-file is split into each column
        /// and a new word is created and assigned into the array.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static Word[] ReadVocabulary(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName, Encoding.Default);
            Word[] words = new Word[lines.Length - 1];
            for (int i = 0; i < lines.Length - 1; i++)
            {
                words[i] = new Word();
                string[] columns = lines[i + 1].Split(';');
                words[i].SetGerman(columns[DE]);
                words[i].SetEnglish(columns[EN]);
                words[i].SetFails(Convert.ToInt32(columns[FAILS]));
                words[i].SetHits(Convert.ToInt32(columns[HITS]));
            }
            return words;
        }

        /// <summary>
        /// Presents the german vocabel and evaluates,
        /// if the given english translation is correct or not. 
        /// The hit or fail is stored in the word object.
        /// If the user has given an invalid answer (nothing),
        /// the method returns false, otherwise true.
        /// </summary> 
        static bool TestVocable(Word word)
        {
            bool proceed = true;
            Console.Write("{0}: ", word.GetGerman());
            string translation = Console.ReadLine();
            if (translation == "")
            {
                proceed = false;
            }
            else if (translation == word.GetEnglish())
            {
                Console.WriteLine("Richtig!\n");
                word.AddHit();
            }
            else
            {
                Console.WriteLine("Leider falsch!\n");
                word.AddFail();
            }
            return proceed;
        }

        /// <summary>
        /// Prints the number of wrong and correct answers per vocabel to the Console
        /// </summary>
        static void PrintResults(Word[] vocabulary)
        {
            // Ausgabe der Statistik
            Console.WriteLine("\nErgebnis des Vokabeltests");
            Console.WriteLine("=========================");
            Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}", "deutsch", "englisch", "falsch", "richtig");
            Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}", "-------", "--------", "------", "-------");
            for (int i = 0; i < vocabulary.Length; i++)
            {
                Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}", 
                    vocabulary[i].GetGerman(), vocabulary[i].GetEnglish(), vocabulary[i].GetFails(), vocabulary[i].GetHits());
            }
        }

        /// <summary>
        /// Writes all words including nr hits and nr fails to a given csv-file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="vocabulary"></param>
        private static void WriteResultsToFile(string fileName, Word[] vocabulary)
        {
            string[] lines = new string[vocabulary.Length + 1];
            lines[0] = "German;English;Fails;Hits";
            for (int i = 0; i < vocabulary.Length; i++)
            {
                lines[i + 1] = vocabulary[i].GetGerman() + ";"
                    + vocabulary[i].GetEnglish() + ";"
                    + vocabulary[i].GetFails() + ";"
                    + vocabulary[i].GetHits();
            }
            File.WriteAllLines(fileName, lines, Encoding.Default);
        }
    }
}
