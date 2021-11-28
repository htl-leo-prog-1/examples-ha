/***********************************************************************************************
 * Übungsnr:        05                                     
 * Programmname:    Vocabulary                                  
 * Autor:           Michael Bucek  
 * Klasse:          1CHIF
 * Datum:           22.10.2013                               
 * ------------------------------------------------ 
 * Kurzbeschreibung:      
 * Der Benutzer wird aufgefordert, ein vorgegebenes deutsches Wort ins
 * Englische zu übersetzen und einzugeben. 
 * ************************************************
*/

using System;

namespace Statistics
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("* ----------------------------------------- *");
            Console.WriteLine("*               Vokabeltrainer              *");
            Console.WriteLine("* ----------------------------------------- *");
            Console.WriteLine("*               Expertenabschnitt           *");
            Console.WriteLine("* ----------------------------------------- *");
            Console.Write("Englisches Wort: ");
            string english = Console.ReadLine();
            Console.Write("Deutsche Übersetzung: ");
            string german = Console.ReadLine();

            //Console.Clear();
            Console.WriteLine("* ----------------------------------------- *");
            Console.WriteLine("*               Schülerabschnitt            *");
            Console.WriteLine("* ----------------------------------------- *");
            string studentAnswer = "";
            int nrOfTries = 0;
            bool answerOk = false;
            Console.WriteLine("Gib die deutsche Übersetzung für {0} an: ", english);
            do
            {
                nrOfTries++;
                Console.Write("Versuch " + nrOfTries + ": ");
                studentAnswer = Console.ReadLine();
                answerOk = (studentAnswer.ToLower() == german.ToLower());
            } while (!answerOk && nrOfTries < 5);

            //Auswertung
            if (nrOfTries == 1)
            {
                Console.WriteLine("Ausgezeichnet! Sofort gewußt!");
            }
            else if (nrOfTries == 2 || nrOfTries == 3)
            {
                Console.WriteLine("Gut gemacht, nur {0} Versuche!", nrOfTries);
            }
            else
            {
                Console.WriteLine("Das war wohl nichts!!");
            }
            Console.ReadKey();
        }
    }
}

