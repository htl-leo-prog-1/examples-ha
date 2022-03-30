/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: FussballMeisterschaft
*--------------------------------------------------------------
*/

using System.Globalization;

namespace FussballMeisterschaft;

using System;
using System.IO;
using System.Text;

public class Program
{
    const string fileName = "Games.csv";

    private enum MenuSelection
    {
        MenuExit,
        MenuSelectCurrentTeam,
        MenuFilterTeam
    }

    static void Main(string[] args)
    {
        Console.WriteLine("EM-Qualifikation 2020");
        Console.WriteLine("=====================");

        var allGames = ReadGamesFromFile(fileName);

        PrintGames(allGames);
        Console.WriteLine();

        var currentTeam = string.Empty;
        var menuSelection = ShowMenu(currentTeam);

        while (menuSelection != MenuSelection.MenuExit)
        {
            switch (menuSelection)
            {
                case MenuSelection.MenuSelectCurrentTeam:
                    currentTeam = ReadTeamName();
                    break;
                case MenuSelection.MenuFilterTeam:
                    var filteredGames = FilterGamesByCountryName(allGames, currentTeam);
                    PrintGames(filteredGames);
                    PrintGoals(filteredGames, currentTeam);
                    break;
            }
            menuSelection = ShowMenu(currentTeam);
        }
    }

    private static MenuSelection ShowMenu(string currentTeam)
    {
        MenuSelection? menuSelection = null;

        Console.WriteLine("Menu");

        do
        {
            Console.WriteLine("1: Select Team");
            Console.WriteLine("X: Exit");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    menuSelection = MenuSelection.MenuSelectCurrentTeam;
                    break;
                case "X":
                    menuSelection = MenuSelection.MenuExit;
                    break;
            }
        } while (!menuSelection.HasValue);

        return menuSelection.Value;
    }

    private static string ReadTeamName()
    {
        Console.Write("Pleas enter current team: ");
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
        var game = new Game();
        var elements = line.Split(';');

        var countries = elements[(int) CsvColumnsIdx.TeamsColIdx].Replace(" ", "").Split("-");
        var goals = elements[(int) CsvColumnsIdx.ResultColIdx].Split(":");

        game.Date = DateTime.ParseExact(elements[(int) CsvColumnsIdx.DateColIdx], "dd.MM.yyyy",
            CultureInfo.InvariantCulture);
        game.HomeTeam = countries[0];
        game.GuestTeam = countries[1];
        game.GoalsHome = int.Parse(goals[0]);
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
                $"{game.Date.ToShortDateString()} {game.HomeTeam,-15} {game.GuestTeam,-15} {game.GoalsHome}:{game.GoalsGuest}");
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
            if (IsCountryGame(game.HomeTeam, countryName))
            {
                goals += game.GoalsHome;
                gotGoals += game.GoalsGuest;
            }
            else if (IsCountryGame(game.GuestTeam, countryName))
            {
                goals += game.GoalsGuest;
                gotGoals += game.GoalsHome;
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
        return IsCountryGame(game.HomeTeam, countryName)
               || IsCountryGame(game.GuestTeam, countryName);
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