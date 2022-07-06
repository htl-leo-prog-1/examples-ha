/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: SelectPupils
*--------------------------------------------------------------
*/

using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace SelectPupils
{
    public class Program
    {
        /// <summary>
        /// Main entry point of program.
        /// </summary>
        /// <param name="args">Command-line-arguments</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Select Pupils");
            Console.WriteLine("=====================");

            string fileName = "Pupils.csv";

            //TODO Implement main code here
        }

        /// <summary>
        /// Read the pupils from the csv file.
        /// </summary>
        /// <param name="fileName">csv filename.</param>
        /// <returns>The list (array) of pupils.</returns>
        public static Pupil[] ReadPupilsFromCsv(string fileName)
        {
            //TODO Implement read csv file here 
        }

        // TODO Implement: Pupil[] FilterByGrade(Pupil[] pupils)
        // TODO Implement: Pupil[] SortByGrade(Pupil[] pupils)
        // TODO Implement: void WritePupilsToCsv(Pupil[] pupils, string fileName)
    }
}