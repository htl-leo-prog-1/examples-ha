using System;
using System.IO;

namespace FrequencyChart
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Convert.to
            Console.WriteLine("Frequency Chart!");

            string[,] grades = ReadCsvFile("GradesFrequency.csv");
            Assert(grades.GetLength(0) == 5, "Rows count");
            Assert(grades.GetLength(1) == 2, "Columns count");
            Assert(grades[0, 0] == "SGT1", "First element");
            Assert(grades[3, 1] == "6", "Number of GEN");

            string [,] revenues = ReadCsvFile("Revenue.csv");
            Assert(revenues.GetLength(0) == 12, "Rows count");
            Assert(revenues.GetLength(1) == 3, "Columns count");
            Assert(revenues[0, 0] == "2013", "First element");
            Assert(revenues[7, 1] == "Apr", "Month in row 8");

            Assert(MakeEmptySpace(5) == "     ", "Empty column of width 5");
            Assert(MakeEmptySpace(7) == "       ", "Empty column of width 7");
            Assert(MakeEmptySpace(3) == "   ", "Empty column of width 3");

            Assert(MakeABarColumn(5) == "  *  ", "Bar with 5");
            Assert(MakeABarColumn(7) == "   *   ", "Bar with 7");
            Assert(MakeABarColumn(3) == " * ", "Bar with 3");

            Assert(TrimTextForLabel("Jan", 4) == "Jan", "If label fits, no trimming. One blank is mandatory");
            Assert(TrimTextForLabel("October", 24) == "October", "If there is plenty of space, no trimming");
            Assert(TrimTextForLabel("August", 5) == "Augu", "Trim to required length - 1");

            Assert(GetEmptySpaceBeforeLabelText("Jan", 5) == 1, "Empty space before: odd text length, centered");
            Assert(GetEmptySpaceBeforeLabelText("Jan", 7) == 2, "Empty space before: odd text length, again centered but more space");
            Assert(GetEmptySpaceBeforeLabelText("SGT1", 5) == 0, "Empty space before: even text length, space cut before.");
            Assert(GetEmptySpaceBeforeLabelText("SGT1", 7) == 1, "Empty space before: even text length, again space cut before but more space");

            Assert(GetEmptySpaceAfterLabelText("Jan", 5) == 1, "Empty space after: odd label length, centered");
            Assert(GetEmptySpaceAfterLabelText("Jan", 7) == 2, "Empty space after: odd label length, again centered but more space");
            Assert(GetEmptySpaceAfterLabelText("SGT1", 5) == 1, "Empty space after: even label length, space added after.");
            Assert(GetEmptySpaceAfterLabelText("SGT1", 7) == 2, "Empty space after: even label length, again space cut before but more space");

            Assert(MakeAnAxisLabel("SGT1", 5) == "SGT1 ", "Fitting axis label with even content length");
            Assert(MakeAnAxisLabel("October", 9) == " October ", "Fitting axis label with odd content length");
            Assert(MakeAnAxisLabel("Jan", 7) == "  Jan  ", "Fitting axis label with more space around");
            Assert(MakeAnAxisLabel("December", 5) == "Dece ", "Too large axis label");

            string chartLine = MakeXAxisLabels(grades, 0, 5);
            Assert(chartLine == "SGT1 GUT2 BEF3 GEN4 NGD5 ", "X-Axis labels of grades");

            chartLine = MakeXAxisLabels(revenues, 1, 5);
            Assert(chartLine == " Sep  Oct  Nov  Dec  Jan  Feb  Mar  Apr  May  Jun  Jul  Aug ", "X-Axis labels of revenues");

            Assert(GetLargestValueInColumn(grades, 1) == 8, "Largest data value in grades");
            Assert(GetLargestValueInColumn(revenues, 2) == 11, "Largest data value in revenues");

            int barWidth = 5;
            int dataColumn = 2;
            int chartLevel = 11;
            chartLine = MakeChartLine(revenues, dataColumn, barWidth, chartLevel);
            Assert(chartLine.Length == 5 * 12, "Width of chart");
            Assert(chartLine == "            *                                               ", "Top level of revenues chart");

            chartLine = MakeChartLine(revenues, dataColumn, barWidth, 5);
            Assert(chartLine == "  *    *    *    *    *         *    *              *       ", "Level 5 of revenues chart");

            chartLine = MakeChartLine(grades, 1, barWidth, 1);
            Assert(chartLine == "  *    *    *    *    *  ", "Level 1 of grades chart");

            PrintSummary();
            Console.ReadKey();
        }

        /// <summary>
        /// Reads a csv file.
        /// </summary>
        /// <returns>The content of the csv file in a two-dimensional array.</returns>
        /// <param name="filePath">File path.</param>
        private static string[,] ReadCsvFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            string[,] fileContent = CreateFileContentContainer(lines);

            for (int i = 0; i < lines.Length; i++)
            {
                FillOneLine(lines[i], fileContent, i);
            }
            return fileContent;
        }

        private static string[,] CreateFileContentContainer(string[] lines)
        {
            int rowsCount = lines.Length;
            int colsCount = rowsCount > 0? lines[0].Split(';').Length: 0;

            return new string[rowsCount, colsCount];
        }

        private static string[,] FillOneLine(string line, string[,] fileContent, int lineNumber)
        {
            string[] cols = line.Split(';');
            for (int j = 0; j < cols.Length; j++)
            {
                fileContent[lineNumber, j] = cols[j];
            }
            return fileContent;
        }

        /// <summary>
        /// Makes an empty space by returning a string of blanks.
        /// </summary>
        /// <returns>Returns a string of blanks of a given width.</returns>
        /// <param name="width">Width of the empty space.</param>
        private static string MakeEmptySpace(int width)
        {
            string barSection = "";
            for (int i = 0; i < width; i++)
                barSection += " ";
            return barSection;
        }

        /// <summary>
        /// Makes one bar column of a bar chart. The bar consists of a centered asterisk (*).
        /// </summary>
        /// <returns>A string of width barWidth with a star as bar column centered.</returns>
        /// <param name="barWidth">Bar width. Should be an odd number.</param>
        private static string MakeABarColumn(int barWidth)
        {
            int halfTheBar = barWidth / 2;
            string emptyPart = MakeEmptySpace(halfTheBar);
            string barSection = emptyPart + "*" + emptyPart;
            return barSection;
        }

        /// <summary>
        /// Cuts the end of a text toLength if necessary. If the text is shorter than
        /// toLength the text is returned unchanged. If the text is as long as or longer
        /// than toLength the text will be shortened.
        /// </summary>
        /// <returns>The trimmed text.</returns>
        /// <param name="text">Text to be trimmed.</param>
        /// <param name="toLength">Max length of text - 1.</param>
        private static string TrimTextForLabel(string text, int toLength)
        {
            if (text.Length < toLength)
                return text;
            else
                return text.Substring(0, toLength - 1);
        }

        /// <summary>
        /// Returns the empty space before a label text for a label of labelWidth. Since
        /// the text is centered it returns half of the available white space of text in
        /// labelWidth. Returns useful results only if labelWidth is at least label.Length.
        /// </summary>
        /// <returns>The number of blanks in label before text begins.</returns>
        /// <param name="text">Text to be printed.</param>
        /// <param name="labelWidth">Width of label into which text is printed.</param>
        private static int GetEmptySpaceBeforeLabelText(string text, int labelWidth)
        {
            return (labelWidth - text.Length) / 2;
        }

        /// <summary>
        /// Returns the empty space after a label text for a label of labelWidth. This is basically
        /// the same procedure as in GetEmptySpaceBeforeLabelText() but if there is an odd number of
        /// blanks to be made the missing blank is added after the label text.
        /// Example: " Sept  " --> Available space is 7, label length is 4. Blanks to be made are 3
        /// (one before the label and two after)
        /// </summary>
        /// <returns>The number of blanks after the text.</returns>
        /// <param name="text">Text to be printed.</param>
        /// <param name="labelWidth">Space available for label.</param>
        private static int GetEmptySpaceAfterLabelText(string text, int labelWidth)
        {
            int blanksCount = labelWidth - text.Length;
            if (blanksCount % 2 == 0)
                return blanksCount / 2;
            else
                return blanksCount / 2 + 1;
        }

        /// <summary>
        /// Makes an axis label of a specific width, i.e., it returns a string with text and adds
        /// white space before and after the string such that the returned string gets the required width.
        /// </summary>
        /// <returns>The an axis label.</returns>
        /// <param name="text">Text for the label.</param>
        /// <param name="labelWidth">Required label width.</param>
        private static string MakeAnAxisLabel(string text, int labelWidth)
        {
            string printedLabel = TrimTextForLabel(text, labelWidth);
            int emptySpaceBefore = GetEmptySpaceBeforeLabelText(printedLabel, labelWidth);;
            int emptySpaceAfter = GetEmptySpaceAfterLabelText(printedLabel, labelWidth);

            return MakeEmptySpace(emptySpaceBefore) + printedLabel + MakeEmptySpace(emptySpaceAfter);
        }

        /// <summary>
        /// Looks for the largest value in fileContent in column dataColumn.
        /// </summary>
        /// <returns>The largest value.</returns>
        /// <param name="fileContent">The file content in which the largest value is searched.</param>
        /// <param name="dataColumn">The data column in which the largest value is searched.</param>
        private static int GetLargestValueInColumn(string[,] fileContent, int dataColumn)
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

        /// <summary>
        /// Returns one line of a bar chart on a specific chartLevel.
        /// </summary>
        /// <returns>The chart line.</returns>
        /// <param name="table">The data source table.</param>
        /// <param name="dataColumn">The data source column.</param>
        /// <param name="barWidth">The width of one bar of the bar chart.</param>
        /// <param name="chartLevel">Chart level.</param>
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

        /// <summary>
        /// Makes the X axis labels for a bar chart.
        /// </summary>
        /// <returns>The X axis labels.</returns>
        /// <param name="table">Table to get label information.</param>
        /// <param name="labelColumn">Column to get label information.</param>
        /// <param name="labelWidth">Max width of the label.</param>
        private static string MakeXAxisLabels(string[,] table, int labelColumn, int labelWidth)
        {
            string axisLabels = "";
            for (int i = 0; i < table.GetLength(0); i++)
            {
                axisLabels += MakeAnAxisLabel(table[i, labelColumn], labelWidth);
            }
            return axisLabels;
        }








        /// <summary>
        /// Assert the specified condition and reports message.
        /// </summary>
        /// <param name="condition">If set to <c>true</c> condition.</param>
        /// <param name="message">Message.</param>
        private static void Assert(bool condition, string message)
        {
            ConsoleColor originalColor = Console.ForegroundColor;

            if (condition)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message + "... OK");
                passCount++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message + "... Fail");
                failCount++;
            }
            Console.ForegroundColor = originalColor;
        }

        private static void PrintSummary()
        {
            Console.WriteLine("Total number of " + (passCount + failCount) + " test cases");
            Console.WriteLine(passCount + " tests passed");
            Console.WriteLine(failCount + " tests failed");
        }

        private static int passCount;
        private static int failCount;
    }
}
