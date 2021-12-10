/***********************************************************************************************
 * Übungsnr:        14                                     
 * Programmname:    Buchstabenzähler
 * Autor:           Michael Bucek  
 * Klasse:          1CHIF
 * Datum:           06.01.2014                               
 * ------------------------------------------------ 
 * Kurzbeschreibung:      
 * Es soll gezählt werden, wie oft die einzelnen Buchstaben von A-Z in einem eingegebenen Text
 * vorkommen. Kleinbuchstaben sollen dabei als Großbuchstaben gezählt werden! Ausgabe als Tabelle.
 ************************************************************************************************/

using System;

namespace LetterCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            string text;
            int[] counter = new int[26];

            Console.Write("Eingabetext:");
            text = Console.ReadLine().ToUpper();

            
            for (int actIdx = 0; actIdx < text.Length; actIdx++) //Alle Zeichen des Eingabetextes prüfen
            {
                if ((text[actIdx] >= 'A') && (text[actIdx] <= 'Z')) //Handelt es sich um einen Buchstaben (Unicode Tabelle..)
                {

                    counter[text[actIdx] - 'A']++;
                }
            }

            Console.WriteLine("\nAnzahl der Buchstaben:\n");

            //Buchstabentabelle ausgeben (immer 2 Buchstaben nebeneinander)
            for (int i = 0; i < 13; i++)
            {
                Console.WriteLine("{0}:{1:d3}    {2}:{3:d3}", Convert.ToChar(i + 'A'), counter[i], (char) (i + 13 + 'A'), counter[i + 13]);
            }
        }
    }
}
