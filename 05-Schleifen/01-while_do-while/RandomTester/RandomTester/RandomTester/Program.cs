using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomTester
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            int max;
            int min;
            string input;
            int inputMin;
            int inputMax;
            int inputCounter;
            int number;
            long sum = 0;
            Random random=new Random(0);

            Console.WriteLine("Tester für Zufallszahlengenerator");
            Console.Write("Minimum: ");
            input = Console.ReadLine();
            inputMin = Convert.ToInt32(input);
            Console.Write("Maximum: ");
            input = Console.ReadLine();
            inputMax = Convert.ToInt32(input);
            Console.Write("Anzahl: ");
            input = Console.ReadLine();
            inputCounter = Convert.ToInt32(input);
            min = inputMax + 1;
            max = inputMin - 1;
            while (counter<inputCounter)
            {
                counter++;
                number = random.Next(inputMin, inputMax + 1);
                sum = sum + number;
                if (number>max)
                {
                    max = number;
                }
                if (number<min)
                {
                    min = number;
                }
            }
            Console.WriteLine("Minimum: {0}, Maximum: {1}, Durchschnitt: {2:f2}",
                min,max,sum/(double)inputCounter);
            Console.Write("Beenden mit der Eingabetaste...");
            Console.ReadLine();



        }
    }
}
