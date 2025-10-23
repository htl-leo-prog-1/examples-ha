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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyTrainer
{
    class Program
    {
        const int DE = 0;
        const int EN = 1;

        const int WRONG = 0;
        const int CORRECT = 1;

        static string[,] vocabulary = { // DE = first column, EN = second column
                                        {"Hund",   "dog" },  
                                        {"Katze",  "cat" }, 
                                        {"Fisch",  "fish" }, 
                                        {"Ente",   "duck" }, 
                                        {"Kuh",    "cow" }, 
                                        {"Pferd",  "horse" },
                                        {"Vogel",  "bird"},
                                        {"Elefant","elephant"},
                                      };
        static void Main(string[] args)
        {
            // Result statistics are stored in 2 columns (first: WRONG, second: CORRECT)
            // and the same number of rows like the vocabulary table.
            int[,] results = new int[vocabulary.GetLength(0), 2]; 
            Random random = new Random();
            bool proceed = true;
            while (proceed = TestVocabel(random.Next(0, vocabulary.GetLength(0)), vocabulary, results));
            PrintResults(results);
            Console.ReadLine();
        }

        /// <summary>
        /// Presents the german vocabel from the given row and evaluates,
        /// if the given english translation is correct or not. The results
        /// table is updated accordingly.
        /// If the user has given an invalid answer ('Ende' or nothing),
        /// the method returns false, otherwise true.
        /// </summary> 
        static bool TestVocabel(int row, string[,] vocabulary, int[,] results)
        {
            bool proceed = true;
            Console.Write("{0}: ",vocabulary[row, DE]);
            string translation = Console.ReadLine();
            if (translation == "Ende")
            {
                proceed = false;
            }
            else if (translation == vocabulary[row, EN])
            {
                Console.WriteLine("Richtig!\n");
                results[row, CORRECT] ++ ;
            }
            else
            {
                Console.WriteLine("Leider falsch!\n");
                results[row, WRONG] ++ ;
            }
            return proceed;
        }

        /// <summary>
        /// Prints the number of wrong and correct answers per vocabel to the Console
        /// </summary>
        static void PrintResults(int[,] results)
        {
            // Ausgabe der Statistik
            Console.WriteLine("\nErgebnis des Vokabeltests");
            Console.WriteLine("=========================");
            Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}", "deutsch", "englisch", "falsch", "richtig");
            Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}", "-------", "--------", "------", "-------");
            for (int i = 0; i < vocabulary.GetLength(0); i++)
            {
                Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}", 
                    vocabulary[i, DE], vocabulary[i, EN], results[i, WRONG], results[i, CORRECT]);
            }
        }
    }
}
