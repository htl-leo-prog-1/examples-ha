/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: SkiJumpVoter - Unittests
*--------------------------------------------------------------
*/

namespace UnitTest;

using FluentAssertions;
using Xunit;
using SkiJumpVoter;

public class ProgramTests
{
    [Fact]
    public void T01_ArePointsValid_Simple()
    {
        Program.ArePointsValid(19).Should().BeTrue("Ganze Zahlen sind zulässig");
        Program.ArePointsValid(19.5).Should().BeTrue("Halbe Punkte sind zulässig");
    }

    [Fact]
    public void T02_ArePointsValid_Range()
    {
        Program.ArePointsValid(20.01).Should().BeFalse("Zu hoch");
        Program.ArePointsValid(-0.1).Should().BeFalse("Zu niedrig");
    }

    [Fact]
    public void T03_ArePointsValid_Value()
    {
        Program.ArePointsValid(19.1).Should().BeFalse("Nur ganze und halbe erlaubt");
        Program.ArePointsValid(1.6).Should().BeFalse("Nur ganze und halbe erlaubt");
    }

    [Fact]
    public void T11_CalculateLengthPointsTest_Simple()
    {
        Program.CalculateLengthPoints(125).Should().Be(69, "125 Meter ergibt 69 Weitenpunkte");
    }

    [Fact]
    public void T12_CalculateLengthPointsTest_Minimum()
    {
        Program.CalculateLengthPoints(50).Should().Be(-66, "50 Meter ergibt -66 Weitenpunkte");
    }

    [Fact]
    public void T21_CalculateStylePointsSumTest_Simple()
    {
        double[] points = {17.5, 18.5, 19, 18.5, 19};
        Program.CalculateStylePointsSum(points).Should().BeApproximately(56, 0.001, "Siehe Angabe");
    }

    [Fact]
    public void T22_CalculateStylePointsSumTest_Same()
    {
        double[] points = {17.5, 17.5, 17.5, 17.5, 17.5};
        Program.CalculateStylePointsSum(points).Should().BeApproximately(17.5 * 3, 0.001, "Siehe Angabe");
    }

    [Fact]
    public void T23_CalculateStylePointsSumTest_Mixed()
    {
        double[] points = {17.5, 17.5, 17.5, 19.5, 19.5};
        Program.CalculateStylePointsSum(points).Should().BeApproximately(17.5 * 2 + 19.5, 0.001, "Siehe Angabe");
    }
}