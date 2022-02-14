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
            int[] grades = ReadGrades();

            double average;
            bool hasFour;
            bool isNegative;

            Calculate(grades, out average, out hasFour, out isNegative);

            ReportResults(average, hasFour, isNegative);
        }

        public static int[] ReadGrades()
        {
            var grades = new int[5];

            Console.WriteLine("Berechnung des Mittelwertes über fünf Noten");
            Console.WriteLine("Geben Sie bitte die 5 Noten ein");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Note {i + 1}: ");
                grades[i] = int.Parse(Console.ReadLine());
            }

            return grades;
        }

        public static void Calculate(int[] grades,
            out double average,
            out bool hasFour,
            out bool isNegative)
        {
            int sum = 0;
            hasFour = false;
            isNegative = false;

            for (int i = 0; i < 5; i++)
            {
                sum += grades[i];
                if (grades[i] == 4)
                {
                    hasFour = true;
                }

                if (grades[i] == 5)
                {
                    isNegative = true;
                }
            }

            average = sum / 5.0;
        }

        private static void ReportResults(double average, bool hasFour, bool isNegative)
        {
            if (isNegative)
            {
                Console.WriteLine("Leider nicht bestanden!");
            }
            else
            {
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