/***********************************************************************************************
 * Übungsnr:        12                                     
 * Programmname:    Sieb des Erathostenes
 * Autor:           Michael Bucek  
 * Klasse:          1CHIF
 * Datum:           03.12.2013                               
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

using System;


namespace PrimSieb
{
    class Sieb
    {
        public static void Main(string[] args)
        {
            const int MAXLINES = 22;
            bool[] isPrim;
            int maxNumber;
            int i, algoBorder, multiplicator;
            int lineCounter;
            int acc = 0;

            Console.Write("Bis zu welcher Zahl wollen Sie Primzahlen ausgeben? ");
            maxNumber = Convert.ToInt32(Console.ReadLine());
            while ((maxNumber <= 0))
            {
                Console.WriteLine("Die größte Zahl muss größer als 1 sein!");
                Console.Write("Bis zu welcher Zahl wollen Sie Primzahlen ausgeben:");
                maxNumber = Convert.ToInt32(Console.ReadLine());
            }

            isPrim = new bool[maxNumber + 1];
            
            //Das bool-Array wird mit true initialisiert -> sobald eine Zahl ein Vielfaches einer Zahl ab 2 ist 
            //wird diese gestrichen.
            
            isPrim[0]=false;   //0 ist keine Primzahl
            isPrim[1]=false;   //1 ist keine Primzahl
            for (i = 2; i <= maxNumber; i++)
            {
                acc++;
                isPrim[i] = true;
            }

            algoBorder = (int)(Math.Sqrt(maxNumber));
            for (i = 2; i <= algoBorder; i++)
            {
                for (multiplicator = 2; (multiplicator * i) <= maxNumber; multiplicator++)
                {
                    acc++;
                    isPrim[multiplicator * i] = false;
                }
            }

            //Ausgabe
            Console.WriteLine("Primzahlen von 1 - " + maxNumber + ":");
            lineCounter = 1;
            for (i = 2; i <= maxNumber; i++)
            {
                acc++;
                if (isPrim[i])
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
            //Console.WriteLine("Zugriffe:" + acc);
            Console.WriteLine("<Eingabetaste für ENDE>");
            Console.ReadLine();

        } // Main
    }
}