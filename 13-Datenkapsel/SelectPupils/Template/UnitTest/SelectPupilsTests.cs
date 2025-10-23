/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: SelectPupils UnitTests
*--------------------------------------------------------------
*/

namespace UnitTest;

using SelectPupils;
using UnitTest.Tools;
using FluentAssertions;
using Xunit;
using System.Linq;

public class SelectPupilsTests
{
    [Fact]
    public void T01_ReadCsv()
    {
        var pupils = SelectPupils.Program.ReadPupilsFromCsv("Pupils.csv");
        pupils.Should().HaveCount(525);

        pupils.Should().OnlyContain(pupil => pupil.GradeEnglish >= 1 && pupil.GradeEnglish <= 5);
        pupils.Should().OnlyContain(pupil => pupil.GradeGerman >= 1 && pupil.GradeGerman <= 5);
        pupils.Should().OnlyContain(pupil => pupil.GradeMath >= 1 && pupil.GradeMath <= 5);

        pupils.Should().OnlyContain(pupil => !string.IsNullOrEmpty(pupil.FirstName));
        pupils.Should().OnlyContain(pupil => !string.IsNullOrEmpty(pupil.LastName));

        pupils.Should().OnlyHaveUniqueItems(pupil => $"{pupil.LastName}{pupil.FirstName}");
    }

    [Fact]
    public void T02_FilterPupil()
    {
        var pupils = SelectPupils.Program.ReadPupilsFromCsv("Pupils.csv");
        var filtered = SelectPupils.Program.FilterByGrade(pupils);

        filtered.Should().HaveCount(410);

        filtered.Should().OnlyContain(pupil => pupil.GradeEnglish >= 1 && pupil.GradeEnglish <= 4);
        filtered.Should().OnlyContain(pupil => pupil.GradeGerman >= 1 && pupil.GradeGerman <= 4);
        filtered.Should().OnlyContain(pupil => pupil.GradeMath >= 1 && pupil.GradeMath <= 4);
    }

    static double CalculateGradeAverage(Pupil pupil)
    {
        return (pupil.GradeMath * 2 +
                pupil.GradeEnglish +
                pupil.GradeGerman) / 4.0;
    }

    [Fact]
    public void T03_Sort()
    {
        var pupils = SelectPupils.Program.ReadPupilsFromCsv("Pupils.csv");
        var filtered = SelectPupils.Program.FilterByGrade(pupils);
        var sorted = SelectPupils.Program.SortByGrade(filtered);

        filtered.Should().HaveCount(410);

        sorted.Select(pupil => CalculateGradeAverage(pupil)).Should().BeInAscendingOrder();
    }

    [Fact]
    public void T04_Argument()
    {
        SelectPupils.Program.Main(new[] {"PupilsEmpty.csv"});

        var csvImporter = new CsvImport<PupilGrad>();
        var pupils = csvImporter.Read("SortedPupils.csv");

        pupils.Should().HaveCount(0);

        SelectPupils.Program.Main(new string[0]);
        pupils = csvImporter.Read("SortedPupils.csv");

        pupils.Should().HaveCount(410);
    }
}