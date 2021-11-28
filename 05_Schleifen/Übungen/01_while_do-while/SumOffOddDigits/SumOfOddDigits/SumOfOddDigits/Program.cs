using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfOddDigits
{
 /*--------------------------------------------------------------
 *				HTBLA-Leonding / Klasse: 1BHIF 2015/2016
 *--------------------------------------------------------------
 * Übung:               0x
 * Datei:			    SumOfOddDigits.cs
 * Autor:		        Max Mustermann
 * Erstellungsdatum:    04.11.2015
 *--------------------------------------------------------------
 * Beschreibung:
 * Das Programm überechnet die Summe aller ungeraden Ziffern
 * der eingegebenen Zahl.
 *--------------------------------------------------------------
*/

    class Program
    {
        static void Main(string[] args)
        {
            // Definition der lokalen Variablen
            int sum = 0;
            int number;
            int inputNumber;
            int digit;
            string input;
            System.Console.WriteLine("Summe der ungeraden Ziffern einer Zahl");
            System.Console.WriteLine("======================================");
            Console.Write("Zahl eingeben: ");
            input = Console.ReadLine();
            inputNumber = Convert.ToInt32(input);
            number = inputNumber;
            do
            {
                digit = number % 10;
                if (digit % 2 > 0)
                {
                    sum = sum + digit;
                }
                number = number / 10;
            } while (number > 0);
            Console.WriteLine("Die Summe der ungeraden Ziffern der Zahl {0} ergibt {1}", inputNumber, sum);
            Console.Write("Beenden mit Eingabetaste ...");
            Console.ReadLine();
        }
    }
}
