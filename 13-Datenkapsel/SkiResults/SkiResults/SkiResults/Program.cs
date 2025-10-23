using System;
using System.IO;
using System.Text;

namespace SkiResults
{

    public struct Result
    {
        public string Name;
        public double TimeRun1;
        public double TimeRun2;
        public double TimeTotal;
        public int Rank;
    }
    public class Program
    {
        const string FILE_DG1 = "results_run1.csv";
        const string FILE_DG2 = "results_run2.csv";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Result[] result = ReadRun1();


        }

        private static Result[] ReadRun1()
        {
            string[] lines = File.ReadAllLines(FILE_DG1, Encoding.Default);
            Result[] results = new Result[lines.Length - 1];
            for (int i = 1; i < lines.Length; i++)
            {
                string[] columns = lines[i].Split(";");
                results[i - 1].Name = columns[1];               
                results[i - 1].TimeRun1 = ParseTime(columns[2]);
            }
            return results;

        }

        public static double ParseTime(string timeString)
        {
            string[] timeParts = timeString.Split(':', '.');
            double time = 0.0;
            if (timeParts.Length == 3)
            {
                time += Convert.ToInt32(timeParts[0]) * 60;
                time += Convert.ToInt32(timeParts[1]);
                time += Convert.ToDouble(timeParts[2]) / 100.0;
            }
            else
            {
                time += Convert.ToInt32(timeParts[0]);
                time += Convert.ToDouble(timeParts[1]) / 100.0;
            }
            return time;
        }
    }
}
