using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameLetterSeries
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            char ch;
            char resultCh=' ';
            int lengthSeriesIndex=0;
            int maxLength = 0;
            int searchIndex;
            int length;

            Console.WriteLine("Serie gleicher Buchstaben finden");
            Console.WriteLine("================================");
            Console.Write("Text: ");
            input = Console.ReadLine();
            Console.WriteLine();

            for (int i = 0; i < input.Length; i++)
            {
                length = 1;
                ch = input[i];
                while (i+length < input.Length && input[i+length] == ch)
                {
                    length++;
                }
                if (length > maxLength)
                {
                    lengthSeriesIndex = i;
                    resultCh = ch;
                    maxLength = length;
                }
            }

            Console.WriteLine($"Der Text {input} enthält das Zeichen {resultCh} ab dem Index {lengthSeriesIndex} {maxLength} mal!");
            Console.Write("Beenden mit Eingabetaste ...");
            Console.ReadLine();
        }
    }
}
