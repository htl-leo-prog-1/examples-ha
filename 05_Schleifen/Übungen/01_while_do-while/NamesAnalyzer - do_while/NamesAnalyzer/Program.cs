using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamesAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            string longestName = "";
            string shortestName = "";
            
            Console.WriteLine("Analyse der Länge der Namen");
            do
            {
                Console.Write("Name (Ende mit leerer Eingabe): ");
                name = Console.ReadLine();
                if (name.Length > longestName.Length)
                {
                    longestName = name;
                }
                if ((name.Length < shortestName.Length ||
                    shortestName.Length == 0)&& name.Length != 0)
                {
                    shortestName = name;
                }
            } while (name != "");
            Console.WriteLine("Der längste Name ist: {0} und er ist {1} Zeichen lang",
                longestName, longestName.Length);
            Console.WriteLine("Der kürzeste Name ist: {0} und er ist {1} Zeichen lang",
               shortestName, shortestName.Length);

            Console.ReadLine();
        }
    }
}
