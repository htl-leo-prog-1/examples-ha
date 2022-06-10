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
using System.Globalization;
using System.IO;
using System.Text;

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

        game.Round              = int.Parse(elements[(int)CsvColumnsIdx.RoundColIdx]);
        game.Date               = DateTime.ParseExact(elements[(int)CsvColumnsIdx.DateColIdx], "d.M.yyyy H:m", CultureInfo.InvariantCulture);
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
    /// <param name="teams">All teams to be printed.</param>
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
    /// Filter games by teams.
    /// Home- and guest team must be in the list of teamNames.
    /// </summary>
    /// <param name="games"></param>
    /// <param name="teamNames"></param>
    /// <returns>A new array with all games of teams.</returns>
    public static Game[] FilterGamesByTeam(Game[] games, string[] teamNames)
    {
        var filteredGames = new Game[games.Length];
        var count         = 0;

        foreach (var game in games)
        {
            if (IsGameOfTeams(game, teamNames))
            {
                filteredGames[count++] = game;
            }
        }

        return Tools.Copy(filteredGames, count);
    }

    /// <summary>
    /// The home and the guest team of the game is within the valid teamNames. 
    /// </summary>
    /// <param name="game"></param>
    /// <param name="teamNames"></param>
    /// <returns>true is both, home and guest are within the teamNames array.</returns>
    public static bool IsGameOfTeams(Game game, string[] teamNames)
    {
        int count = 0;
        foreach (var teamName in teamNames)
        {
            if (IsGameOfTeam(game, teamName))
            {
                count++;
            }
        }

        return count == 2;
    }

    /// <summary>
    /// Create a array of teams based on the games.
    /// Fill all properties in object Team, e.g. WinCount, LossCount, ...
    /// </summary>
    /// <param name="games"></param>
    /// <returns>Unsorted list of teams.</returns>
    public static Team[] CreateListOfTeams(Game[] games)
    {
        var teams     = new Team[games.Length * 2];
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

            teams[teamIdx].GoalsCount    += game.GoalsHome;
            teams[teamIdx].GotGoalsCount += game.GoalsGuest;
            teams[teamIdx].WinCount      += game.GoalsHome > game.GoalsGuest ? 1 : 0;
            teams[teamIdx].LossCount     += game.GoalsHome < game.GoalsGuest ? 1 : 0;
            teams[teamIdx].TieCount      += game.GoalsHome == game.GoalsGuest ? 1 : 0;
        }

        foreach (var game in games)
        {
            int teamIdx = Tools.IndexOf(teams, teamCount, game.GuestTeam);
            if (teamIdx < 0)
            {
                teams[teamCount]          = new Team();
                teams[teamCount].TeamName = game.GuestTeam;
                teamIdx                   = teamCount;
                teamCount++;
            }

            teams[teamIdx].GotGoalsCount  += game.GoalsHome;
            teams[teamIdx].GoalsCount     += game.GoalsGuest;
            teams[teamIdx].AwayGoalsCount += game.GoalsGuest;
            teams[teamIdx].WinCount       += game.GoalsHome < game.GoalsGuest ? 1 : 0;
            teams[teamIdx].LossCount      += game.GoalsHome > game.GoalsGuest ? 1 : 0;
            teams[teamIdx].TieCount       += game.GoalsHome == game.GoalsGuest ? 1 : 0;
        }

        return Tools.Copy(teams, teamCount);
    }

    /// <summary>
    /// Test, if a team (specified by the name) is ether home or guest.
    /// </summary>
    /// <param name="game"></param>
    /// <param name="teamName"></param>
    /// <returns>true if home or guest</returns>
    private static bool IsGameOfTeam(Game game, string teamName)
    {
        return IsGameOfTeam(game.HomeTeam,     teamName)
               || IsGameOfTeam(game.GuestTeam, teamName);
    }

    /// <summary>
    /// Compare of a teamName.
    /// Ignore case and the name must be part of the teamName (contains).
    /// </summary>
    /// <param name="teamName"></param>
    /// <param name="lookForTeamName"></param>
    /// <returns></returns>
    private static bool IsGameOfTeam(string teamName, string lookForTeamName)
    {
        return teamName.ToUpper().Contains(lookForTeamName.ToUpper());
    }

    /// <summary>
    /// Sort the teams by OFB rules.
    /// </summary>
    /// <param name="games"></param>
    /// <param name="teams"></param>
    /// <returns>Sorted team array.</returns>
    public static Team[] SortByOefb(Team[] teams, Game[] games)
    {
        // 1. sort by (do not use PosIfSamePoints = 0 - because it is 0)
        // 2. for all "groups" of teams with same points
        //   => extract group
        //   => Create Results (with SortBy)
        //   => set the Position (=Property PosIfSamePoints) in teams
        // 3. sort again (using PosIfSamePoints)

        teams = SortByPoints(teams);

        int samePointCount = 0;

        for (int i = 1; i < teams.Length; i++)
        {
            if (teams[i - 1].Points == teams[i].Points)
            {
                samePointCount++;
            }
            else if (samePointCount > 0)
            {
                SetPositionInSubGroup(teams, games, i - samePointCount - 1, samePointCount + 1);
                samePointCount = 0;
            }
        }

        if (samePointCount > 0)
        {
            SetPositionInSubGroup(teams, games, teams.Length - samePointCount - 1, samePointCount + 1);
        }

        return SortByPoints(teams);
    }

    /// <summary>
    /// Set the property "PosIfSamePoints" for the specified "sub-group".
    /// All teams in the sub-group have the same "points".
    /// Teams with same result (in the sub-group) must get the identical PosIsSamePoints.
    /// It is necessary for the order by GoalDiff, ... of the main group.
    /// </summary>
    /// <param name="teams">All teams - must be sorted (by points).</param>
    /// <param name="games">We need them to calculate the result of the sub-group.</param>
    /// <param name="startIdx">Index where the team (with the same points) starts.</param>
    /// <param name="count">Count of teams with same points.</param>
    private static void SetPositionInSubGroup(Team[] teams, Game[] games, int startIdx, int count)
    {
        string[] teamNames = new string[count];
        for (int i = 0; i < count; i++)
        {
            teamNames[i] = teams[i + startIdx].TeamName;
        }

        var gamesOfGroup = FilterGamesByTeam(games, teamNames);
        if (gamesOfGroup.Length > 0)
        {
            var teamsOfGroup = CreateListOfTeams(gamesOfGroup);
            teamsOfGroup = SortByPoints(teamsOfGroup);

            PrintTeams(teamsOfGroup);

            int posIfSamePoints = 1;
            for (int i = 0; i < count; i++)
            {
                teams[Tools.IndexOf(teams, teams.Length, teamsOfGroup[i].TeamName)].PosIfSamePoints = posIfSamePoints;
                if (i < count - 1 && CompareTo(teamsOfGroup[i], teamsOfGroup[i + 1], false) != 0)
                {
                    posIfSamePoints++;
                }
            }
        }
    }

    /// <summary>
    /// Sort the team array.
    ///  1. by point
    ///  2. if points equal by goalDiff
    ///  3. ...
    /// </summary>
    /// <param name="teams"></param>
    /// <returns>Sorted (new) team array</returns>
    public static Team[] SortByPoints(Team[] teams)
    {
        teams = Tools.Copy(teams, teams.Length);

        for (int i = 0; i < teams.Length; i++)
        {
            int min = i;
            for (int j = i + 1; j < teams.Length; j++)
            {
                if (CompareTo(teams[j], teams[min], true) > 0)
                {
                    min = j;
                }
            }

            var tmp = teams[i];
            teams[i]   = teams[min];
            teams[min] = tmp;
        }

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
    /// <param name="team1"></param>
    /// <param name="team2"></param>
    /// <param name="compareName"></param>
    /// <returns>0 if equal, 1 if higher rank, -1 if lower rank</returns>
    public static int CompareTo(Team team1, Team team2, bool compareName)
    {
        if (team1.Points != team2.Points)
        {
            return CompareTo(team1.Points, team2.Points);
        }

        if (team1.PosIfSamePoints != team2.PosIfSamePoints)
        {
            return CompareTo(team2.PosIfSamePoints, team1.PosIfSamePoints); // less is better
        }

        if (team1.GoalDiff != team2.GoalDiff)
        {
            return CompareTo(team1.GoalDiff, team2.GoalDiff);
        }

        if (team1.GoalsCount != team2.GoalsCount)
        {
            return CompareTo(team1.GoalsCount, team2.GoalsCount);
        }

        if (team1.AwayGoalsCount != team2.AwayGoalsCount)
        {
            return CompareTo(team1.AwayGoalsCount, team2.AwayGoalsCount);
        }

        return compareName ? team2.TeamName.CompareTo(team1.TeamName) : 0;
    }

    static int CompareTo(int value1, int value2)
    {
        return value1 > value2 ? 1 : -1;
    }
}