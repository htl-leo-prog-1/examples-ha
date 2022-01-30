using System;

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
            WriteArray(numbers,"Ursprüngliches Array mit Duplikaten: ");
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
            WriteArray(numbers, "Array mit gelöschten Duplikaten:     ");
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
            WriteArray(numbers, "Verdichtetes Array:                  ");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Beenden mit Eingabetaste ...");
            Console.ReadLine();
        }

        /// <summary>
        /// Gibt das Array auf den Bildschirm aus. Die einzelnen Zahlen
        /// werden durch ein Leerzeichen getrennt.
        /// Der Text wird vor dem Array ausgegeben
        /// </summary>
        /// <param name="numbers">Array mit int-Zahlen</param>
        /// <param name="text"></param>
        static void WriteArray(int[] numbers, string text)
        {
            Console.Write(text);
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write("{0} ", numbers[i]);
            }

        }
    }
}
