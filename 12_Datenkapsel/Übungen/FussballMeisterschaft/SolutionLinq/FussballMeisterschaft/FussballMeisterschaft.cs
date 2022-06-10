/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: FussballMeisterschaft
*--------------------------------------------------------------
*/

namespace FussballMeisterschaft;

using System;
using System.Collections.Generic;
using System.Linq;

public class FussballMeisterschaft
{
    static void Main(string[] args)
    {
        Console.WriteLine("Fussball-Meisterschaft");
        Console.WriteLine("=====================");

        string fileName = "Games.csv";

        if (args.Length >= 1)
        {
            fileName = args[0];
        }

        var allGames = ReadGamesFromFile(fileName);
        var teams    = CreateListOfTeams(allGames);
        teams = SortByOefb(teams, allGames);

        PrintTeams(teams);
    }

    /// <summary>
    /// Read the Csv File and return the result as an array.
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns>All games stored in the Csv file.</returns>
    public static IEnumerable<Game> ReadGamesFromFile(string fileName)
    {
        var csvImporter = new CsvImport<GameCsv>();
        csvImporter.DateFormat = "d.M.yyyy";
        csvImporter.TimeFormat = "H:m";

        return csvImporter.Read(fileName).Select(gameCsv => ConvertTo(gameCsv));
    }

    private static Game ConvertTo(GameCsv gameCsv)
    {
        var game = new Game();

        var goals         = gameCsv.Score.Split(":");
        var halfTimeGoals = gameCsv.ScoreHalfTime.TrimStart('(').TrimEnd(')').Split(":");

        game.Round              = gameCsv.Round;
        game.Date               = gameCsv.Date;
        game.HomeTeam           = gameCsv.HomeTeam;
        game.GuestTeam          = gameCsv.GuestTeam;
        game.GoalsHome          = int.Parse(goals[0]);
        game.GoalsGuest         = int.Parse(goals[1]);
        game.HalfTimeGoalsHome  = int.Parse(halfTimeGoals[0]);
        game.HalfTimeGoalsGuest = int.Parse(halfTimeGoals[1]);

        return game;
    }

    /// <summary>
    /// Print all teams to the console (as a list).
    /// </summary>
    /// <param name="teams">All teams to be printed.</param>
    public static void PrintTeams(IEnumerable<Team> teams)
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
    /// Filter games by teams.
    /// Home- and guest team must be in the list of teamNames.
    /// </summary>
    /// <param name="games"></param>
    /// <param name="teamNames"></param>
    /// <returns>A new array with all games of teams.</returns>
    public static IEnumerable<Game> FilterGamesByTeam(IEnumerable<Game> games, IEnumerable<string> teamNames)
    {
        return games.Where(game => game.IsGameOfTeams(teamNames));
    }

    /// <summary>
    /// Create a array of teams based on the games.
    /// Fill all properties in object Team, e.g. WinCount, LossCount, ...
    /// </summary>
    /// <param name="games"></param>
    /// <returns>Unsorted list of teams.</returns>
    public static IEnumerable<Team> CreateListOfTeams(IEnumerable<Game> games)
    {
        var teams = games.GroupBy(g => g.HomeTeam, g => g)
            .Select(g => new Team()
            {
                TeamName      = g.Key,
                GoalsCount    = g.Sum(game => game.GoalsHome),
                GotGoalsCount = g.Sum(g => g.GoalsGuest),
                WinCount      = g.Sum(g => g.GoalsHome > g.GoalsGuest ? 1 : 0),
                LossCount     = g.Sum(g => g.GoalsHome < g.GoalsGuest ? 1 : 0),
                TieCount      = g.Sum(g => g.GoalsHome == g.GoalsGuest ? 1 : 0)
            })
            .ToList();

        foreach (var game in games)
        {
            var team = teams.FirstOrDefault(t => game.GuestTeam == t.TeamName);
            if (team == default)
            {
                team          = new Team();
                team.TeamName = game.GuestTeam;
                teams.Add(team);
            }

            team.GotGoalsCount  += game.GoalsHome;
            team.GoalsCount     += game.GoalsGuest;
            team.AwayGoalsCount += game.GoalsGuest;
            team.WinCount       += game.GoalsHome < game.GoalsGuest ? 1 : 0;
            team.LossCount      += game.GoalsHome > game.GoalsGuest ? 1 : 0;
            team.TieCount       += game.GoalsHome == game.GoalsGuest ? 1 : 0;
        }

        return teams;
    }

    /// <summary>
    /// Sort the teams by OFB rules.
    /// </summary>
    /// <param name="games"></param>
    /// <param name="teams"></param>
    /// <returns>Sorted team array.</returns>
    public static IEnumerable<Team> SortByOefb(IEnumerable<Team> teams, IEnumerable<Game> games)
    {
        // 2. for all "groups" of teams with same points
        //   => extract group
        //   => Create Results (with SortBy)
        //   => set the Position (=Property PosIfSamePoints) in teams
        // 3. sort again (using PosIfSamePoints)

        var samePointGroups = teams.GroupBy(team => team.Points, team => team).Where(grp => grp.Count() >= 2);
        
        foreach (var samePointGroup in samePointGroups)
        {
            var teamsSub = SortBy(CreateListOfTeams(FilterGamesByTeam(games, samePointGroup.Select(t => t.TeamName))));
            SetPositionInSubGroup(teams, teamsSub);
        }

        return SortBy(teams);
    }

    /// <summary>
    /// Set the property "PosIfSamePoints" for the specified "sub-group".
    /// All teams in the sub-group have the same "points".
    /// Teams with same result (in the sub-group) must get the identical PosIsSamePoints.
    /// It is necessary for the order by GoalDiff, ... of the main group.
    /// </summary>
    /// <param name="teams">All teams - here to set the subgroup result.</param>
    /// <param name="subTeams">Result of the sub group</param>
    private static void SetPositionInSubGroup(IEnumerable<Team> teams, IEnumerable<Team> subTeams)
    {
        var subTeamAr = subTeams.ToArray();
        PrintTeams(subTeamAr);
        
        int  posIfSamePoints = 1;
        Team lastTeam        = null;
       
        foreach (var team in subTeamAr)
        {
            if (lastTeam != null && !team.IsEqualRank(lastTeam))
            {
                posIfSamePoints++;
            }

            teams.First(t => t.TeamName == team.TeamName).PosIfSamePoints = posIfSamePoints;
            lastTeam = team;
        }
    }

    /// Sort the team array.
    ///  1. by point
    ///  2. if points equal by goalDiff
    ///  3. ...
    /// </summary>
    /// <param name="teams"></param>
    /// <returns>Sorted teams</returns>
    public static IEnumerable<Team> SortBy(IEnumerable<Team> teams)
    {
        return teams
            .OrderByDescending(t => t.Points)
            .ThenBy(t => t.PosIfSamePoints)
            .ThenByDescending(t => t.GoalDiff)
            .ThenByDescending(t => t.GoalsCount)
            .ThenByDescending(t => t.AwayGoalsCount)
            .ThenBy(t => t.TeamName);
    }
}