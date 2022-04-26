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
        MenuPrintAllGames,
        MenuPrintCurrentTeamGames,
        MenuPrintCurrentTeamGoals,
        MenuPrintAllTeams
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Fussball-Meisterschaft");
        Console.WriteLine("=====================");

        var allGames = ReadGamesFromFile(fileName);
        var currentTeam = string.Empty;

        var menuSelection = ShowMenu(currentTeam, allGames);

        while (menuSelection != MenuSelection.MenuExit)
        {
            switch (menuSelection)
            {
                case MenuSelection.MenuSelectCurrentTeam:
                    currentTeam = ReadTeamName();
                    break;
                case MenuSelection.MenuPrintAllGames:
                    PrintGames(allGames);
                    break;
                case MenuSelection.MenuPrintCurrentTeamGames:
                    var filteredGames = FilterGamesByCountryName(allGames, currentTeam);
                    PrintGames(filteredGames);
                    break;
                case MenuSelection.MenuPrintCurrentTeamGoals:
                    PrintGoals(allGames, currentTeam);
                    break;
                case MenuSelection.MenuPrintAllTeams:
                    PrintTeams(allGames);
                    break;
            }

            menuSelection = ShowMenu(currentTeam, allGames);
        }
    }

    private static MenuSelection ShowMenu(string currentTeam, Game[] allGames)
    {
        MenuSelection? menuSelection = null;

        Console.WriteLine($"Menu (Games:{allGames.Length})");

        do
        {
            if (string.IsNullOrEmpty(currentTeam))
            {
                Console.WriteLine("1: Select team ");
            }
            else
            {
                Console.WriteLine($"1: Select other team - current : {currentTeam}");
            }

            Console.WriteLine("2: print all games");
            if (!string.IsNullOrEmpty(currentTeam))
            {
                Console.WriteLine("3: print games of current team");
                Console.WriteLine("4: goals of current team");
            }

            Console.WriteLine("5: print all teams");
            Console.WriteLine("X: Exit");
            Console.Write("=> ");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    menuSelection = MenuSelection.MenuSelectCurrentTeam;
                    break;
                case "2":
                    menuSelection = MenuSelection.MenuPrintAllGames;
                    break;
                case "3":
                    if (!string.IsNullOrEmpty(currentTeam))
                    {
                        menuSelection = MenuSelection.MenuPrintCurrentTeamGames;
                    }

                    break;
                case "4":
                    if (!string.IsNullOrEmpty(currentTeam))
                    {
                        menuSelection = MenuSelection.MenuPrintCurrentTeamGoals;
                    }

                    break;
                case "5":
                    menuSelection = MenuSelection.MenuPrintAllTeams;
                    break;
                case "x":
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
        var header = $"{"Date",-10} {"Home-Team",-15} {"Guest-Team",-15}";

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

        Console.WriteLine($"Goals {goals}:{gotGoals} Difference: {goals - gotGoals}");
    }

    private static void PrintTeams(Game[] games)
    {
        var teams = Sort(CreateListOfTeams(games));

        var header = $"{"Team",-15} {"SP",3} {"S",3} {"N",3} {"U",3} {"Tore",6} {"+/-",6} {"Pt",4}";

        Console.WriteLine(header);
        Console.WriteLine(new String('=', header.Length + 4));

        foreach (var team in teams)
        {
            Console.WriteLine(
                $"{team.TeamName,-15} {team.Games,3} {team.Win,3} {team.Loss,3} {team.Tie,3} {team.GoalVsGot,6} {team.GoalDiff,6} {team.Points,4}");
        }
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

    private static Team[] CreateListOfTeams(Game[] games)
    {
        var teams = new Team[games.Length];
        int teamCount = 0;
        
        foreach (var game in games)
        {
            int teamIdx = IndexOf(teams, teamCount, game.HomeTeam);
            if (teamIdx < 0)
            {
                teams[teamCount] = new Team();
                teams[teamCount].TeamName = game.HomeTeam;
                teamIdx = teamCount;
                teamCount++;
            }

            teams[teamIdx].Goals += game.GoalsHome;
            teams[teamIdx].Got += game.GoalsGuest;
            teams[teamIdx].Win += game.GoalsHome > game.GoalsGuest ? 1 : 0;
            teams[teamIdx].Loss += game.GoalsHome < game.GoalsGuest ? 1 : 0;
            teams[teamIdx].Tie += game.GoalsHome == game.GoalsGuest ? 1 : 0;
        }

        foreach (var game in games)
        {
            int teamIdx = IndexOf(teams, teamCount, game.GuestTeam);
            teams[teamIdx].Got += game.GoalsHome;
            teams[teamIdx].Goals += game.GoalsGuest;
            teams[teamIdx].Win += game.GoalsHome < game.GoalsGuest ? 1 : 0;
            teams[teamIdx].Loss += game.GoalsHome > game.GoalsGuest ? 1 : 0;
            teams[teamIdx].Tie += game.GoalsHome == game.GoalsGuest ? 1 : 0;
        }

        return Copy(teams, teamCount);
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

    private static Team[] Sort(Team[] teams)
    {
        teams = Copy(teams, teams.Length);

        for (int i = 0; i < teams.Length; i++)
        {
            int min = i;
            for (int j = i + 1; j < teams.Length; j++)
            {
                if (teams[j].Points > teams[min].Points ||
                    (teams[j].Points == teams[min].Points && teams[j].GoalDiff > teams[min].GoalDiff))
                {
                    min = j;
                }
            }

            var tmp = teams[i];
            teams[i] = teams[min];
            teams[min] = tmp;
        }

        return teams;
    }

    private static int IndexOf(Team[] teams, int count, string teamName)
    {
        for (int i = 0; i < count; i++)
        {
            if (teams[i].TeamName == teamName)
            {
                return i;
            }
        }

        return -1;
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
    private static Team[] Copy(Team[] src, int count)
    {
        var dest = new Team[count];
        for (int i = 0; i < count; i++)
        {
            dest[i] = src[i];
        }

        return dest;
    }
}