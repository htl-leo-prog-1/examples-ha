/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: GradeSummary - UnitTests
 *--------------------------------------------------------------
 */

using System.Linq;
using GradeSummary;

namespace UnitTest;

using System.IO;
using FluentAssertions;
using Xunit;

public class GradeToolTests
{
    [Fact]
    public void T01_ReadGradeCsv()
    {
        var fileName = "Pupils.csv";
        var grades = GradeTool.ReadCsvFile(fileName);
        grades.Length.Should().Be(526);
        grades.Should().OnlyContain(x => x.Length == 5);
        grades[0].Should().BeEquivalentTo([
            "LastName", "FirstName", "GradeGerman", "GradeEnglish", "GradeMath"
        ]);
        grades[1].Should().BeEquivalentTo([
            "Bennet", "Marie", "4", "2", "2"
        ]);
    }

    [Fact]
    public void T02_AddAverage()
    {
        string[][] grades =
        [
            ["LastName", "FirstName", "GradeGerman", "GradeEnglish", "GradeMath"],
            ["Bennet", "Marie", "4", "2", "2"],
            ["Bosse", "Johannes", "3", "1", "1"],
        ];


        GradeTool.AddAvgColumn(grades);
        grades.Length.Should().Be(3);
        grades.Should().OnlyContain(x => x.Length == 6);
        grades[0].Should().BeEquivalentTo([
            "LastName", "FirstName", "GradeGerman", "GradeEnglish", "GradeMath", "Average"
        ]);
        grades[1].Should().BeEquivalentTo([
            "Bennet", "Marie", "4", "2", "2", "2.67"
        ]);
        grades[2].Should().BeEquivalentTo([
            "Bosse", "Johannes", "3", "1", "1", "1.67"
        ]);
    }

    [Fact]
    public void T03_DoNotAddAverage()
    {
        string[][] grades =
        [
            ["LastName", "FirstName", "GradeGerman", "GradeEnglish", "GradeMath", "Average"],
            ["Bennet", "Marie", "4", "2", "2", "2.67"],
            ["Bosse", "Johannes", "3", "1", "1", "1.67"],
        ];


        GradeTool.AddAvgColumn(grades);
        grades.Length.Should().Be(3);
        grades.Should().OnlyContain(x => x.Length == 6);
        grades[0].Should().BeEquivalentTo([
            "LastName", "FirstName", "GradeGerman", "GradeEnglish", "GradeMath", "Average"
        ]);
        grades[1].Should().BeEquivalentTo([
            "Bennet", "Marie", "4", "2", "2", "2.67"
        ]);
        grades[2].Should().BeEquivalentTo([
            "Bosse", "Johannes", "3", "1", "1", "1.67"
        ]);
    }

    [Fact]
    public void T04_ReplaceCsv()
    {
        var fileName1 = "Pupils.csv";
        var fileName2 = "Pupils2.csv";

        var fileName = "PupilsTest.csv";
        var fileNameBak = "PupilsTest.bak";

        var grades = GradeTool.ReadCsvFile(fileName1);
        var gradesTest = GradeTool.ReadCsvFile(fileName2);

        var content1 = File.ReadAllText(fileName1);
        var content2 = File.ReadAllText(fileName2);

        GradeTool.WriteCsvFile(gradesTest, fileName);
        GradeTool.WriteCsvFile(grades, fileNameBak);

        File.Exists(fileName).Should().BeTrue();
        File.Exists(fileNameBak).Should().BeTrue();

        GradeTool.ReplaceCsvFile(grades,fileName);

        File.Exists(fileName).Should().BeTrue();
        File.Exists(fileNameBak).Should().BeTrue();


        File.ReadAllText(fileName).Should().Be(content1);
        File.ReadAllText(fileNameBak).Should().Be(content2);

    }
}