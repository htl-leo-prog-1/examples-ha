/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Fussballmeisterschaft
*--------------------------------------------------------------
*/

namespace FussballMeisterschaft;

using System;
using System.Collections.Generic;

public class Game
{
    public int      Round              { get; set; }
    public DateTime Date               { get; set; }
    public string   HomeTeam           { get; set; }
    public string   GuestTeam          { get; set; }
    public int      GoalsHome          { get; set; }
    public int      GoalsGuest         { get; set; }
    public int      HalfTimeGoalsHome  { get; set; }
    public int      HalfTimeGoalsGuest { get; set; }

    /// <summary>
    /// The home and the guest team of the game is within the valid teamNames. 
    /// </summary>
    /// <param name="teamNames"></param>
    /// <returns>true is both, home and guest are within the teamNames array.</returns>
    public bool IsGameOfTeams(IEnumerable<string> teamNames)
    {
        int count = 0;
        foreach (var teamName in teamNames)
        {
            if (IsGameOfTeam(teamName))
            {
                count++;
            }
        }

        return count == 2;
    }

    /// <summary>
    /// Test, if a team (specified by the name) is ether home or guest.
    /// </summary>
    /// <param name="teamName"></param>
    /// <returns>true if home or guest</returns>
    public bool IsGameOfTeam(string teamName)
    {
        return IsGameOfTeam(HomeTeam,     teamName)
               || IsGameOfTeam(GuestTeam, teamName);
    }

    /// <summary>
    /// Compare of a teamName.
    /// Ignore case and the name must be part of the teamName (contains).
    /// </summary>
    /// <param name="teamName"></param>
    /// <param name="lookForTeamName"></param>
    /// <returns></returns>
    public static bool IsGameOfTeam(string teamName, string lookForTeamName)
    {
        return teamName.ToUpper().Contains(lookForTeamName.ToUpper());
    }
}