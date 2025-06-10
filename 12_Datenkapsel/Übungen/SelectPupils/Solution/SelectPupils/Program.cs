/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: SelectPupils
*--------------------------------------------------------------
*/

using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace SelectPupils;

public class Program
{
    /// <summary>
    /// Main entry point of program.
    /// </summary>
    /// <param name="args">Command-line-arguments</param>
    public static void Main(string[] args)
    {
        Console.WriteLine("SelectPupils");
        Console.WriteLine("=====================");

        string fileName = "Pupils.csv";

        if (args.Length >= 1)
        {
            fileName = args[0];
        }

        Pupil[] pupils = ReadPupilsFromCsv(fileName);
        Pupil[] pupilsGrade = FilterByGrade(pupils);
        Pupil[] pupilsSorted = SortByGrade(pupilsGrade);

        PrintPupils(pupilsSorted);
        WritePupilsToCsv(pupilsSorted, "SortedPupils.csv");
    }

    /// <summary>
    /// Read the pupils from the csv file.
    /// </summary>
    /// <param name="fileName">csv filename.</param>
    /// <returns>The list (array) of pupils.</returns>
    public static Pupil[] ReadPupilsFromCsv(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName, Encoding.Default);
        Pupil[] pupils = new Pupil[lines.Length - 1]; // ignore headline

        for (int i = 1; i < lines.Length; i++)
        {
            pupils[i - 1] = ReadPupilFromLine(lines[i]); // i-1 because of headline
        }

        return pupils;
    }

    private static Pupil ReadPupilFromLine(string line)
    {
        Pupil pupil = new Pupil();
        string[] elements = line.Split(';');

        pupil.LastName = elements[0];
        pupil.FirstName = elements[1];
        pupil.GradeGerman = int.Parse(elements[2]);
        pupil.GradeEnglish = int.Parse(elements[3]);
        pupil.GradeMath = int.Parse(elements[4]);

        return pupil;
    }

    /// <summary>
    /// Print all pupils.
    /// The list is printed in order of the array.
    /// </summary>
    /// <param name="pupils"></param>
    static void PrintPupils(Pupil[] pupils)
    {
        Console.WriteLine("LastName             FirstName            D E M Grade");

        foreach (Pupil pupil in pupils)
        {
            Console.WriteLine(
                $"{pupil.FirstName,-20} {pupil.LastName,-20} {pupil.GradeGerman} {pupil.GradeEnglish} {pupil.GradeMath} {CalculateGradeAverage(pupil),5}");
        }
    }

    /// <summary>
    /// Calculate the grade average value.
    /// We calculate (Math*2 + German + English ) / 4.0
    /// </summary>
    /// <param name="pupil"></param>
    /// <returns></returns>
    static double CalculateGradeAverage(Pupil pupil)
    {
        return (pupil.GradeMath * 2 +
                pupil.GradeEnglish +
                pupil.GradeGerman) / 4.0;
    }

    /// <summary>
    /// Filter the array by grade.
    /// A pupil with a grade of 5 (in German, English or Math) will be removed. 
    /// </summary>
    /// <param name="pupils"></param>
    /// <returns>A new array with the valid pupils.</returns>
    public static Pupil[] FilterByGrade(Pupil[] pupils)
    {
        int count = 0;
        Pupil[] filteredPupils = new Pupil[pupils.Length];

        foreach (Pupil pupil in pupils)
        {
            if (IsGradeOk(pupil))
            {
                filteredPupils[count++] = pupil;
            }
        }

        return Tools.Tools.Copy(filteredPupils, count);
    }

    static bool IsGradeOk(Pupil pupil)
    {
        return pupil.GradeEnglish < 5 &&
               pupil.GradeGerman < 5 &&
               pupil.GradeMath < 5;
    }

    /// <summary>
    /// Sort the pupils by GradeAverage.
    /// </summary>
    /// <param name="pupils">The pupils to be sorted</param>
    /// <returns>A new sorted array.</returns> 
    public static Pupil[] SortByGrade(Pupil[] pupils)
    {
        pupils = Tools.Tools.Copy(pupils, pupils.Length);

        for (int i = 0; i < pupils.Length; i++)
        {
            int min = i;
            double gradeMin = CalculateGradeAverage(pupils[min]);

            for (int j = i + 1; j < pupils.Length; j++)
            {
                double grade = CalculateGradeAverage(pupils[j]);

                if (gradeMin > grade)
                {
                    min = j;
                    gradeMin = grade;
                }
            }

            Pupil tmp = pupils[i];
            pupils[i] = pupils[min];
            pupils[min] = tmp;
        }

        return pupils;
    }

    /// <summary>
    /// Write all pupils to a csv file.
    /// The file is overwritten if exists.
    /// </summary>
    /// <param name="pupils"></param>
    /// <param name="fileName"></param>
    public static void WritePupilsToCsv(Pupil[] pupils, string fileName)
    {
        string[] lines = new string[pupils.Length + 1];
        lines[0] = "LastName;FirstName;GradeGerman;GradeEnglish;GradeMath;GradeAverage";

        for (int i = 0; i < pupils.Length; i++)
        {
            lines[i + 1] = PupilsToCsvLine(pupils[i]);
        }

        File.WriteAllLines(fileName, lines, Encoding.Default);
    }

    static string PupilsToCsvLine(Pupil pupil)
    {
        return
            $"{pupil.LastName};{pupil.FirstName};{pupil.GradeGerman};{pupil.GradeEnglish};{pupil.GradeMath};{CalculateGradeAverage(pupil).ToString(CultureInfo.InvariantCulture)}";
    }
}