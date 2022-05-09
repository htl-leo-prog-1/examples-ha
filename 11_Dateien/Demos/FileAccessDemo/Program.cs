using System;
using System.IO;

namespace FileAccessDemo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Accessing a CSV File!");
            string[] allLines = File.ReadAllLines("ClassList.csv");
            string[] formatString = {"{0, -5}", "{0, -20}", "{0, -20}", "{0, -5}"};

            for (int i = 0; i < allLines.Length; i++)
            {
                string [] allElements = allLines[i].Split(';');
                for (int j = 0; j < allElements.Length; j++)
                {
                    Console.Write(formatString[j], allElements[j]);
                }
                Console.WriteLine();
            }
        }
    }
}
