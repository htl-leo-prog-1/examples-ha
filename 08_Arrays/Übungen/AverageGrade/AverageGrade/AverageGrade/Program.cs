using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageGrade
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            double average;
            int[] grades = new int[5];
            bool hasFour = false; // hat der Schüler einen 4er
            bool isNegative = false; // hat der Schüler einen 5er

            // Eingabe
            Console.WriteLine("Berechnung des Mittelwertes über fünf Noten");
            Console.WriteLine("Geben Sie bitte die 5 Noten ein");
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Note {0}: ", i + 1);
                grades[i] = int.Parse(Console.ReadLine());
            }
            // Berechnung
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
            // Ausgabe
            if (isNegative)
            {
                Console.WriteLine("Leider nicht bestanden!");
            }
            else  // auf jeden Fall bestanden
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
            Console.WriteLine("Durchschnittsnote: {0,5:f2}", average);
            Console.WriteLine();
            Console.WriteLine("Beenden, bitte Eingabetaste drücken ...");
            Console.ReadLine();
        }
    }
}
