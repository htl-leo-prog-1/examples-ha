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

        // ReadGamesFromFile(fileName);
        // CreateListOfTeams(allGames);
        // SortByOefb(teams, allGames);
        // PrintTeams(teams);
    }

    //TODO implement other method here, e.g. PrintTeam, IsGameOfTeam, ...

    /// <summary>
    /// Read the Csv File and return the result as an array.
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns>All games stored in the Csv file.</returns>
    public static Game[] ReadGamesFromFile(string fileName)
    {
        //TODO implement method
    }

    /// <summary>
    /// Print all teams to the console (as a list).
    /// </summary>
    /// <param name="teams">All teams to be printed.</param>
    public static void PrintTeams(Team[] teams)
    {
        //TODO implement method
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
        //TODO implement method
    }

    /// <summary>
    /// Create a array of teams based on the games.
    /// Fill all properties in object Team, e.g. WinCount, LossCount, ...
    /// </summary>
    /// <param name="games"></param>
    /// <returns>Unsorted list of teams.</returns>
    public static Team[] CreateListOfTeams(Game[] games)
    {
        //TODO implement method
    }

    /// <summary>
    /// Sort the teams by OFB rules.
    /// </summary>
    /// <param name="games"></param>
    /// <param name="teams"></param>
    /// <returns>Sorted team array.</returns>
    public static Team[] SortByOefb(Team[] teams, Game[] games)
    {
        // 1. sort by (do not use PosIfSamePoints = 0)
        // 2. for all "groups" of teams with same points
        //   => extract group
        //   => Create Results (with SortBy)
        //   => set the Position in teams

        //TODO implement method
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
        //TODO implement method
        // Use "CompareTo" to compare team rank
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
    /// <returns>0 if equal, 1 if higher rank, -1 if lower rank</returns>
    public static int CompareTo(Team team1, Team team2, bool compareName)
    {
        //TODO implement method

        // Points
        // PosIfSamePoints
        // GoalDiff
        // GoalsCount
        // AwayGoalsCount
        // TeamName if parameter "compareName" is set;
    }
}