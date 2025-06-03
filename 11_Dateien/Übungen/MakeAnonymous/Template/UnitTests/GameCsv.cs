/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Fussballmeisterschaft
*--------------------------------------------------------------
*/

namespace UnitTest;

using System;

using UnitTest.Tools.CsvImport;

public class GameCsv
{
    public int   ID     { get; set; }
    public int Round { get; set; }
    [CsvImportFormat(Format = "d.M.yyyy H:m")]
    public DateTime Date          { get; set; }
    public string   HomeTeam      { get; set; } = string.Empty;
    public string   GuestTeam     { get; set; } = string.Empty;
    public string   Score         { get; set; } = string.Empty;
    public string   ScoreHalfTime { get; set; } = string.Empty;
}