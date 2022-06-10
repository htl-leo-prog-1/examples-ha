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

public class SoccerChampion
{
    /// <summary>
    /// Get the sorted list) of champions.
    /// This are teams (class Team).
    /// </summary>
    /// <param name="fileName">Csv file-name with "games".</param>
    public static IEnumerable<Team> GetChampions(string fileName)
    {
        var allGames = ReadGamesFromFile(fileName).ToList();
        var teams    = CreateListOfTeams(allGames);

        return SortByOefb(teams, allGames);
    }

    /// <summary>
    /// Print all teams to the console (as a list).
    /// </summary>
    /// <param name="teams">All teams to be printed.</param>
    public static void PrintTeams(IEnumerable<Team> teams)
    {
        var header = $"Rank {"Team",-40} {"SP",3} {"S",3} {"N",3} {"U",3} {"Tore",6} {"+/-",6} {"Pt",4}";
        var rank   = 1;

        Console.WriteLine(header);
        Console.WriteLine(new String('=', header.Length + 4));

        foreach (var team in teams)
        {
            Console.WriteLine($"{rank++,4} {team.TeamName,-40} {team.GameCount,3} {team.WinCount,3} {team.LossCount,3} {team.TieCount,3} {team.GoalVsGot,6} {team.GoalDiff,6} {team.Points,4}");
        }
    }

    /// <summary>
    /// Read the Csv File and return the result as an array.
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns>All games stored in the Csv file.</returns>
    public static IEnumerable<Game> ReadGamesFromFile(string fileName)
    {
        var csvImporter = new Tools.CsvImport<GameCsv>()
        {
            DateFormat = "d.M.yyyy",
            TimeFormat = "H:m"
        };

        return csvImporter.Read(fileName).Select(gameCsv =>
        {
            var goals         = gameCsv.Score.Split(":");
            var halfTimeGoals = gameCsv.ScoreHalfTime.TrimStart('(').TrimEnd(')').Split(":");

            return new Game()
            {
                Round              = gameCsv.Round,
                Date               = gameCsv.Date,
                HomeTeam           = gameCsv.HomeTeam,
                GuestTeam          = gameCsv.GuestTeam,
                GoalsHome          = int.Parse(goals[0]),
                GoalsGuest         = int.Parse(goals[1]),
                HalfTimeGoalsHome  = int.Parse(halfTimeGoals[0]),
                HalfTimeGoalsGuest = int.Parse(halfTimeGoals[1])
            };
        });
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
        var gameList = games.ToList();
        var teams = gameList.GroupBy(g => g.HomeTeam, g => g)
            .Select(grp => new Team()
            {
                TeamName      = grp.Key,
                GoalsCount    = grp.Sum(g => g.GoalsHome),
                GotGoalsCount = grp.Sum(g => g.GoalsGuest),
                WinCount      = grp.Sum(g => g.GoalsHome > g.GoalsGuest ? 1 : 0),
                LossCount     = grp.Sum(g => g.GoalsHome < g.GoalsGuest ? 1 : 0),
                TieCount      = grp.Sum(g => g.GoalsHome == g.GoalsGuest ? 1 : 0)
            })
            .Concat(
                gameList.GroupBy(g => g.GuestTeam, g => g)
                    .Select(grp => new Team()
                    {
                        TeamName       = grp.Key,
                        GoalsCount     = grp.Sum(g => g.GoalsGuest),
                        GotGoalsCount  = grp.Sum(g => g.GoalsHome),
                        AwayGoalsCount = grp.Sum(g => g.GoalsGuest),
                        WinCount       = grp.Sum(g => g.GoalsHome < g.GoalsGuest ? 1 : 0),
                        LossCount      = grp.Sum(g => g.GoalsHome > g.GoalsGuest ? 1 : 0),
                        TieCount       = grp.Sum(g => g.GoalsHome == g.GoalsGuest ? 1 : 0)
                    }));

        return teams.GroupBy(t => t.TeamName).Select(
                grp => new Team()
                {
                    TeamName       = grp.Key,
                    WinCount       = grp.Sum(t => t.WinCount),
                    LossCount      = grp.Sum(t => t.LossCount),
                    TieCount       = grp.Sum(t => t.TieCount),
                    GoalsCount     = grp.Sum(t => t.GoalsCount),
                    GotGoalsCount  = grp.Sum(t => t.GotGoalsCount),
                    AwayGoalsCount = grp.Sum(t => t.AwayGoalsCount)
                })
            .ToList();
    }

    /// <summary>
    /// Sort the teams by OFB rules.
    /// </summary>
    /// <param name="games"></param>
    /// <param name="teams"></param>
    /// <returns>Sorted team array.</returns>
    public static IEnumerable<Team> SortByOefb(IEnumerable<Team> teams, IEnumerable<Game> games)
    {
        // 1. for all "groups" of teams with same points
        //   => extract group
        //   => Create Results (with SortBy)
        //   => set the Position (=Property PosIfSamePoints) in teams
        // 2. sort again (using PosIfSamePoints)
        var teamList = teams.ToList();
        var gameList = games.ToList();

        var samePointGroups = teamList
            .GroupBy(team => team.Points, team => team)
            .Where(grp => grp.Count() >= 2);

        foreach (var samePointGroup in samePointGroups)
        {
            var teamsSub = SortBy(CreateListOfTeams(FilterGamesByTeam(gameList, samePointGroup.Select(t => t.TeamName))));
            SetPositionInSubGroup(teamList, teamsSub);
        }

        return SortBy(teamList);
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
        var subTeamList = subTeams.ToList();
        var teamsList   = teams.ToList();

        PrintTeams(subTeamList); // for debug

        int  posIfSamePoints = 1;
        Team lastTeam        = null;

        foreach (var team in subTeamList)
        {
            if (lastTeam != null && !team.IsEqualRank(lastTeam))
            {
                posIfSamePoints++;
            }

            teamsList.First(t => t.TeamName == team.TeamName).PosIfSamePoints = posIfSamePoints;

            lastTeam = team;
        }
    }

    /// <summary>
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