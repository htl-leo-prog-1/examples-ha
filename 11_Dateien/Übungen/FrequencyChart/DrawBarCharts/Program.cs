using System;
using System.IO;

namespace DrawBarCharts
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Draw Bar Chart!");
            Console.Write("Bitte geben Sie den Namen der CSV-Datei ein: ");
            string fileName = Console.ReadLine();

            Console.Write("Bitte geben Sie die Spalte mit den zu zeichnenden Daten ein: ");
            int dataCol = Convert.ToInt32(Console.ReadLine());

            Console.Write("Bitte geben Sie die Spalte mit den X-Achsen-Bezeichnungen ein: ");
            int labelCol = Convert.ToInt32(Console.ReadLine());

            string[, ] fileContent = ReadCsvFile("Revenue.csv");

            int topLevel = GetTopChartLevel(fileContent, dataCol);

            for (int i = topLevel; i > 0; i--)
                Console.WriteLine(MakeChartLine(fileContent, dataCol, 5, i));
            Console.WriteLine(MakeXAxisLabels(fileContent, 5, labelCol));
        }

        /// <summary>
        /// Reads a csv file.
        /// </summary>
        /// <returns>The content of the csv file in a two-dimensional array.</returns>
        /// <param name="filePath">File path.</param>
        private static string[,] ReadCsvFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
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

        static int GetTopChartLevel(string[,] fileContent, int dataColumn)
        {
            int maxLevel = 0;
            for (int i = 0; i < fileContent.GetLength(0); i++)
            {
                int level = Convert.ToInt32(fileContent[i, dataColumn]);
                if (level > maxLevel)
                    maxLevel = level;
            }
            return maxLevel;
        }

        private static string MakeChartLine(string[,] table, int dataColumn, int barWidth, int chartLevel)
        {
            string barLine = "";
            for (int i = 0; i < table.GetLength(0); i++)
            {
                if (Convert.ToInt32(table[i, dataColumn]) >= chartLevel)
                {
                    barLine += MakeABarColumn(barWidth);
                }
                else
                {
                    barLine += MakeEmptySpace(barWidth);
                }

            }
            return barLine;
        }

        static string MakeEmptySpace(int width)
        {
            string barSection = "";
            for (int i = 0; i < width; i++)
                barSection += " ";
            return barSection;
        }

        static string MakeABarColumn(int barWidth)
        {
            int halfTheBar = barWidth / 2;
            string emptyPart = MakeEmptySpace(halfTheBar);
            string barSection = emptyPart + "*" + emptyPart;
            return barSection;
        }
            
        static string MakeAnAxisLabel(string label, int labelWidth)
        {
            string printedLabel = label;
            int emptySpace = labelWidth - label.Length;
            int emptySpaceBefore = emptySpace / 2;
            int emptySpaceAfter = emptySpaceBefore;

            if (emptySpace > 0)
            {
                if (emptySpace % 2 != 0)
                {
                    emptySpaceAfter++; 
                }
            }
            else
            {
                emptySpaceBefore = 0;
                emptySpaceAfter = 1;
                printedLabel = label.Substring(0, labelWidth - 1);
            }
            return MakeEmptySpace(emptySpaceBefore) + printedLabel + MakeEmptySpace(emptySpaceAfter);
        }

        static string MakeXAxisLabels(string[,] table, int barWidth, int labelColumn)
        {
            string axisLabels = "";
            for (int i = 0; i < table.GetLength(0); i++)
            {
                axisLabels += MakeAnAxisLabel(table[i, labelColumn], barWidth);
            }
            return axisLabels;
        }

    }
}
