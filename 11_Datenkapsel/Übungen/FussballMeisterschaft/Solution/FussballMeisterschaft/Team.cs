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
    public string TeamName { get; set; }
    public int Win { get; set; }
    public int Loss { get; set; }
    public int Tie { get; set; }
    public int Goals { get; set; }
    public int Got { get; set; }

    public int Games => Win+Loss+Tie;
    public int Points => Win*3 + Tie;
    public int GoalDiff => Goals - Got;
    public string GoalVsGot => $"{Goals}:{Got}";
}