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
            string[] lines = File.ReadAllLines(filePath, Encoding.Default);
            string[][] fileContent = new string[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                fileContent[i] = lines[i].Split(';');
            }

            return fileContent;
        }

        /// <summary>
        /// Writes the file content into a csv file.
        /// </summary>
        /// <param name="fileContent">File content as two-dimensional area.</param>
        /// <param name="filePath">File path.</param>
        public static void WriteCsvFile(string[][] fileContent, string filePath)
        {
            string[] lines = new string[fileContent.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = string.Join(';', fileContent[i]);
            }

            File.WriteAllLines(filePath, lines, Encoding.Default);
        }

        /// <summary>
        /// Replace an existing file.
        /// A bak file is created. 
        /// </summary>
        /// <param name="fileContent"></param>
        /// <param name="filePath"></param>
        public static void ReplaceCsvFile(string[][] fileContent, string filePath)
        {
            var fullPathName = Path.GetFullPath(filePath);
            var pathName = $"{Path.GetDirectoryName(fullPathName)}\\";
            var bakPathName = $"{pathName}{Path.GetFileNameWithoutExtension(fullPathName)}.bak";
            var tmpPathName = $"{pathName}{Path.GetFileNameWithoutExtension(fullPathName)}.$$$";

            WriteCsvFile(fileContent, tmpPathName);

            if (File.Exists(bakPathName))
            {
                File.Delete(bakPathName);
            }

            File.Move(fullPathName, bakPathName);
            File.Move(tmpPathName, fullPathName);
        }

        /// <summary>
        /// Add (if not exist) the average as last column.
        /// If the column already exists no average is added.
        /// </summary>
        /// <param name="fileContent"></param>
        public static void AddAvgColumn(string[][] fileContent)
        {
            if (fileContent[0][fileContent[0].Length - 1] != AvgColumnName)
            {
                fileContent[0] = CopyArray(fileContent[0], fileContent[0].Length + 1);
                fileContent[0][fileContent[0].Length - 1] = AvgColumnName;

                for (int i = 1; i < fileContent.Length; i++)
                {
                    fileContent[i] = AddAvgColumn(fileContent[i]);
                }
            }
        }

        private static string[] AddAvgColumn(string[] pupil)
        {
            int gradeSum = 0;
            int gradeCount = 0;
            for (int i = FIRSTGRADECOLUMN; i < pupil.Length; i++)
            {
                gradeCount++;
                gradeSum += int.Parse(pupil[i]);
            }

            if (gradeCount > 0)
            {
                pupil = CopyArray(pupil, pupil.Length + 1);
                pupil[pupil.Length-1] = ((double) gradeSum / gradeCount).ToString("N2", CultureInfo.InvariantCulture);
            }

            return pupil;
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