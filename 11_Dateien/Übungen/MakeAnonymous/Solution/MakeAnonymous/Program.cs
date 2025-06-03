/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: MakeAnonymous
*--------------------------------------------------------------
*/

namespace MakeAnonymous
{
    using System;
    using System.Globalization;
    using System.IO;

    public class Program
    {
        public static int Main(string[] args)
        {
            string fileName;

            if (!CheckArguments(args, out fileName))
            {
                return 1;
            }

            string fullPathName = Path.GetFullPath(fileName);

            string[][] games = MakeAnonymous.ReadCsvFile(fullPathName);

            string[] convert = MakeAnonymous.MakeTeamsAnonymous(games);

            MakeAnonymous.ReplaceCsvFile(games, fileName);

            for (int i = 0; i < convert.Length; i++)
            {
                Console.WriteLine($"{convert[i],-40} => Team {i + 1}");
            }

            return 0;
        }

        static bool CheckArguments(string[] args, out string fileName)
        {
            fileName   = "Games.csv";

            if (args.Length > 1)
            {
                Console.WriteLine("usage: MakeAnonymous CSV-Filename");
                return false;
            }


            if (args.Length > 0)
            {
                fileName = args[0];
            }

            if (!File.Exists(fileName))
            {
                Console.WriteLine($"{fileName} does not exist");
                return false;
            }

            if (Path.GetExtension(fileName).ToUpper() != ".CSV")
            {
                Console.WriteLine("File is not of type .csv");
                return false;
            }

            return true;
        }
    }
}