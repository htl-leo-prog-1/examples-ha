using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Eingabetext: ");
            string userInPut = Console.ReadLine();

            Console.Write("Eliminatortext: ");
            string eliminator = Console.ReadLine();

            string outputText = "";

            for (int i = 0; i < userInPut.Length; i++)
            {
                bool eliminated = false;
                for (int k = 0; k < eliminator.Length && !eliminated; k++)
                {
                    if (eliminator[k] == userInPut[i])
                    {
                        eliminated = true;
                    }
                }
                if (!eliminated)
                {
                    outputText += userInPut[i];
                }
            }
            Console.WriteLine("Ausgabe: " + outputText);
            Console.ReadKey();
        }
    }
}
