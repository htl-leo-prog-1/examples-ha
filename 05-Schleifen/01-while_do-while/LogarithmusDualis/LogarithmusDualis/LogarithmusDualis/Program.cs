using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogarithmusDualis
{
    class Program
    {
        static void Main(string[] args)
        {

            bool proceed = true;
            do
            {
                Console.Write("Berechne den Logarithmus Dualis (ld) von: ");
                int a = Convert.ToInt32(Console.ReadLine());
                int remainder = a / 2;
                int x = 0;
                while (remainder > 0) 
                {
                    x++;
                    remainder /= 2;
                }
                Console.WriteLine("ld(" + a + ") = " + x);
                Console.WriteLine();
                Console.WriteLine("Nochmal?");
                proceed = Console.ReadLine() == "j";
            } while (proceed);
            

            Console.ReadKey();
        }
    }
}
