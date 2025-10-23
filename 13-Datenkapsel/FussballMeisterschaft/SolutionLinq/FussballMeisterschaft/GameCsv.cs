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

public class GameCsv
{
    public int      Round         { get; set; }
    public DateTime Date          { get; set; }
    public string   HomeTeam      { get; set; } = string.Empty;
    public string   GuestTeam     { get; set; } = string.Empty;
    public string   Score         { get; set; } = string.Empty;
    public string   ScoreHalfTime { get; set; } = string.Empty;
}