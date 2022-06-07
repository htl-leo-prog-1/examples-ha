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

        //TODO Implement main Program here
    }

    //TODO implement other method here, e.g. PrintTeam, IsGameOfTeam, ...

    /// <summary>
    /// Read the csv File and return the result as an array
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns>All games stored in the csv file.</returns>
    public static Game[] ReadGamesFromFile(string fileName)
    {
        //TODO implement method
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

    /// <summary>
    /// Calculate the goal diff.
    /// </summary>
    /// <param name="games"></param>
    /// <param name="teamName"></param>
    /// <param name="goals"></param>
    /// <param name="gotGoals"></param>
    public static void CountGoals(Game[] games, string teamName, out int goals, out int gotGoals)
    {
        //TODO implement method
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
        //TODO implement method
    }

    /// <summary>
    /// Calculates the away goals for the specified team.
    /// </summary>
    /// <param name="games"></param>
    /// <param name="teamName"></param>
    /// <returns>Amount of away goals based on the game list.</returns>
    public static int CountAwayGoals(Game[] games, string teamName)
    {
        //TODO implement method
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
        //TODO implement method
    }

    /// <summary>
    /// Create a array of teams based on the games.
    /// </summary>
    /// <param name="games"></param>
    /// <returns>Unsorted list of teams.</returns>
    public static Team[] CreateListOfTeams(Game[] games)
    {
        //TODO implement method
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
        //TODO implement method
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
        //TODO implement method
    }
}