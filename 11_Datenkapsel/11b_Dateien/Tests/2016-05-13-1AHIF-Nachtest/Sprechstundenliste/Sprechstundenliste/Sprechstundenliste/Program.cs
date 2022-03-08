using System;
using System.IO;
using System.Text;

namespace Sprechstundenliste
{
    class Program
    {
        const int TITEL = 2;
        const int NAME = 0;
        const int TAG = 4;
        const int UHRZEIT = 5;
        const int RAUM = 6;
        static void Main(string[] args)
        {
            string[,] fileContent = ReadCsvFile("Sprechstunden.csv");
            for (int i = 0; i < fileContent.GetLength(0); i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("{0, -5}");
                    Console.WriteLine("{0,-21}{1,-25}{2,-4}{3,-14}{4,-10}",
                        fileContent[i, TITEL].ToUpper(),
                        fileContent[i, NAME].ToUpper(),
                        fileContent[i, TAG].ToUpper(),
                        fileContent[i, UHRZEIT].ToUpper(),
                        fileContent[i, RAUM].ToUpper());
                }
                else
                {
                    Console.WriteLine("{0,-21}{1,-25}{2,-4}{3,-14}{4,-10}",
                        fileContent[i, TITEL],
                        fileContent[i, NAME],
                        fileContent[i, TAG],
                        fileContent[i, UHRZEIT],
                        fileContent[i, RAUM]);
                }


            }

            Console.ReadKey();
        }

        /// <summary>
        /// Reads a csv file.
        /// </summary>
        /// <returns>The content of the csv file in a two-dimensional array.</returns>
        /// <param name="filePath">File path.</param>
        private static string[,] ReadCsvFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath, Encoding.Default);
            string[,] fileContent = null;

            for (int i = 0; i < lines.Length; i++)
            {
                string[] cols = lines[i].Split(';');
                if (i == 0)
                    fileContent = new string[lines.Length, cols.Length];
                for (int j = 0; j < cols.Length; j++)
                {
                    fileContent[i, j] = cols[j];
                }
            }
            return fileContent;
        }

    }
}
