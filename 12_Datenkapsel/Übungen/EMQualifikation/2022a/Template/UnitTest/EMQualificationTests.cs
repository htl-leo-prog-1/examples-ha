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
        games.Where(g => g.GuestTeam == "Österreich").Should().HaveCount(5);
        games.Where(g => g.HomeTeam == "Österreich").Should().HaveCount(5);

        games.GroupBy(g => g.HomeTeam).Should().HaveCount(6);
        games.GroupBy(g => g.GuestTeam).Should().HaveCount(6);

        games.Should().NotContain(g => g.HomeTeam == g.GuestTeam);
        games.Should().NotContain(g => g.GoalsGuest < 0 || g.GoalsHome < 0);
        games.Sum(g => g.GoalsGuest).Should().Be(38);
        games.Sum(g => g.GoalsHome).Should().Be(47);

        games[1].HomeTeam.Should().Be("Mazedonien");
        games[1].GuestTeam.Should().Be("Lettland");
        games[1].Date.Should().Be("21.03.2019");
        games[1].GoalsHome.Should().Be(3);
        games[1].GoalsGuest.Should().Be(1);
    }

    [Fact]
    public void T02_FilterCountry()
    {
        var games         = Program.ReadGamesFromFile("Games.csv");
        var filteredGames = Program.FilterGamesByTeamName(games, "POLEN");

        filteredGames.Should().HaveCount(10);
        filteredGames.Should().OnlyContain(g => g.GuestTeam == "Polen" || g.HomeTeam == "Polen");
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

    [Fact]
    public void T04_CheckForTeams()
    {
        var game = new Game()
        {
            Date       = "2022-01-01",
            HomeTeam   = "Union Leonding",
            GuestTeam  = "ASKOE Traun",
            GoalsGuest = 1,
            GoalsHome  = 1
        };

        game.IsGameOfGuestTeam("TRaun").Should().BeTrue();
        game.IsGameOfHomeTeam("TRaun").Should().BeFalse();

        game.IsGameOfGuestTeam("LEONDING").Should().BeFalse();
        game.IsGameOfHomeTeam("leonding").Should().BeTrue();

        game.IsGameOfTeam("LEONDING").Should().BeTrue();
        game.IsGameOfTeam("LASK").Should().BeFalse();
    }
}