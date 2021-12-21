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
            // Länge überprüfen
            if (creditCardNumber.Length != CARDNUMBERLENGHT)
            {
                return false;
            }

            // Prüfen, ob nur Ziffern in der Zeichenfolge enthalten sind.
            int index = 0;
            while (index < creditCardNumber.Length)
            {
                if (Char.IsDigit(creditCardNumber[index]) == false)
                {
                    return false;
                }
                index = index + 1; // == idx++;
            }
            // Ermitteln der Summen (gerader und ungerader Stellen)
            int oddSum = 0;
            int evenSum = 0;
            for (int i = 0; i < creditCardNumber.Length - 1; i++)
            {
                int digit = creditCardNumber[i] - '0';
                if (i % 2 == 0)
                {
                    evenSum += CalculateDigitSum(digit * 2);  // liefert 0 - 9 => 0*2=>0, 9*2=18 => 9
                }
                else
                {
                    oddSum += digit;
                }
            }
            // Prüfziffer ermitteln
            int chkDigit = CalculateCheckDigit(oddSum, evenSum);
            // Prüfziffer mit der letzten Ziffer in der Kreditkartennummer vergleichen
            return chkDigit == (creditCardNumber[creditCardNumber.Length - 1] - '0');
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
            int chkDigit = 0;
            if ((oddSum + evenSum) % 10 != 0)  // 0 bleibt erhalten
                chkDigit = 10 - ((oddSum + evenSum) % 10);
            return chkDigit;
        }

        /// <summary>
        /// Berechnet die Ziffernsumme einer Zahl
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Ziffernsumme der Zahl</returns>
        public static int CalculateDigitSum(int number)
        {
            int sum = 0;
            do
            {
                sum += number % 10;
                number = number / 10;
            } while (number != 0);
            return sum;
        }
    }
}
