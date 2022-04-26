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

        string teamName = ReadTeamName();

        while (!string.IsNullOrEmpty(teamName))
        {
            var filteredGames = FilterGamesByTeamName(allGames, teamName);
            PrintGames(filteredGames);
            PrintGoals(filteredGames, teamName);

            teamName = ReadTeamName();
        }
    }

    private static string ReadTeamName()
    {
        Console.Write("Abfrage der Spiele für ein bestimmtes Team: ");
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
        DateColIdx = 0,
        TeamsColIdx,
        ResultColIdx
    }

    private static Game ReadGameFromLine(string line)
    {
        var game     = new Game();
        var elements = line.Split(';');

        var countries = elements[(int)CsvColumnsIdx.TeamsColIdx].Replace(" ", "").Split("-");
        var goals     = elements[(int)CsvColumnsIdx.ResultColIdx].Split(":");

        game.Date       = elements[(int)CsvColumnsIdx.DateColIdx];
        game.HomeTeam   = countries[0];
        game.GuestTeam  = countries[1];
        game.GoalsHome  = int.Parse(goals[0]);
        game.GoalsGuest = int.Parse(goals[1]);

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
                $"{game.Date} {game.HomeTeam,-15} {game.GuestTeam,-15} {game.GoalsHome}:{game.GoalsGuest}");
        }
    }

    private static void PrintGoals(Game[] games, string teamName)
    {
        int goals;
        int gotGoals;

        CountGoals(games, teamName, out goals, out gotGoals);

        Console.WriteLine($"Tore {goals}:{gotGoals} Tordifferenz: {goals - gotGoals}");
    }

    public static void CountGoals(Game[] games, string teamName, out int goals, out int gotGoals)
    {
        goals    = 0;
        gotGoals = 0;

        foreach (var game in games)
        {
            if (game.IsGameOfHomeTeam(teamName))
            {
                goals    += game.GoalsHome;
                gotGoals += game.GoalsGuest;
            }
            else if (game.IsGameOfGuestTeam(teamName))
            {
                goals    += game.GoalsGuest;
                gotGoals += game.GoalsHome;
            }
        }
    }

    public static Game[] FilterGamesByTeamName(Game[] games, string teamName)
    {
        var filteredGames = new Game[games.Length];
        var count         = 0;

        foreach (var game in games)
        {
            if (game.IsGameOfTeam(teamName))
            {
                filteredGames[count] = game;
                count++;
            }
        }

        return Copy(filteredGames, count);
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