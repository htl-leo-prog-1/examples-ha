using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorizeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int number;        // zu faktorosierende Zahl
            int divideBy = 2; // bei zwei beginnend wird dividiert
            string resultText = "1";
            Console.WriteLine("Primfaktorzerlegung");
            Console.WriteLine("===================");
            Console.Write("Geben Sie eine Zahl > 1 ein, die dann in Primfaktoren zerlegt wird: ");
            input = Console.ReadLine();
            number = Convert.ToInt32(input);
            Console.WriteLine();
            while (number > 1)
            {
                if (number % divideBy == 0) // Zahl ist durch Divisor teilbar
                {
                    Console.WriteLine("{0,5} : {1,3} = {2,3}", number, divideBy, number/divideBy);
                    number = number / divideBy;
                    resultText = resultText + "*"+ divideBy;
                }
                else // Zahl ist nicht (mehr) durch Divisor teilbar ==> Divisor erhöhen
                {
                    divideBy++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("{0}={1}", input, resultText);
            Console.Write("Beenden mit Engabetaste ...");
            Console.ReadLine();
        }
    }
}
