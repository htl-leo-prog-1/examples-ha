/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: MakeAnonymous - UnitTests
*--------------------------------------------------------------
*/

namespace UnitTest;

using System.IO;
using System.Linq;

using FluentAssertions;

using UnitTest.Tools.CsvImport;

using Xunit;

using MakeAnonymous;
using System;

public class FussballmeisterschaftTests
{
    [Fact]
    public void T01_CheckArg_WrongCount()
    {
        Program.Main(new string[0]).Should().Be(1);
        Program.Main(new string[1]).Should().Be(1);
        Program.Main(new string[3]).Should().Be(1);
    }

    [Fact]
    public void T02_CheckArg_NoFile()
    {
        Program.Main(new string[] { "NoCSVFile" }).Should().Be(1);
        Program.Main(new string[] { "NoCSVFile.txt" }).Should().Be(1);
    }

    [Fact]
    public void T03_MakeAnonymous()
    {
        var fileName     = "Games.csv";
        var fullPathName = Path.GetFullPath(fileName);
        var pathName     = $"{Path.GetDirectoryName(fullPathName)}\\";
        var bakPathName  = $"{pathName}{Path.GetFileNameWithoutExtension(fullPathName)}.bak";

        var fileInfoOrig = new FileInfo(fileName).LastWriteTime;

        var games = new CsvImport<GameCsv>().Read(fileName);
        games.Should().HaveCountGreaterThan(1);

        Program.Main(new string[] { fileName }).Should().Be(0);

        var fileInfoBak = new FileInfo(bakPathName).LastWriteTime;

        fileInfoOrig.Should().Be(fileInfoBak, "You have to rename the file to bak.");

        new FileInfo(fileName).LastWriteTime.Should().NotBe(fileInfoOrig);

        var teams = games
            .SelectMany(g => new string[] { g.HomeTeam, g.GuestTeam })
            .Distinct()
            .ToList();

        var gamesAnonymous = new CsvImport<GameCsv>().Read(fileName);

        gamesAnonymous.Should().HaveCount(games.Count);

        var mergedGames = games.Join(gamesAnonymous, p => p.ID, p => p.ID, (orig, updated) => (orig, updated));

        foreach (var mergedGame in mergedGames)
        {
            mergedGame.orig.Round.Should().Be(mergedGame.updated.Round);
            mergedGame.orig.Date.Should().Be(mergedGame.updated.Date);
            mergedGame.orig.Score.Should().Be(mergedGame.updated.Score);
            mergedGame.orig.ScoreHalfTime.Should().Be(mergedGame.updated.ScoreHalfTime);

            teams.Should().Contain(mergedGame.orig.HomeTeam);
            teams.Should().Contain(mergedGame.orig.GuestTeam);

            teams.Should().NotContain(mergedGame.updated.HomeTeam);
            teams.Should().NotContain(mergedGame.updated.GuestTeam);
        }

        var nameMapping = mergedGames
            .SelectMany(g => new[] { (g.orig.HomeTeam, g.updated.HomeTeam), (g.orig.GuestTeam, g.updated.GuestTeam) })
            .Distinct()
            .ToList();

        nameMapping.Should().HaveCount(teams.Count);
    }
}