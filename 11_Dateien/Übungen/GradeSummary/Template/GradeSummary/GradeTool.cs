using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace GradeSummary
{
    public class GradeTool
    {
        const int FIRSTGRADECOLUMN = 2;
        private const string AvgColumnName = "Average";

        /// <summary>
        /// Reads a csv file.
        /// </summary>
        /// <returns>The content of the csv file in a two-dimensional array.</returns>
        /// <param name="filePath">File path.</param>
        public static string[][] ReadCsvFile(string filePath)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes the file content into a csv file.
        /// </summary>
        /// <param name="fileContent">File content as two-dimensional area.</param>
        /// <param name="filePath">File path.</param>
        public static void WriteCsvFile(string[][] fileContent, string filePath)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Replace an existing file.
        /// A bak file is created. 
        /// </summary>
        /// <param name="fileContent"></param>
        /// <param name="filePath"></param>
        public static void ReplaceCsvFile(string[][] fileContent, string filePath)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add (if not exist) the average as last column.
        /// If the column already exists no average is added.
        /// </summary>
        /// <param name="fileContent"></param>
        public static void AddAvgColumn(string[][] fileContent)
        {
            throw new NotImplementedException();
        }

        private static string[] AddAvgColumn(string[] pupil)
        {
            throw new NotImplementedException();
        }

        private static string[] CopyArray(string[] ar, int newSize)
        {
            string[] newAr = new string[newSize];

            for (int i = 0; i < ar.Length && i < newSize; i++)
            {
                newAr[i] = ar[i];
            }

            return newAr;
        }
    }
}