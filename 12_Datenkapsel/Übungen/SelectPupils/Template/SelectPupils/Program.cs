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
        Console.WriteLine("Select Pupils");
        Console.WriteLine("=====================");

        //string fileName = "Pupils.csv";

        //TODO Implement main code here
    }

    /// <summary>
    /// Read the pupils from the csv file.
    /// </summary>
    /// <param name="fileName">csv filename.</param>
    /// <returns>The list (array) of pupils.</returns>
    public static Pupil[] ReadPupilsFromCsv(string fileName)
    {
        //TODO Implement read csv file here 
        throw new NotImplementedException();
    }

    // TODO Implement: Pupil[] FilterByGrade(Pupil[] pupils)
    // TODO Implement: Pupil[] SortByGrade(Pupil[] pupils)
    // TODO Implement: void WritePupilsToCsv(Pupil[] pupils, string fileName)
}


/*
  you can use the following code for sorting 
  // TODO Implement (and use): double CalculateGradeAverage(Pupil pupil)
  // the methode calculates the grade average of a pupil.

for (int i = 0; i<pupils.Length; i++)
{
    int min = i;
    double gradeMin = CalculateGradeAverage(pupils[min]);

    for (int j = i + 1; j<pupils.Length; j++)
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
*/
