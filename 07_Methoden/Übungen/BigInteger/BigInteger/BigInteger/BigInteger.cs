using System;
using System.Collections.Generic;
using System.Text;

namespace BigInteger
{
    /// <summary>
    /// Diese Klasse bietet Methoden an, um sehr große Zahlen addieren und multiplizieren zu können.
    /// </summary>
    public static class BigInteger
    {
        /// <summary>
        /// Gibt die übergebene Eingabeaufforderung auf die Konsole aus und
        /// liest eine beliebig langen Text ein. Besteht der Text nicht ausschließlich
        /// aus Ziffern, so wird eine Fehlermeldung ausgegeben und die Eingabe solange
        /// wiederholt, bis eine gültige Zahl eingegeben wurde.
        /// </summary>
        /// <param name="inputRequest">Eingabeaufforderung als Text</param>
        /// <returns>String bestehend aus beliebig vielen Ziffern</returns>
        public static string ReadBigInteger(string inputRequest)
        {
            return "";
        }

        /// <summary>
        /// Ergänzen eines Strings mit führenden Zeichen
        /// </summary>
        /// <param name="bigInteger">String an den Zeichen vorne angehängt werden sollen</param>
        /// <param name="c">Dieses Zeichen wird vorne an den String gehängt </param>
        /// <param name="count">Wieviele Zeichen sollen angehängt werden</param>
        /// <returns></returns>
        public static string AddLeadingCharacters(string bigInteger, char c, int count)
        {
            return "";
        }

        /// <summary>
        /// Addieren zweier positiver BigInteger-Zahlen als String
        /// </summary>
        /// <param name="a">Erster Summand</param>
        /// <param name="b">Zweiter Summand</param>
        /// <returns>Summe als BigInteger-String</returns>
        public static string AddBigIntegers(string a, string b)
        {
            return "";
        }

        /// <summary>
        /// Multiplizieren einer positiven BigInt-Zahl mit einer einzelnen Ziffer (int)
        /// </summary>
        /// <param name="multiplicand">Multiplikand als BigInteger-Zahl</param>
        /// <param name="digit">Einzelne Ziffer als Multiplikator</param>
        /// <returns>Produkt aus a * digit</returns>
        public static string MultiplyBigIntegerWithDigit(string multiplicand, int digit)
        {
            return "";
        }

        /// <summary>
        /// Multiplizieren zweier positiver BigInt-Zahlen (string mal string)
        /// </summary>
        /// <param name="multiplicand">Multiplikand als BigInteger-Zahl</param>
        /// <param name="multiplicator">Multiplikator als BigInteger-Zahl</param>
        /// <returns>Produkt aus Multiplikand * Multiplikator</returns>
        public static string MultiplyBigIntegers(string multiplicand, string multiplicator)
        {
            return "";
        }
    }
}
