using System;

namespace CreditcardChecker
{
    public class Program
    {
        public const int CARDNUMBERLENGHT = 16;

        public static void Main()
        {
            Console.WriteLine("Programm wird über Unittests gestartet!");
            Console.Write("Beenden mit Eingabetaste ...");
            Console.ReadLine();
        }

        /// <summary>
        /// Diese Methode überprüft eine Kredikartennummer, ob diese gültig 
        /// ist. Regeln entsprechend der Angabe
        /// </summary>
        /// <param name="creditCardNumber">Die zu überprüfende Kartennummer</param>
        /// <returns>True falls die Kartennummer gültig ist, false sonst</returns>
        public static bool IsCreditCardValid(string creditCardNumber)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Berechnet aus der Summe der geraden Stellen (bereits verdoppelt) und der
        /// Summe der ungeraden Stellen die Checkziffer
        /// </summary>
        /// <param name="oddSum"></param>
        /// <param name="evenSum"></param>
        /// <returns></returns>
        public static int CalculateCheckDigit(int oddSum, int evenSum)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Berechnet die Ziffernsumme einer Zahl
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Ziffernsumme der Zahl</returns>
        public static int CalculateDigitSum(int number)
        {
            throw new NotImplementedException();
        }
    }
}
