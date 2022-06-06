/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Fussballmeisterschaft UnitTests
*--------------------------------------------------------------
*/

using System;

namespace UnitTest;

using FussballMeisterschaft;

using FluentAssertions;

using Xunit;

using System.Linq;

using FluentAssertions.Extensions;

public class FussballMeisterschaftTests
{
    const         string unionKleinmuenchen = "SPG UNION Kleinmünchen/FC Blau-Weiß Linz";
    const         string mohrenDornbirn     = "FC Mohren Dornbirn Damen";
    private const string wildCats           = "Wildcats 11teamsports Krottendorf";

    [Fact]
    public void T01_ReadCsv()
    {
        var games = FussballMeisterschaft.ReadGamesFromFile("Games.csv");
        games.Should().HaveCount(150);
        games.Where(g => g.GuestTeam == unionKleinmuenchen).Should().HaveCount(11);
        games.Where(g => g.HomeTeam == unionKleinmuenchen).Should().HaveCount(12);

        games.GroupBy(g => g.HomeTeam).Should().HaveCount(13);
        games.GroupBy(g => g.GuestTeam).Should().HaveCount(13);

        games.Should().NotContain(g => g.HomeTeam == g.GuestTeam);
        games.Should().NotContain(g => g.GoalsGuest < 0 || g.GoalsHome < 0);
        games.Sum(g => g.GoalsGuest).Should().Be(296);
        games.Sum(g => g.GoalsHome).Should().Be(393);

        games.Should().OnlyContain(game => game.Date > 1.August(2021) && game.Date < 15.June(2022));

        var group = games.GroupBy(g => g.Round).ToList();
        group.Should().HaveCount(25);
        group.Should().OnlyContain(grp => grp.Count() == 6);
    }

    [Fact]
    public void T02_FilterTeam()
    {
        var games         = FussballMeisterschaft.ReadGamesFromFile("Games.csv");
        var filteredGames = FussballMeisterschaft.FilterGamesByTeam(games, unionKleinmuenchen);

        filteredGames.Should().HaveCount(23);
        filteredGames.Should().OnlyContain(g => g.GuestTeam == unionKleinmuenchen || g.HomeTeam == unionKleinmuenchen);
    }

    [Fact]
    public void T02_FilterTwoTeam()
    {
        var games         = FussballMeisterschaft.ReadGamesFromFile("Games.csv");
        var filteredGames = FussballMeisterschaft.FilterGamesByTeam(games, unionKleinmuenchen, mohrenDornbirn);

        filteredGames.Should().HaveCount(2);
        filteredGames.Should().OnlyContain(g => g.GuestTeam == unionKleinmuenchen || g.HomeTeam == unionKleinmuenchen);
        filteredGames.Should().OnlyContain(g => g.GuestTeam == mohrenDornbirn || g.HomeTeam == mohrenDornbirn);
    }

    [Fact]
    public void T03_CountGoals()
    {
        var games = FussballMeisterschaft.ReadGamesFromFile("Games.csv");
        int goals;
        int gotGoals;

        FussballMeisterschaft.CountGoals(games, unionKleinmuenchen, out goals, out gotGoals);

        goals.Should().Be(89);
        gotGoals.Should().Be(30);
    }

    [Fact]
    public void T04_CalculatePoints()
    {
        var games = FussballMeisterschaft.ReadGamesFromFile("Games.csv");
        FussballMeisterschaft.CalculatePoints(games, unionKleinmuenchen).Should().Be(54);
    }

    [Fact]
    public void T05_CalculateAwayGoals()
    {
        var games = FussballMeisterschaft.ReadGamesFromFile("Games.csv");
        FussballMeisterschaft.CountAwayGoals(games, unionKleinmuenchen).Should().Be(33);
    }

    [Fact]
    public void T06_CreateTeams()
    {
        var games = FussballMeisterschaft.ReadGamesFromFile("Games.csv");
        var teams = FussballMeisterschaft.CreateListOfTeams(games);

        teams.Should().HaveCount(13);
        var ukm = teams.First(team => team.TeamName == unionKleinmuenchen);
        ukm.Should().BeEquivalentTo(new
        {
            TeamName = ukm,
            Win      = 17,
            Loss     = 3,
            Tie      = 3,
            Points   = 54
        }, options =>
            options.ExcludingMissingMembers());
    }

    [Fact]
    public void T07_SortTeams()
    {
        var games = FussballMeisterschaft.ReadGamesFromFile("Games.csv");
        var teams = FussballMeisterschaft.CreateListOfTeams(games);
        teams = FussballMeisterschaft.SortByScore(games, teams);

        teams.Should().HaveCount(13);

        var ukm = teams[0];
        ukm.Should().BeEquivalentTo(new
        {
            TeamName = unionKleinmuenchen,
            Win      = 17,
            Loss     = 3,
            Tie      = 3,
            Points   = 54
        }, options =>
            options.ExcludingMissingMembers());

        var md = teams[2];
        md.Should().BeEquivalentTo(new
        {
            TeamName = mohrenDornbirn,
            Win      = 17,
            Loss     = 3,
            Tie      = 3,
            Points   = 54
        }, options =>
            options.ExcludingMissingMembers());

        var wc = teams[1];
        wc.Should().BeEquivalentTo(new
        {
            TeamName = wildCats,
            Win      = 17,
            Loss     = 3,
            Tie      = 3,
            Points   = 54
        }, options =>
            options.ExcludingMissingMembers());
    }
}