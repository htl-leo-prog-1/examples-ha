/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: ChessGame
*--------------------------------------------------------------
*/

namespace Chess;

public class ChessPiece
{
    private int _row;
    private int _col;
    private int _pieceType;
    private bool _isBlack;

    //1 König - King
    //2 Dame - Queen
    //3 Turm - Rook
    //4 Läufer - Bishop
    //5 Springer - Knight
    //6 Bauer - Pawn

    public const int King   = 1;
    public const int Queen  = 2;
    public const int Rook   = 3;
    public const int Bishop = 4;
    public const int Knight = 5;
    public const int Pawn   = 6;

    public int Row  { get { return _row;}        set { _row       = value; } }
    public int Col  { get { return _col; }       set { _col       = value; } }
    public int Type { get { return _pieceType; } set { _pieceType = value; } }
    public bool IsBlack { get { return _isBlack; } set { _isBlack = value; } }
}