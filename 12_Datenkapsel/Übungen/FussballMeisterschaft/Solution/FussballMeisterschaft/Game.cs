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
}