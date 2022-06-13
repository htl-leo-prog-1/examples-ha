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
    private int      _round;
    private DateTime _date;
    private string   _homeTeam;
    private string   _guestTeam;
    private int      _goalsHome;
    private int      _goalsGuest;
    private int      _halfTimeGoalsHome;
    private int      _halfTimeGoalsGuest;

    public int Round
    {
        get { return _round; }
        set { _round = value; }
    }

    public DateTime Date
    {
        get { return _date; }
        set { _date = value; }
    }

    public string HomeTeam
    {
        get { return _homeTeam; }
        set { _homeTeam = value; }
    }

    public string GuestTeam
    {
        get { return _guestTeam; }
        set { _guestTeam = value; }
    }

    public int GoalsHome
    {
        get { return _goalsHome; }
        set { _goalsHome = value; }
    }

    public int GoalsGuest
    {
        get { return _goalsGuest; }
        set { _goalsGuest = value; }
    }

    public int HalfTimeGoalsHome
    {
        get { return _halfTimeGoalsHome; }
        set { _halfTimeGoalsHome = value; }
    }

    public int HalfTimeGoalsGuest
    {
        get { return _halfTimeGoalsGuest; }
        set { _halfTimeGoalsGuest = value; }
    }
}