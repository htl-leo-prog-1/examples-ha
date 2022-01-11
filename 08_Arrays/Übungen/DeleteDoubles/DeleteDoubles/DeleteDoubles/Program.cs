using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteDoubles
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MAX = 10;
            int[] numbers = new int[MAX];
            int number;
            int counter = 0;
            int indexOneLeft;

            Console.WriteLine("Eingabe von maximal 10 Zahlen");
            Console.WriteLine("Beenden durch Zahl 0");
            Console.WriteLine("====================");
            Console.WriteLine();
            // Eingabe
            do
            {
                Console.Write("{0}. Zahl: ", counter + 1);
                number = Convert.ToInt32(Console.ReadLine());
                if (number != 0)
                {
                    numbers[counter] = number;
                    counter++;
                }
            } while (counter < 10 && number != 0);
            // Ausgabe
            Console.WriteLine();
            Console.Write("Ursprüngliches Array mit Duplikaten: ");
            for (int i = 0; i < counter && numbers[i] != 0; i++)
            {
                Console.Write("{0} ", numbers[i]);
            }
            // Verarbeitung
            // Doppelte Elemente aus dem Array löschen ==> 0 setzen
            for (int i = 0; i < counter - 1; i++)
            {
                for (int j = i + 1; j < counter; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        numbers[j] = 0;
                    }
                }
            }
            Console.WriteLine();
            Console.Write("Array mit gelöschten Duplikaten:     ");
            for (int i = 0; i < counter; i++)
            {
                Console.Write("{0} ", numbers[i]);
            }
            // Array verdichten
            for (int i = 0; i < counter; i++)
            {
                indexOneLeft = i - 1;
                while (indexOneLeft >= 0 && numbers[indexOneLeft] == 0)  // solange links die selbe Zahl steht
                {
                    numbers[indexOneLeft] = numbers[indexOneLeft + 1];
                    numbers[indexOneLeft + 1] = 0;
                    indexOneLeft--;
                }
            }
            // Ausgabe
            Console.WriteLine();
            Console.Write("Verdichtetes Array:                  ");
            for (int i = 0; i < counter; i++)
            {
                Console.Write("{0} ", numbers[i]);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Beenden mit Eingabetaste ...");
            Console.ReadLine();
        }
    }
}
