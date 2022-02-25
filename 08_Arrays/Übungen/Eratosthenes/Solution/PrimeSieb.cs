/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------                         
* ------------------------------------------------ 
* Kurzbeschreibung:      
* Mit Hilfe des klassischen Algorithmus "Sieb des Erathostenes" (ca. 300 v.Chr.) sollen alle Primzahlen
* (i.e. eine ganze Zahl, die nur durch sich selbst und durch 1 teilbar ist) bis zu einer einzugebenden
* Obergrenze bestimmt werden.
* Da das mit Divisionen sehr aufwändig ist, hatte Erathostenes folgende Idee:
* Man schreibt die Zahlen von 1 bis zur Obergrenze auf. Dann streicht man daraus die Vielfachen
* von 2, 3, 5 usw. bis zur Quadratwurzel aus der Obergrenze. Die nicht gestrichenen Zahlen sind
* am Ende dann die Primzahlen.
 ***********************************************************************************************/

namespace PrimeSieb
{
    using System;

    class Sieb
    {
        public static void Main(string[] args)
        {
            const int MAXLINES = 22;

            Console.Write("Bis zu welcher Zahl wollen Sie Primzahlen ausgeben? ");
            int maxNumber = Convert.ToInt32(Console.ReadLine());
            while ((maxNumber <= 0))
            {
                Console.WriteLine("Die größte Zahl muss größer als 1 sein!");
                Console.Write("Bis zu welcher Zahl wollen Sie Primzahlen ausgeben:");
                maxNumber = Convert.ToInt32(Console.ReadLine());
            }

            var isPrime = CalcIsPrime(maxNumber);

            //Ausgabe
            Console.WriteLine("Primzahlen von 1 - " + maxNumber + ":");
            int lineCounter = 1;
            for (int i = 2; i <= maxNumber; i++)
            {
                if (isPrime[i])
                {
                    Console.WriteLine(i);
                    lineCounter++;
                    if (lineCounter == MAXLINES)
                    {
                        //Nach MAXLINES Zeilen wird auf eine Eingabetaste gewartet
                        Console.WriteLine("<Eingabetaste für weiter>");
                        Console.ReadLine();
                        lineCounter = 0;
                    }
                }
            }
        }

        private static bool[] CalcIsPrime(int maxNumber)
        {
            var isPrime = new bool[maxNumber + 1];

            isPrime[0] = false; //0 ist keine Primzahl
            isPrime[1] = false; //1 ist keine Primzahl
            for (int i = 2; i <= maxNumber; i++)
            {
                isPrime[i] = true;
            }

            int maxCheck = (int) (Math.Sqrt(maxNumber));
            for (int i = 2; i <= maxCheck; i++)
            {
                for (int multiplicator = 2; (multiplicator * i) <= maxNumber; multiplicator++)
                {
                    isPrime[multiplicator * i] = false;
                }
            }

            return isPrime;
        }
    }
}