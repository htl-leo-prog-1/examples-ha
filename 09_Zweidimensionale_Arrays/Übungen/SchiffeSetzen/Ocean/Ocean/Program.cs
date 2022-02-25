/***********************************************************************************************
 * Übungsnr:        13                                     
 * Programmname:    Schiffe setzen
 * Autor:           Michael Bucek  
 * Klasse:          1CHIF
 * Datum:           16.12.2013                               
 * ------------------------------------------------ 
 * Kurzbeschreibung:      
 * Gesucht ist ein Programm, welches eine Tabelle wie beim Spiel „Schifferl versenken“ auf
 * dem Bildschirm zeichnet (vgl. Screenshot). Der Benutzer kann nun eingeben, an welcher
 * Position der Tabelle ein Schiff gesetzt wird (z.B. Eingabe „B4“).
 * Nach jeder Eingabe soll die Tabelle neu gezeichnete werden,
 * dabei werden alle gesetzten Schiffe mit einem X markiert.
 * Der Benutzer kann beliebig viele Schiffe setzen (Abbruch  durch Eingabe von E).
 ***********************************************************************************************/
using System;

namespace Ocean
{
    class Program
    {
        static bool[,] ocean = new bool[10, 10];
        static string rowSplittingLine;

        static void Main(string[] args)
        {
            //Die Trennlinie zwischen zwei Zeilen aufbauen (abhängig von Spielfeldgröße)
            rowSplittingLine = CreateRowSplittingLine(ocean);
            string input;

            do
            {
                do
                {
                    Console.Clear();

                    //Überschrift der Spalten
                    WriteHeadline();
                    Console.WriteLine(rowSplittingLine);
                    DrawOcean();

                    input = HandleUserInput();

                } while (input != "E");


                Console.Write("Nochmal spielen (J/N) ?");
                input = Console.ReadLine().ToUpper();
            } while (input == "J");
        }

        static string CreateRowSplittingLine(bool[,] ocean)
        {
            string splittingLine;
            splittingLine = "  ";
            for (int i = 0; i < ocean.GetLength(0); i++)
            {
                splittingLine = splittingLine + ("+---");
            }
            splittingLine = splittingLine + ("+");
            return splittingLine;
        }

        static void WriteHeadline()
        {
            Console.Write("  ");
            for (int column = 0; column < ocean.GetLength(1); column++)
            {
                Console.Write("  {0} ", column);
            }
            Console.WriteLine();
        }

        static void DrawOcean()
        {
            for (int row = 0; row < ocean.GetLength(0); row++)
            {
                Console.Write(Convert.ToChar(row + 'A') + " ");
                for (int column = 0; column < ocean.GetLength(1); column++)
                {
                    if (ocean[row, column] == true)
                    {
                        //Ein Schiff platziert
                        Console.Write("| X ");
                    }
                    else
                    {
                        //Feld ohne Schiff
                        Console.Write("|   ");
                    }
                }
                Console.WriteLine("|");
                Console.WriteLine(rowSplittingLine);
            }
        }

        static string HandleUserInput()
        {
            Console.Write("Schiffsteil auf welche Position (z.B. A3) oder E für Ende ?");
            string input = Console.ReadLine().ToUpper();
            int newRow = -1;
            int newCol = -1;
            if (input != "E")
            {
                if (input.Length == 2)
                {
                    //Zeilen und Spaltenindex aus Eingabe berechnen
                    newRow = input.ToUpper()[0] - 'A';
                    if (IsDigit(input[1]))
                    {
                        newCol = Convert.ToInt32(input.Substring(1));
                    }
                }

                if (newCol >= 0 && newRow < ocean.GetLength(0) &&
                    newCol >= 0 && newRow < ocean.GetLength(1))
                {
                    //Nur gültige Arrayposition setzen
                    ocean[newRow, newCol] = true;
                }
                else
                {
                    //Fehlerausgabe (erneute Eingabe nicht extra nötig, 
                    //da ohnehin nach dem Neuzeichnen die nächste Eingabe erfolgt)
                    Console.WriteLine("Ungültige Eingabe! Eingabetaste für neue Eingabe !");
                    Console.ReadLine();
                }
            }
            return input;
        }

        static bool IsDigit(char input)
        {
            return input <= '9' && input >= '0';
        }
    }
}
