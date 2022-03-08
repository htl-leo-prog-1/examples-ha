/***********************************************************************************************
 * Assignment:     Grade Conversion
 * Author:             
 * Class:          1AHIF
 * Date:           29.04.2016                              
 * ------------------------------------------------ 
 * Description:      
 * A program to read a csv-file containing students
 * and their related grades in numbers. The grade numbers shall be converted
 * into grade texts, and be written to a new csv-file,
 * now containing grade texts instead of grade numbers.
 ***********************************************************************************************/
using System;
using System.IO;
using System.Text;

namespace GradeConversion
{
    class Program
    {
        const int LASTNAME = 0;
        const int FIRSTNAME = 1;
        const int GRADE = 2;

        public static void Main(string[] args)
        {
            Console.WriteLine("Convert Grades");

            string[,] fileContent = ReadCsvFile("sample.csv");

            Assert(fileContent.GetLength(0) == 31, "Number of lines");
            Assert(fileContent.GetLength(1) == 3, "Number of columns");
            Assert(fileContent[0, LASTNAME] == "Ahmadi", "Name of first entry");
            Assert(fileContent[13, FIRSTNAME] == "Jonas", "First name of 14th entry");
            Assert(fileContent[30, GRADE] == "3", "Grade of last entry");

            fileContent = ReplaceGrade(fileContent);

            Assert(fileContent[0, GRADE] == "GEN", "Letter grade of first entry");
            Assert(fileContent[13, GRADE] == "NGD", "Letter grade of 14th entry");
            Assert(fileContent[30, GRADE] == "BEF", "Letter grade of last entry");

            WriteCsvFile(fileContent, "sampleChanged.csv");

            CompareFiles(); // This is a test method -> already implemented

            PrintSummary();

            Console.ReadKey();
        }

        /// <summary>
        /// Reads a csv file.
        /// </summary>
        /// <returns>The content of the csv file in a two-dimensional array.</returns>
        /// <param name="filePath">File path.</param>
        static string[,] ReadCsvFile(string filePath)
        {
            string[,] fileContent = new string[50,4];

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
                string[] fileUnderTest = File.ReadAllLines("sampleChanged.csv", Encoding.Default);
                string[] expected = File.ReadAllLines("sampleExpected.csv", Encoding.Default);
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
