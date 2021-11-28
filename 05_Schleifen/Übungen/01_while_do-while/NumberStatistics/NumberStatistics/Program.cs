using System;

namespace NumberStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int number;   // aktuell eingegebene Zahl
            int count = 0;
            int sum = 0;
            double average;
            int largestNumber = 0;
            int secondLargestNumber = 0;
            Console.WriteLine("Mittelwert, Summe und zweitgroesste Zahl einer Folge positiver Ganzzahlen ermitteln");
            Console.WriteLine("Zahl eingeben und Eingabetaste druecken, Ende mit 0");
            Console.WriteLine();
            Console.Write("Zahl {0}: ", count + 1);
            input = Console.ReadLine();
            number = Convert.ToInt32(input);
            while (number > 0)
            {
                // Fortlaufende Summe und Anzahl der Zahlen ermitteln
                count++;
                sum += number;
                if (number > largestNumber)  // neue größte Zahl und bisherige größte wird zweitgrößte
                {
                    secondLargestNumber = largestNumber;
                    largestNumber = number;
                }
                else
                {
                    if (number > secondLargestNumber)
                    {
                        secondLargestNumber = number;
                    }
                }
                Console.Write("Zahl {0}: ", count + 1);
                input = Console.ReadLine();
                number = Convert.ToInt32(input);
            }
            Console.WriteLine();
            // Ausgabe
            if (count > 0)
            {
                Console.WriteLine("Summe: {0}", sum);
                average = sum / Convert.ToDouble(count);
                Console.WriteLine("Mittelwert: {0:f2}", average);
                if (count >= 2)
                {
                    Console.WriteLine("Zweitgroesste Zahl: {0}", secondLargestNumber);
                }
                else
                {
                    Console.WriteLine("Es gibt keine zweitgroesste Zahl, da weniger als zwei Zahlen eingegeben wurden!");
                }
            }
            else  // keine Zahlen eingegeben
            {
                Console.WriteLine("Es wurden keine Zahlen eingegeben!");
            }
            Console.Write("Weiter mit Enter!");
            Console.ReadLine();
        }
    }
}
