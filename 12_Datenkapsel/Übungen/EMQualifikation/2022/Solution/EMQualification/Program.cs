/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: EMQualification
*--------------------------------------------------------------
*/

namespace EMQualification;

using System;
using System.IO;
using System.Text;

public class Program
{
    const string fileName = "Games.csv";

    static void Main(string[] args)
    {
        Console.WriteLine("EM-Qualifikation 2020");
        Console.WriteLine("=====================");

        var allGames = ReadGamesFromFile(fileName);

        PrintGames(allGames);
        Console.WriteLine();

        string countryName = ReadCountryName();

        while (!string.IsNullOrEmpty(countryName))
        {
            var filteredGames = FilterGamesByCountryName(allGames, countryName);
            PrintGames(filteredGames);
            PrintGoals(filteredGames, countryName);

            countryName = ReadCountryName();
        }
    }

    private static string ReadCountryName()
    {
        Console.Write("Abfrage der Spiele für ein bestimmtes Land: ");
        return Console.ReadLine();
    }

    public static Game[] ReadGamesFromFile(string fileName)
    {
        var lines = File.ReadAllLines(fileName, Encoding.Default);
        var games = new Game[lines.Length - 1]; // ignore headline
        
        for (int i = 1; i < lines.Length; i++)
        {
            games[i - 1] = ReadGameFromLine(lines[i]); // i-1 because of headline
        }

        return games;
    }
    private enum CsvColumnsIdx
    {
        DateColIdx=0,
        TeamsColIdx,
        ResultColIdx
    }

    private static Game ReadGameFromLine(string line)
    {
        var game = new Game();
        var elements = line.Split(';');
        
        var countries = elements[(int)CsvColumnsIdx.TeamsColIdx].Replace(" ", "").Split("-");
        var goals = elements[(int)CsvColumnsIdx.ResultColIdx].Split(":");

        game.SetDate(elements[(int)CsvColumnsIdx.DateColIdx]);
        game.SetHomeTeam(countries[0]);
        game.SetGuestTeam(countries[1]);
        game.SetGoalsHome(int.Parse(goals[0]));
        game.SetGoalsGuest(int.Parse(goals[1]));
        
        return game;
    }

    private static void PrintGames(Game[] games)
    {
        var header = $"{"Datum",-10} {"Home-Team",-15} {"Guest-Team",-15}";
        
        Console.WriteLine(header);
        Console.WriteLine(new String('=', header.Length + 4));
        
        foreach (var game in games)
        {
            Console.WriteLine(
                $"{game.GetDate()} {game.GetHomeTeam(),-15} {game.GetGuestTeam(),-15} {game.GetGoalsHome()}:{game.GetGoalsGuest()}");
        }
    }

    private static void PrintGoals(Game[] games, string countryName)
    {
        int goals;
        int gotGoals;

        CountGoals(games, countryName, out goals, out gotGoals);

        Console.WriteLine($"Tore {goals}:{gotGoals} Tordifferenz: {goals - gotGoals}");
    }

    public static void CountGoals(Game[] games, string countryName, out int goals, out int gotGoals)
    {
        goals = 0;
        gotGoals = 0;

        foreach (var game in games)
        {
            if (IsCountryGame(game.GetHomeTeam(), countryName))
            {
                goals += game.GetGoalsHome();
                gotGoals += game.GetGoalsGuest();
            }
            else if (IsCountryGame(game.GetGuestTeam(), countryName))
            {
                goals += game.GetGoalsGuest();
                gotGoals += game.GetGoalsHome();
            }
        }
    }

    public static Game[] FilterGamesByCountryName(Game[] games, string countryName)
    {
        var filteredGames = new Game[games.Length];
        var count = 0;

        foreach (var game in games)
        {
            if (IsCountryGame(game, countryName))
            {
                filteredGames[count] = game;
                count++;
            }
        }

        return Copy(filteredGames, count);
    }

    private static bool IsCountryGame(Game game, string countryName)
    {
        return IsCountryGame(game.GetHomeTeam(), countryName)
               || IsCountryGame(game.GetGuestTeam(), countryName);
    }

    private static bool IsCountryGame(string countryName, string lookForCountryName)
    {
        return countryName.ToUpper().Contains(lookForCountryName.ToUpper());
    }

    private static Game[] Copy(Game[] src, int count)
    {
        var dest = new Game[count];
        for (int i = 0; i < count; i++)
        {
            dest[i] = src[i];
        }

        return dest;
    }
}