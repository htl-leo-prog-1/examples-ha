/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: EMQualification UnitTests
*--------------------------------------------------------------
*/

namespace UnitTest;

using System.Linq;
using FluentAssertions;
using EMQualification;
using Xunit;

public class EMQualificationTests
{
    [Fact]
    public void T01_ReadCsv()
    {
        var games = Program.ReadGamesFromFile("Games.csv");
        games.Should().HaveCount(30);
        games.Where(g => g.GetGuestTeam() == "Österreich").Should().HaveCount(5);
        games.Where(g => g.GetHomeTeam() == "Österreich").Should().HaveCount(5);

        games.GroupBy(g => g.GetHomeTeam()).Should().HaveCount(6);
        games.GroupBy(g => g.GetGuestTeam()).Should().HaveCount(6);

        games.Should().NotContain(g => g.GetHomeTeam() == g.GetGuestTeam());
        games.Should().NotContain(g => g.GetGoalsGuest() < 0 || g.GetGoalsHome() < 0);
        games.Sum(g => g.GetGoalsGuest()).Should().Be(38);
        games.Sum(g => g.GetGoalsHome()).Should().Be(47);

        games[1].GetHomeTeam().Should().Be("Mazedonien");
        games[1].GetGuestTeam().Should().Be("Lettland");
        games[1].GetDate().Should().Be("21.03.2019");
        games[1].GetGoalsHome().Should().Be(3);
        games[1].GetGoalsGuest().Should().Be(1);
    }

    [Fact]
    public void T02_FilterCountry()
    {
        var games = Program.ReadGamesFromFile("Games.csv");
        var filteredGames = Program.FilterGamesByCountryName(games, "POLEN");

        filteredGames.Should().HaveCount(10);
        filteredGames.Should().OnlyContain(g => g.GetGuestTeam() == "Polen" || g.GetHomeTeam() == "Polen");
    }

    [Fact]
    public void T03_CountGoals()
    {
        var games = Program.ReadGamesFromFile("Games.csv");
        int goals;
        int gotGoals;
        Program.CountGoals(games, "POLEN", out goals, out gotGoals);

        goals.Should().Be(18);
        gotGoals.Should().Be(6);
    }
}