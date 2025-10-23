using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarshadNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Berechnung von Harshad-Zahlen:");
            for (int harshadCandidate = 1; harshadCandidate <= 1000; harshadCandidate++ )
            {
                int number = harshadCandidate;
                int sumOfDigits = 0;
                while (number != 0)
                {
                    sumOfDigits += number % 10;
                    number = number / 10;
                }
                if (harshadCandidate % sumOfDigits == 0)
                {
                    Console.Write("{0}, ", harshadCandidate);
                }
            }
            Console.Write("\b\b.");
            Console.ReadKey();
        }
    }
}
