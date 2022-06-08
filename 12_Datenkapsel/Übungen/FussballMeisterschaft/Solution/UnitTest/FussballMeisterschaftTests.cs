/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Fussballmeisterschaft UnitTests
*--------------------------------------------------------------
*/

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
    public void T02_FilterTwoTeam()
    {
        var games         = FussballMeisterschaft.ReadGamesFromFile("Games.csv");
        var filteredGames = FussballMeisterschaft.FilterGamesByTeam(games, new string[] { unionKleinmuenchen, mohrenDornbirn });

        filteredGames.Should().HaveCount(2);
        filteredGames.Should().OnlyContain(g => g.GuestTeam == unionKleinmuenchen || g.HomeTeam == unionKleinmuenchen);
        filteredGames.Should().OnlyContain(g => g.GuestTeam == mohrenDornbirn || g.HomeTeam == mohrenDornbirn);
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

    private Team[] ReadAndSortTeams(string fileName)
    {
        var games = FussballMeisterschaft.ReadGamesFromFile(fileName);
        var teams = FussballMeisterschaft.CreateListOfTeams(games);
        return FussballMeisterschaft.SortByOefb(teams, games);
    }

    [Fact]
    public void T07_SortTeams()
    {
        var teams = ReadAndSortTeams("Games.csv");

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

        var md = teams[1];
        md.Should().BeEquivalentTo(new
        {
            TeamName = mohrenDornbirn,
            Win      = 17,
            Loss     = 3,
            Tie      = 3,
            Points   = 54
        }, options =>
            options.ExcludingMissingMembers());

        var wc = teams[2];
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

    [Fact]
    public void T08_SortTeamsEmpty()
    {
        var teams = ReadAndSortTeams("GamesEmpty.csv");

        teams.Should().HaveCount(0);
    }

    [Fact]
    public void T08_SortTeamsAllEqual()
    {
        var teams = ReadAndSortTeams("GamesAllEqual.csv");

        teams.Should().HaveCount(12);

        teams.Should().OnlyContain(team => team.Points == 1);
        teams.Should().OnlyContain(team => team.PosIfSamePoints == 1);

        teams.Select(team => team.TeamName).Should().BeInAscendingOrder();
    }

    [Fact]
    public void T08_SortTeamsGroupEqualName()
    {
        var teams = ReadAndSortTeams("GamesAllEqual.csv");

        teams.Should().HaveCount(12);

        teams.Should().OnlyContain(team => team.Points == 1);
        teams.Should().OnlyContain(team => team.PosIfSamePoints == 1);

        teams.Select(team => team.TeamName).Should().BeInAscendingOrder();
    }

    [Fact]
    public void T08_SortTeamsGroupEqualGoalDiff()
    {
        var teams = ReadAndSortTeams("GamesByTotalGoalDiff.csv");

        FussballMeisterschaft.PrintTeams(teams);

        teams.Should().HaveCount(10);

        teams.Take(6).Should().OnlyContain(team => team.Points == 4);
        teams.Skip(6).Should().OnlyContain(team => team.Points == 0);
        teams.Skip(6).Select(team => team.GoalDiff).Should().BeInDescendingOrder();
    }
}