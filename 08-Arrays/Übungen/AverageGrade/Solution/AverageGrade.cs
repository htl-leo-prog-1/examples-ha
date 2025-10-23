/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: AverageGrade
*--------------------------------------------------------------
*/

namespace AverageGrade
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var grades = ReadGrades();
            ReportResults(grades);
        }

        public static int[] ReadGrades()
        {
            var grades = new int[5];

            Console.WriteLine("Berechnung des Mittelwertes über fünf Noten");
            Console.WriteLine("Geben Sie bitte die 5 Noten ein");
            
            for (int i = 0; i < 5; i++)
            {
                grades[i] = ReadGrade($"Note {i + 1}: ");
            }

            return grades;
        }

        public static int ReadGrade(string message)
        {
            int grade;
            bool parseOk;
            do
            {
                Console.Write(message);
                parseOk = int.TryParse(Console.ReadLine(), out grade);

            } while (!parseOk || grade < 1 || grade > 5);

            return grade;

        }

        public static bool Contains(int[] grades, int grade)
        {
            foreach (var g in grades)
            {
                if (g == grade)
                {
                    return true;
                }
            }

            return false;
        }

        public static double Average(int[] grades)
        {
            int sum = 0;
            foreach (var grade in grades)
            {
                sum += grade;
            }

            return sum / 5.0;
        }

        private static void ReportResults(int[] grades)
        {
            double average = Average(grades);

            if (Contains(grades, 5))
            {
                Console.WriteLine("Leider nicht bestanden!");
            }
            else
            {
                bool hasFour = Contains(grades, 4);
                if (!hasFour && average <= 1.5)
                {
                    Console.WriteLine("Super, mit Auszeichnung bestanden!");
                }
                else
                {
                    if (!hasFour && average <= 2.0)
                    {
                        Console.WriteLine("Bravo, mit gutem Erfolg bestanden!");
                    }
                    else
                    {
                        Console.WriteLine("Bestanden!");
                    }
                }
            }

            Console.WriteLine($"Durchschnittsnote: {average,5:f2}");
        }
    }
}