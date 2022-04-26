using System;
using System.IO;

namespace ConvertFile
{
    class MainClass
    {
        const int LASTNAME = 0;
        const int FIRSTNAME = 1;
        const int GRADE = 2;

        public static void Main(string[] args)
        {
            Console.WriteLine("File of Grades");

            string[,] fileContent = ReadCsvFile("sample.csv");
            Assert(fileContent.GetLength(0) == 29, "Number of lines");
            Assert(fileContent.GetLength(1) == 3, "Number of columns");
            Assert(fileContent[0, LASTNAME] == "Bamminger", "Name of first entry");
            Assert(fileContent[13, FIRSTNAME] == "Christoph", "First name of 14th entry");
            Assert(fileContent[28, GRADE] == "3", "Grade of last entry");

            fileContent = ReplaceGrade(fileContent);
            Assert(fileContent[0, GRADE] == "GEN", "Letter grade of first entry");
            Assert(fileContent[13, GRADE] == "NGD", "Letter grade of 14th entry");
            Assert(fileContent[28, GRADE] == "BEF", "Letter grade of last entry");

            WriteCsvFile(fileContent, "sampleChanged.csv");
            CompareFiles(); // This is a test method -> already implemented

            PrintSummary();
        }

        /// <summary>
        /// Reads a csv file.
        /// </summary>
        /// <returns>The content of the csv file in a two-dimensional array.</returns>
        /// <param name="filePath">File path.</param>
        private static string[,] ReadCsvFile(string filePath)
        {
            string[,] fileContent = new string[30,4];

            return fileContent;
        }

        /// <summary>
        /// Replaces the grade which is given as a number into the letter form.
        /// 1 -> SGT, 2 -> GUT, 3 -> BEF, 4 -> GEN, 5 -> NGD
        /// </summary>
        /// <returns>The file content as two-dimensional array with the grades replaced.</returns>
        /// <param name="fileContent">File content as two-dimensional array which grades have to be repaced.</param>
        static string[,] ReplaceGrade(string[,] fileContent)
        {
            return fileContent;
        }

        /// <summary>
        /// Writes the file content into a csv file.
        /// </summary>
        /// <param name="fileContent">File content as two-dimensional area.</param>
        /// <param name="filePath">File path.</param>
        static void WriteCsvFile(string[,] fileContent, string filePath)
        {
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

        static void CompareFiles()
        {
            if (File.Exists("sampleChanged.csv"))
            {
                string[] fileUnderTest = File.ReadAllLines("sampleChanged.csv");
                string[] expected = File.ReadAllLines("expected.csv");
                Assert(fileUnderTest.Length == expected.Length, "File lengths");
                for (int i = 0; i < expected.Length; i++)
                {
                    Assert(fileUnderTest[i] == expected[i], "Line " + i + " of written file");
                }
            }
            else
            {
                Assert(false, "Written file");
            }
        }

        private static int passCount;
        private static int failCount;
    }

    }
