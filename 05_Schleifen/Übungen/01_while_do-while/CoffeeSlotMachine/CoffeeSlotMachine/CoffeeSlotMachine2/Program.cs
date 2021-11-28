using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSlotMachine2
{
    class Program
    {
        static void Main(string[] args)
        {
            const int PRICE = 50;
            int sumThrownIn = 0;
            int throwIn;
            int centsToReturn;
            string input;
            Console.WriteLine("Kaffeeautomat; Preis 50 Cent; Einwurf von 5, 10, 20, 50, 100, 200 Cent");
            Console.WriteLine();
            do
            {
                Console.Write("Bisher eingeworfen {0}, Einwurf in Cent: ", sumThrownIn);
                input = Console.ReadLine();
                throwIn = Convert.ToInt32(input);
                if (throwIn == 5 || throwIn == 10 || throwIn == 20 || throwIn == 50 || throwIn == 100 || throwIn == 200)
                {
                    sumThrownIn = sumThrownIn + throwIn;
                }
                else
                {
                    Console.WriteLine("Bitte geben sie gültige Münzen ein!");
                }
            }
            while (sumThrownIn < PRICE);
            centsToReturn = sumThrownIn - PRICE;
            Console.WriteLine("Kaffeeausgabe, Einwurf: {0} ==> Retourgeld: {1} Cent", sumThrownIn, centsToReturn);
            Console.WriteLine("Programm beenden mit Eingabetaste ...");
            Console.ReadLine();
        }
    }
}
