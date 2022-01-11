using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesStatistic
{
    class Program
    {
        static void Main(string[] args)
        {
            int countPupils;
            int[] grades;
            string input;
            int grade;
            int sum = 0;
            double average;
            Random random = new Random();
            int[] gradeCounts = new int[5];
            Console.WriteLine("GradeStatistics");
            Console.WriteLine("===============");
            Console.Write("Anzahl der Schüler [int]: ");
            input = Console.ReadLine();
            countPupils = Convert.ToInt32(input);
            grades = new int[countPupils];
            for (int i = 0; i < grades.Length; i++)
            {
                grades[i] = random.Next(1, 6);
            }
            for (int i = 0; i < grades.Length; i++)
            {
                grade = grades[i];
                gradeCounts[grade - 1]++;
                sum += grade;
            }
            average = ((double) sum)/grades.Length;
            Console.WriteLine("Schülerübersicht");
            for (int i = 0; i < grades.Length; i++)
            {
                Console.Write("{0,2} ",i+1);
            }
            Console.WriteLine();
            for (int i = 0; i < grades.Length; i++)
            {
                Console.Write("{0,2} ",grades[i]);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Note Anzahl");
            for (int i = 0; i < gradeCounts.Length; i++)
            {
                Console.WriteLine(" {0}    {1,2}",i+1,gradeCounts[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Die Durchschnittsnote beträgt: {0:f2}",average);
            Console.ReadLine();
        }
    }
}
