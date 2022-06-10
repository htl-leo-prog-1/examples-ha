/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Fussballmeisterschaft
*--------------------------------------------------------------
*/

namespace FussballMeisterschaft;

public class Team
{
    private string _teamName        { get; set; }
    private int    _winCount        { get; set; }
    private int    _lossCount       { get; set; }
    private int    _tieCount        { get; set; }
    private int    _goalsCount      { get; set; }
    private int    _gotGoalsCount   { get; set; }
    private int    _awayGoalsCount  { get; set; }
    private int    _posIfSamePoints { get; set; }


    public string TeamName
    {
        get { return _teamName; }
        set { _teamName = value; }
    }

    public int WinCount
    {
        get { return _winCount; }
        set { _winCount = value; }
    }

    public int LossCount
    {
        get { return _lossCount; }
        set { _lossCount = value; }
    }

    public int TieCount
    {
        get { return _tieCount; }
        set { _tieCount = value; }
    }

    public int GoalsCount
    {
        get { return _goalsCount; }
        set { _goalsCount = value; }
    }

    public int GotGoalsCount
    {
        get { return _gotGoalsCount; }
        set { _gotGoalsCount = value; }
    }

    public int AwayGoalsCount
    {
        get { return _awayGoalsCount; }
        set { _awayGoalsCount = value; }
    }

    public int PosIfSamePoints
    {
        get { return _posIfSamePoints; }
        set { _posIfSamePoints = value; }
    }

    public int GameCount
    {
        get { return WinCount + LossCount + TieCount; }
    }

    public int Points
    {
        get { return WinCount * 3 + TieCount; }
    }

    public int GoalDiff
    {
        get { return GoalsCount - GotGoalsCount; }
    }

    public string GoalVsGot
    {
        get { return $"{GoalsCount}:{GotGoalsCount}"; }
    }
}