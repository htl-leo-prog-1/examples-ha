using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EMQualification
{

    class Program
    {
        const string fileName = "Games.csv";

        /// <summary>
        /// Liest alle Spiele ein, gibt sie aus, fragt den Benutzer nach einem 
        /// Land ab, filtert die Spiele entsprechend der Eingabe und
        /// gibt die gefilterte Liste wieder aus.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {            
            Console.WriteLine("EM-Qualifikation 2012");
            Console.WriteLine("=====================");

            Game[] allGames = ReadGamesFromFile(fileName);
            Console.WriteLine("Alle eingelesenen Spiele:");
            WriteGames(allGames);
            Console.WriteLine();

            Console.WriteLine("Abfrage der Spiele für ein bestimmtes Land");
            Console.Write("Land: ");
            string countryName = Console.ReadLine();
            Game[] filteredGames = FilterGamesByCountryName(allGames, countryName);
            WriteGames(filteredGames);

            PrintTopScorers(allGames);

            Console.Write("Beenden mit der Eingabetaste ...");
            Console.ReadLine();
        }

        /// <summary>
        /// Spiele aus der csv-Datei in ein Array einlesen
        /// </summary>
        /// <param name="fileName">Name der Datei im bin\debug-Verzeichnis</param>
        /// <returns>Eingelesene Spiele</returns>
        private static Game[] ReadGamesFromFile(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName, Encoding.Default);
            Game[] games = new Game[lines.Length - 1]; // Überschrift überlesen
            for (int i = 1; i < lines.Length; i++)  
            {
                games[i - 1] = ReadGameFromLine(lines[i]);  // wieder wegen Überschrift i-1
            }
            return games;
        }

        /// <summary>
        /// Daten eines Spiels aus der Zeile parsen
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static Game ReadGameFromLine(string line)
        {
            Game game = new Game();
            string[] elements = line.Split(';');
            game.Home = elements[0];
            game.Guest = elements[1];
            game.ShotHome = int.Parse(elements[2]);
            game.ShotGuest= int.Parse(elements[3]);
            return game;
        }


        /// <summary>
        /// Spiele formatiert auf Bildschirm ausgeben
        /// </summary>
        /// <param name="games"></param>
        private static void WriteGames(Game[] games)
        {
            Console.WriteLine("{0,-15} {1,-15}", "Home", "Guest");
            for (int i = 0; i < games.Length; i++)
            {
                Console.WriteLine("{0,-15} {1,-15} {2}:{3}",
                    games[i].Home, games[i].Guest, games[i].ShotHome, games[i].ShotGuest);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Filtere aus den Spielen jene Spiele heraus, in denen das
        /// gesuchte Land entweder Heim- oder Auswärtsmannschaft ist.
        /// Groß/Kleinschreibung wird nicht beachtet.
        /// </summary>
        /// <param name="allGames"></param>
        /// <param name="countryName"></param>
        /// <returns>Spiele mit Beteiligung des gesuchten Lands</returns>
        private static Game[] FilterGamesByCountryName(Game[] allGames, string countryName)
        {
            Game[] filteredGames;
            int count = 0;
            // Zählen, wieviele Spiele für das Land vorhanden sind
            for (int i = 0; i < allGames.Length; i++)
            {
                if (IsCountryGame(allGames[i], countryName))
                {
                    count++;
                }
            }
            filteredGames = new Game[count];
            count = 0;
            // gefilterte Spiele übernehmen
            for (int i = 0; i < allGames.Length; i++)
            {
                if (IsCountryGame(allGames[i], countryName))
                {
                    filteredGames[count] = allGames[i];
                    count++;
                }
            }
            return filteredGames;
        }

        /// <summary>
        /// Prüft, ob das Land die Heimmannschaft oder die Auswärtsmannschaft ist
        /// </summary>
        /// <param name="game">Zu prüfendes Spiel</param>
        /// <param name="countryName"></param>
        /// <returns>Land ist beteiligt</returns>
        private static bool IsCountryGame(Game game, string countryName)
        {
            return game.Home.ToUpper() == countryName.ToUpper() 
                || game.Guest.ToUpper() == countryName.ToUpper();
        }

        /// <summary>
        /// Ermittelt die Liste der Länder, zählt die Anzahl der
        /// Tore pro Land, gibt die Liste sortiert nach Torzahl
        /// aus.
        /// </summary>
        /// <param name="allGames"></param>
        private static void PrintTopScorers(Game[] allGames)
        {
            Goals[] goals = CreateListOfGoals(allGames);
            Sort(goals);
            Console.WriteLine("Top Scorers:");
            Console.WriteLine("============");
            for (int i = 0; i < goals.Length; i++)
            {
                Console.WriteLine("{0, -3} {1, -30}", goals[i].NrOfGoals, goals[i].Country);
            }
        }

        /// <summary>
        /// Erstellt eine Liste von Goals in richtiger Größe aus
        /// der übergebenen Liste von Spielen. Für jedes Land,
        /// das eingetragen wird, wird auch gleich die Anzahl von
        /// Toren ermittelt.
        /// </summary>
        /// <param name="allGames"></param>
        /// <returns></returns>
        private static Goals[] CreateListOfGoals(Game[] allGames)
        {
            Goals[] goals = new Goals[allGames.Length * 2];
            int count = 0;
            for (int i = 0; i < allGames.Length; i++)
            {
                if (!FindCountry(allGames[i].Home, count, goals))
                {
                    goals[count] = new Goals();
                    goals[count].Country = allGames[i].Home;
                    goals[count].NrOfGoals = CountGoals(allGames, goals[count].Country);
                    count++;
                }
                if (!FindCountry(allGames[i].Guest, count, goals))
                {
                    goals[count] = new Goals();
                    goals[count].Country = allGames[i].Guest;
                    goals[count].NrOfGoals = CountGoals(allGames, goals[count].Country);
                    count++;
                }
            }
            Goals[] finalGames = new Goals[count];
            for (int i = 0; i < finalGames.Length; i++)
            {
                finalGames[i] = goals[i];
            }
            return finalGames;
        }
        /// <summary>
        /// Liefert die Anzahl von Toren aus allen Spielen,
        /// die das übergebene Land geschossen hat.
        /// </summary>
        /// <param name="allGames"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        private static int CountGoals(Game[] allGames, string country)
        {
            int goals = 0;
            for (int i = 0; i < allGames.Length; i++)
            {
                if (allGames[i].Home == country)
                {
                    goals += allGames[i].ShotHome;
                }
                if (allGames[i].Guest == country)
                {
                    goals += allGames[i].ShotGuest;
                }
            }
            return goals;
        }

        /// <summary>
        /// Es wird überprüft, ob ein Land bereits in der Liste
        /// für die Top-Scorer-Berechnung enthalten ist.
        /// </summary>
        /// <param name="country">Name des Landes</param>
        /// <param name="count">Bisheriger Füllstand der Liste goals</param>
        /// <param name="goals">Liste für Name + Anzahl Tore</param>
        /// <returns></returns>
        private static bool FindCountry(string country, int count, Goals[] goals)
        {
            for (int i = 0; i < count; i++)
            {
                if (goals[i].Country == country)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Sortiert die Liste von Goals absteigend nach
        /// der Anzahl der Tore.
        /// </summary>
        /// <param name="goals"></param>
        private static void Sort(Goals[] goals)
        {
            for (int i = 0; i < goals.Length; i++)
            {
                for (int j = i + 1; j < goals.Length; j++)
                {
                    if (goals[i].NrOfGoals < goals[j].NrOfGoals)
                    {
                        Goals temp = goals[i];
                        goals[i] = goals[j];
                        goals[j] = temp;
                    }
                }
            }
        }
    }
}
