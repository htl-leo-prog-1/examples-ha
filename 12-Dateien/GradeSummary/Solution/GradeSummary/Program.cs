using System;
using System.IO;

namespace GradeSummary
{
    class Program
    {

        public static int Main(string[] args)
        {
            string fileName;

            if (!CheckArguments(args, out fileName))
            {
                return 1;
            }

            string[][] fileContent = GradeTool.ReadCsvFile(fileName);

            GradeTool.AddAvgColumn(fileContent);

            GradeTool.ReplaceCsvFile(fileContent, fileName);

            return 0;
        }

        static bool CheckArguments(string[] args, out string fileName)
        {
            fileName = "Pupils.csv";

            if (args.Length > 1)
            {
                Console.WriteLine("usage:  CSV-Filename");
                return false;
            }
            else if (args.Length == 1)
            {
                fileName = args[0];
            }

            if (!File.Exists(fileName))
            {
                Console.WriteLine($"{fileName} does not exist");
                return false;
            }

            return true;
        }
    }
}
