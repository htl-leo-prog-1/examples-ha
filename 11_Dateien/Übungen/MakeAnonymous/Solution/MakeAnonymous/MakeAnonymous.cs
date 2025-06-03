/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: MakeAnonymous
 *--------------------------------------------------------------
 */

namespace MakeAnonymous;

using System.IO;
using System.Text;

public class MakeAnonymous
{
    private const int HomeTeamIdx = 3;
    private const int GuestTeamIdx = 4;

    /// <summary>
    /// Reads a csv file.
    /// </summary>
    /// <returns>The content of the csv file in a two-dimensional array (without header).</returns>
    /// <param name="filePath">File path.</param>
    public static string[][] ReadCsvFile(string filename)
    {
        string[]   lines = File.ReadAllLines(filename);
        string[][] games = new string[lines.Length - 1][];

        for (int i = 1; i < lines.Length; i++)
        {
            games[i - 1] = lines[i].Split(';');
        }

        return games;
    }

    /// <summary>
    /// Make the games anonymous.
    /// Replace all teams-names with a new "anonymous" name, e.g. "Team 1".
    /// Report the mapping (as string[]).
    /// </summary>
    /// <param name="games"></param>
    /// <returns>the converting table</returns>
    public static string[] MakeTeamsAnonymous(string[][] games)
    {
        string[] teams     = new string[games.Length * 2];
        int      teamCount = 0;

        foreach (string[] game in games)
        {
            int teamIdx = Tools.IndexOf(teams, teamCount, game[HomeTeamIdx]);
            if (teamIdx == -1)
            {
                teamIdx            = teamCount;
                teams[teamCount++] = game[HomeTeamIdx];
            }

            game[HomeTeamIdx] = $"Team {teamIdx+1}";

            teamIdx = Tools.IndexOf(teams, teamCount, game[GuestTeamIdx]);
            if (teamIdx == -1)
            {
                teamIdx            = teamCount;
                teams[teamCount++] = game[GuestTeamIdx];
            }

            game[GuestTeamIdx] = $"Team {teamIdx + 1}";
        }

        return Tools.Copy(teams, teamCount);
    }

    /// <summary>
    /// Writes the file content into a csv file.
    /// </summary>
    /// <param name="games">File content as two-dimensional area.</param>
    /// <param name="filePath">File path.</param>
    public static void WriteCsvFile(string[][] games, string filePath)
    {
        string[] lines = new string[games.Length + 1];

        lines[0] = "ID;Round;Date;HomeTeam;GuestTeam;Score;ScoreHalfTime";

        for (int i = 0; i < games.Length; i++)
        {
            lines[i+1] = string.Join(';', games[i]);
        }

        File.WriteAllLines(filePath, lines, Encoding.Default);
    }

    /// <summary>
    /// Replace an existing file.
    /// A bak file is created. 
    /// </summary>
    /// <param name="games"></param>
    /// <param name="filePath"></param>
    public static void ReplaceCsvFile(string[][] games, string filePath)
    {
        var fullPathName = Path.GetFullPath(filePath);
        var pathName     = $"{Path.GetDirectoryName(fullPathName)}\\";
        var bakPathName  = $"{pathName}{Path.GetFileNameWithoutExtension(fullPathName)}.bak";
        var tmpPathName  = $"{pathName}{Path.GetFileNameWithoutExtension(fullPathName)}.$$$";

        WriteCsvFile(games, tmpPathName);

        if (File.Exists(bakPathName))
        {
            File.Delete(bakPathName);
        }

        File.Move(fullPathName, bakPathName);
        File.Move(tmpPathName,  fullPathName);
    }
}