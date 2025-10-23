/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: GradeStatistics
*--------------------------------------------------------------
*/

namespace GradeStatistics;

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("-----------------");
        Console.WriteLine("Grade Statistics");

        int[] gradeCount = ReadGrades();

        PrintGrades(gradeCount);
    }

    static int[] ReadGrades()
    {
        int[] gradeCount = new int[5];

        int grade = ReadGrade();

        while (grade != 0)
        {
            gradeCount[grade - 1]++;
            grade = ReadGrade();
        }

        return gradeCount;
    }

    static int ReadGrade()
    {
        int grade;
        bool isOk;

        do
        {
            Console.Write("Grade: ");
            isOk = int.TryParse(Console.ReadLine(), out grade);
            if (!isOk)
            {
                Console.WriteLine("Wrong input, please try again");
            }

        } while (!isOk);

        if (grade < 1 || grade > 5)
        {
            grade = 0;
        }

        return grade;
    }

    private static void PrintGrades(int[] gradeCount)
    {
        Console.WriteLine("-----------------");
        Console.WriteLine("Grade Counts:");

        for (int i = 0; i < gradeCount.Length; i++)
        {
            Console.WriteLine($"{i + 1}: {gradeCount[i]}");
        }
    }
}