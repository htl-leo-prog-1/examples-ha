using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variablendefinitionen
            int leftOperand;
            int rightOperand;
            int result;
            string userInput;
            // Eingabe
            Console.WriteLine("Einfacher Addierer für ganze Zahlen");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.Write("Linker Operand [int]: ");
            userInput = Console.ReadLine();
            leftOperand = Convert.ToInt32(userInput);
            Console.Write("Rechter Operand [int]: ");
            userInput = Console.ReadLine();
            rightOperand = Convert.ToInt32(userInput);
            // Verarbeitung
            result = leftOperand + rightOperand;
            // Ausgabe
            Console.WriteLine("Ergebnis von {0} + {1} = {2}",
                leftOperand, rightOperand, result);
            Console.Write("Beenden mit der Eingabetaste ...");
            Console.ReadLine();
        }

    }
}

