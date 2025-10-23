/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: BattleShipGame
*--------------------------------------------------------------
*/

namespace BattleShip;

public class Ship
{
    private int _row;
    private int _col;
    private int _shipSize;
    private bool _isVertical;

    public int  Row        { get { return _row;}         set { _row        = value; } }
    public int  Col        { get { return _col; }        set { _col        = value; } }
    public int  ShipSize   { get { return _shipSize; }   set { _shipSize   = value; } }
    public bool IsVertical { get { return _isVertical; } set { _isVertical = value; } }
}