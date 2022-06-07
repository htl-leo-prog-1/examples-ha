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

public class FussballMeisterschaft
{
    static void Main(string[] args)
    {
        Console.WriteLine("Fussball-Meisterschaft");
        Console.WriteLine("=====================");

        string fileName = "Games.csv";

        if (args.Length == 1)
        {
            fileName = args[0];
        }

        var allGames = ReadGamesFromFile(fileName);

        var teams = CreateListOfTeams(allGames);

        teams = SortByScore(allGames, teams);

        PrintTeams(teams);
    }

    /// <summary>
    /// Read the csv File and return the result as an array
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns>All games stored in the csv file.</returns>
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
        RoundColIdx = 0,
        DateColIdx,
        HomeTeamsColIdx,
        GuestTeamsColIdx,
        ScoreColIdx,
        HalfTimeScoreColIdx,
    }

    private static Game ReadGameFromLine(string line)
    {
        var game     = new Game();
        var elements = line.Split(';');

        var goals         = elements[(int)CsvColumnsIdx.ScoreColIdx].Split(":");
        var halfTimeGoals = elements[(int)CsvColumnsIdx.HalfTimeScoreColIdx].TrimStart('(').TrimEnd(')').Split(":");

        game.Round = int.Parse(elements[(int)CsvColumnsIdx.RoundColIdx]);
        game.Date = DateTime.ParseExact(elements[(int)CsvColumnsIdx.DateColIdx], "d.M.yyyy H:m",
            CultureInfo.InvariantCulture);
        game.HomeTeam           = elements[(int)CsvColumnsIdx.HomeTeamsColIdx];
        game.GuestTeam          = elements[(int)CsvColumnsIdx.GuestTeamsColIdx];
        game.GoalsHome          = int.Parse(goals[0]);
        game.GoalsGuest         = int.Parse(goals[1]);
        game.HalfTimeGoalsHome  = int.Parse(halfTimeGoals[0]);
        game.HalfTimeGoalsGuest = int.Parse(halfTimeGoals[1]);

        return game;
    }

    /// <summary>
    /// Print all teams to the console (as a list).
    /// </summary>
    /// <param name="teams"></param>
    public static void PrintTeams(Team[] teams)
    {
        var header = $"{"Rank"} {"Team",-40} {"SP",3} {"S",3} {"N",3} {"U",3} {"Tore",6} {"+/-",6} {"Pt",4}";
        var rank   = 1;

        Console.WriteLine(header);
        Console.WriteLine(new String('=', header.Length + 4));

        foreach (var team in teams)
        {
            Console.WriteLine(
                $"{rank++,4} {team.TeamName,-40} {team.GameCount,3} {team.WinCount,3} {team.LossCount,3} {team.TieCount,3} {team.GoalVsGot,6} {team.GoalDiff,6} {team.Points,4}");
        }
    }

    /// <summary>
    /// Calculate the goal diff.
    /// </summary>
    /// <param name="games"></param>
    /// <param name="teamName"></param>
    /// <param name="goals"></param>
    /// <param name="gotGoals"></param>
    public static void CountGoals(Game[] games, string teamName, out int goals, out int gotGoals)
    {
        goals    = 0;
        gotGoals = 0;

        foreach (var game in games)
        {
            if (IsGameOfTeam(game.HomeTeam, teamName))
            {
                goals    += game.GoalsHome;
                gotGoals += game.GoalsGuest;
            }
            else if (IsGameOfTeam(game.GuestTeam, teamName))
            {
                goals    += game.GoalsGuest;
                gotGoals += game.GoalsHome;
            }
        }
    }

    /// <summary>
    /// Calculates the points (1 tie, 3 win) for the team.
    /// Use only games where the team is ether home or guest.
    /// </summary>
    /// <param name="games"></param>
    /// <param name="teamName"></param>
    /// <returns>Total "Points"</returns>
    public static int CalculatePoints(Game[] games, string teamName)
    {
        int points = 0;
        foreach (var game in games)
        {
            if (IsGameOfTeam(game.HomeTeam, teamName))
            {
                points += game.HomePoints;
            }
            else if (IsGameOfTeam(game.GuestTeam, teamName))
            {
                points += game.GuestPoints;
            }
        }

        return points;
    }

    /// <summary>
    /// Calculates the away goals for the specified team.
    /// </summary>
    /// <param name="games"></param>
    /// <param name="teamName"></param>
    /// <returns>Amount of away goals based on the game list.</returns>
    public static int CountAwayGoals(Game[] games, string teamName)
    {
        int awayGoals = 0;

        foreach (var game in games)
        {
            if (IsGameOfTeam(game.GuestTeam, teamName))
            {
                awayGoals += game.GoalsGuest;
            }
        }

        return awayGoals;
    }

    /// <summary>
    /// Filter the games by two teams.
    /// </summary>
    /// <param name="games"></param>
    /// <param name="teamName1"></param>
    /// <param name="teamName2"></param>
    /// <returns>A new array with all games of both teams (usual two games).</returns>
    public static Game[] FilterGamesByTeam(Game[] games, string teamName1, string teamName2)
    {
        var filteredGames = new Game[games.Length];
        var count         = 0;

        foreach (var game in games)
        {
            if (IsGameOfTeam(game, teamName1) && IsGameOfTeam(game, teamName2))
            {
                filteredGames[count] = game;
                count++;
            }
        }

        return Tools.Copy(filteredGames, count);
    }

    /// <summary>
    /// Create a array of teams based on the games.
    /// </summary>
    /// <param name="games"></param>
    /// <returns>Unsorted list of teams.</returns>
    public static Team[] CreateListOfTeams(Game[] games)
    {
        var teams     = new Team[games.Length];
        int teamCount = 0;

        foreach (var game in games)
        {
            int teamIdx = Tools.IndexOf(teams, teamCount, game.HomeTeam);
            if (teamIdx < 0)
            {
                teams[teamCount]          = new Team();
                teams[teamCount].TeamName = game.HomeTeam;
                teamIdx                   = teamCount;
                teamCount++;
            }

            teams[teamIdx].GoalsCount += game.GoalsHome;
            teams[teamIdx].GotGoalsCount   += game.GoalsGuest;
            teams[teamIdx].WinCount   += game.GoalsHome > game.GoalsGuest ? 1 : 0;
            teams[teamIdx].LossCount  += game.GoalsHome < game.GoalsGuest ? 1 : 0;
            teams[teamIdx].TieCount   += game.GoalsHome == game.GoalsGuest ? 1 : 0;
        }

        foreach (var game in games)
        {
            int teamIdx = Tools.IndexOf(teams, teamCount, game.GuestTeam);
            teams[teamIdx].GotGoalsCount   += game.GoalsHome;
            teams[teamIdx].GoalsCount += game.GoalsGuest;
            teams[teamIdx].WinCount   += game.GoalsHome < game.GoalsGuest ? 1 : 0;
            teams[teamIdx].LossCount  += game.GoalsHome > game.GoalsGuest ? 1 : 0;
            teams[teamIdx].TieCount   += game.GoalsHome == game.GoalsGuest ? 1 : 0;
        }

        return Tools.Copy(teams, teamCount);
    }

    private static bool IsGameOfTeam(Game game, string countryName)
    {
        return IsGameOfTeam(game.HomeTeam,     countryName)
               || IsGameOfTeam(game.GuestTeam, countryName);
    }

    private static bool IsGameOfTeam(string countryName, string lookForCountryName)
    {
        return countryName.ToUpper().Contains(lookForCountryName.ToUpper());
    }

    /// <summary>
    /// Sort the team array.
    ///  1. by point
    ///  2. by direct compare,
    ///  3. ...
    /// </summary>
    /// <param name="games"></param>
    /// <param name="teams"></param>
    /// <returns>Sorted team array</returns>
    public static Team[] SortByScore(Game[] games, Team[] teams)
    {
        teams = Tools.Copy(teams, teams.Length);

        bool swapped = false;
        do
        {
            swapped = false;
            for (int i = 1; i < teams.Length; i++)
            {
                if (IsBetterRanking(games, teams, i, i - 1))
                {
                    var tmp = teams[i];
                    teams[i]     = teams[i - 1];
                    teams[i - 1] = tmp;
                    swapped      = true;
                }
            }
        } while (swapped);

        return teams;
    }


    /// <summary>
    /// Compare two teams for ranking.
    ///   Haben zwei oder mehr Mannschaften die gleiche Punkteanzahl, entscheidet die Anzahl der Punkte aus den direkten Spielen der betreffenden Teams gegeneinander über die Reihung.Ausnahme: Bei Strafverifizierungen erfolgt weiterhin eine automatische Rückreihung bei Punktegleichheit.
    ///   Bei gleicher Punkteanzahl aus den direkten Begegnungen entscheidet die bessere Tordifferenz aus den direkten Partien der betreffenden Teams.
    ///   Ist auch die Tordifferenz gleich, entscheidet die höhere Zahl an erzielten Toren.
    ///   Wenn auch die gleich ist, wird die Höhe der erzielten Auswärtstore herangezogen.
    ///   Erst wenn auch die gleich ist, entscheidet wie bisher die Tordifferenz aus allen Meisterschaftspartien.
    /// </summary>
    /// <param name="games"></param>
    /// <param name="teams"></param>
    /// <param name="teamIdx1">Index of team1</param>
    /// <param name="teamIdx2">Index of team2</param>
    /// <returns>Return true if teamIdx1 has a better ranking as teamIdx2, otherwise false.</returns>
    public static bool IsBetterRanking(Game[] games, Team[] teams, int teamIdx1, int teamIdx2)
    {
        bool isBetterRank = false;
        if (teams[teamIdx1].Points == teams[teamIdx2].Points)
        {
            var directCompare = FilterGamesByTeam(games, teams[teamIdx1].TeamName, teams[teamIdx2].TeamName);

            int goals;
            int gotGoals;
            int awayGoal1=0;
            int awayGoal2=0;


            CountGoals(directCompare, teams[teamIdx1].TeamName, out goals, out gotGoals);

            int points = CalculatePoints(directCompare, teams[teamIdx1].TeamName) -
                         CalculatePoints(directCompare, teams[teamIdx2].TeamName);

            if (points > 0 ||
                (points == 0 && goals > gotGoals) ||
                (points == 0 && goals == gotGoals && (awayGoal1=CountAwayGoals(directCompare, teams[teamIdx1].TeamName)) > (awayGoal2=CountAwayGoals(directCompare, teams[teamIdx2].TeamName))) ||
                (points == 0 && goals == gotGoals && awayGoal1 == awayGoal2 && teams[teamIdx1].GoalDiff > teams[teamIdx2].GoalDiff)
                )
            {
                isBetterRank = true;
            }
        }
        else if (teams[teamIdx1].Points > teams[teamIdx2].Points)
        {
            isBetterRank = true;
        }

        return isBetterRank;
    }
}