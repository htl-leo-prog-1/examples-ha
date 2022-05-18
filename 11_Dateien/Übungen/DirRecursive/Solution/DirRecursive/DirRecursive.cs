/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: DirRecursive
*--------------------------------------------------------------
*/

namespace DirRecursive
{
    using System;
    using System.IO;

    public class DirRecursive
    {
        public static int Main(string[] args)
        {
            if (!CheckArguments(args))
            {
                return 1;
            }

            var dirName = Path.GetFullPath(args[0]);
            var searchPattern = args.Length > 1 ? args[1] : "*.*";

            int count = ListAndCount(dirName, searchPattern);

            Console.WriteLine($"total {count}");
            return 0;
        }

        static bool CheckArguments(string[] args)
        {
            if (args.Length < 1 || args.Length > 2)
            {
                Console.WriteLine("usage: DirRecursive dirname [searchPattern]");
                return false;
            }

            var dirName = args[0];

            if (!Directory.Exists(dirName))
            {
                Console.WriteLine($"{dirName} does not exist");
                return false;
            }

            return true;
        }

        static int ListAndCount(string dirName, string searchPattern)
        {
            int count = 0;
            foreach (var filename in Directory.GetFiles(dirName, searchPattern))
            {
                count++;
                Console.WriteLine(filename);
            }

            foreach (var subDirName in Directory.GetDirectories(dirName))
            {
                count += ListAndCount(subDirName, searchPattern);
            }

            return count;
        }
    }
}