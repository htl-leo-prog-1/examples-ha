/***********************************************************************************************
 * Übungsnr:        14                                     
 * Programmname:    Split
 * Autor:           Michael Bucek  
 * Klasse:          1CHIF
 * Datum:           06.01.2014                               
 * ------------------------------------------------ 
 * Kurzbeschreibung:      
 * Das Programm ließt zunächst einen beliebigen Text in einen String ein.
 * Als nächstes wird das gewünschte Trennzeichen eingelesen. Dieses Zeichen soll in einem char
 * gespeichert werden! (Eingabeprüfung: Länge 1 -> sonst Eingabe wiederholen!)  
 * Nun soll der eingegebene Text nach dem eingegebenen Trennzeichen aufgesplittet werden.
 ************************************************************************************************/

using System;

namespace StringSplit
{
    class Program
    {
        static void Main(string[] args)
        {
            string text;
            char delimiter;
            string input;
            string actWord;

            Console.Write("Eingabetext:");
            text = Console.ReadLine();

            do //Trennzeichen einlesen solange bis Länge 1
            {
                Console.Write("Trennzeichen:");
                input = Console.ReadLine();
                if (input.Length != 1)
                    Console.WriteLine("Das Trennzeichen muss genau ein Zeichen sein!");
            } while (input.Length != 1);

            delimiter = Convert.ToChar(input);

            actWord = "";

            Console.WriteLine("\nTeiltexte:\n\n");
            for (int actIdx = 0; actIdx < text.Length; actIdx++) //Alle Zeichen des Eingabetextes prüfen
            {
                if (text[actIdx] == delimiter) //Trennzeichen gefunden
                {
                    //aktuellen Teiltext ausgeben und Teiltext wieder auf Leerstring setzen
                    Console.WriteLine(actWord);
                    actWord = "";
                }
                else
                {
                    //Kein Trennzeichen -> aktuelles Zeichen zum aktuellen Teiltext hinzufügen
                    actWord = actWord + text[actIdx];
                }
            }
            //Letzten text extra ausgeben (da kein Trennzeichen am Schluss folgt)
            Console.WriteLine(actWord);
        }
    }
}
