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

public class Team
{
    public string TeamName        { get; set; }
    public int    WinCount        { get; set; }
    public int    LossCount       { get; set; }
    public int    TieCount        { get; set; }
    public int    GoalsCount      { get; set; }
    public int    GotGoalsCount   { get; set; }
    public int    AwayGoalsCount  { get; set; }
    public int    PosIfSamePoints { get; set; }

    public int    GameCount => WinCount + LossCount + TieCount;
    public int    Points    => WinCount * 3 + TieCount;
    public int    GoalDiff  => GoalsCount - GotGoalsCount;
    public string GoalVsGot => $"{GoalsCount}:{GotGoalsCount}";
}