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
using System.Linq;

public class Game
{
    public int      Round              { get; set; }
    public DateTime Date               { get; set; }
    public string   HomeTeam           { get; set; } = string.Empty;
    public string   GuestTeam          { get; set; } = string.Empty;
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
        var teamNameList = teamNames.ToList();
        return teamNameList.Contains(HomeTeam) && teamNameList.Contains(GuestTeam);
    }
}