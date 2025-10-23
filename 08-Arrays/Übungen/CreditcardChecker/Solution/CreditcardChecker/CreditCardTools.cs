/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: CreditcardChecker
*--------------------------------------------------------------
*/

namespace CreditcardChecker;

using System;

public class CreditCardTools
{
    public const int CARDNUMBERLENGHT = 16;

    /// <summary>
    /// Diese Methode überprüft eine Kredikartennummer, ob diese gültig 
    /// ist. Regeln entsprechend der Angabe
    /// </summary>
    /// <param name="creditCardNumber">Die zu überprüfende Kartennummer</param>
    /// <returns>True falls die Kartennummer gültig ist, false sonst</returns>
    public static bool IsCreditCardValid(string creditCardNumber)
    {
        if (creditCardNumber.Length != CARDNUMBERLENGHT || OnlyContainsDigits(creditCardNumber) == false)
        {
            return false;
        }

        int oddSum = 0;
        int evenSum = 0;
        for (int i = 0; i < creditCardNumber.Length - 1; i++)
        {
            int digit = creditCardNumber[i] - '0';
            if (i % 2 == 0)
            {
                evenSum += CalculateDigitSum(digit * 2);
            }
            else
            {
                oddSum += digit;
            }
        }


        int chkDigit = CalculateCheckDigit(oddSum, evenSum);

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
        if ((oddSum + evenSum) % 10 != 0)
        {
            chkDigit = 10 - ((oddSum + evenSum) % 10);
        }

        return chkDigit;
    }

    /// <summary>
    /// Berechnet die Ziffernsumme einer Zahl.
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static int CalculateDigitSum(int number)
    {
        number = Math.Abs(number);

        int sum = 0;
        do
        {
            sum += number % 10;
            number = number / 10;
        } while (number != 0);

        return sum;
    }

    private static bool OnlyContainsDigits(string creditCardNumber)
    {
        foreach (char ch in creditCardNumber)
        {
            if (Char.IsDigit(ch) == false)
            {
                return false;
            }
        }

        return true;
    }
}