/// 
/// Unit 11 - Methods: Big Integers
/// 1AHIF, 2014/15
/// Best practice example
///       

using System;

namespace BigInt
{
    public class MainClass
    {

        public static void Main()
        {
            string proceed;
            do
            {
                string number1 = ReadBigInteger("Geben Sie die 1. Zahl ein: ");
                string number2 = ReadBigInteger("Geben Sie die 2. Zahl ein: ");
                Console.WriteLine();
                Console.WriteLine("Summe der Zahlen:\n" + AddBigIntegers(number1, number2));
                Console.WriteLine();
                Console.WriteLine("Produkt der Zahlen:\n" + MultiplyBigIntegers(number1, number2));
                Console.WriteLine();
                Console.WriteLine("Weiter mit \"j\"");
                proceed = Console.ReadLine();
            } while (proceed == "j");
        }

        /// <summary>
        /// Liest eine beliebig lange Zahl ein und speichert diese in einen String
        /// Wiederholt die Eingabe, solange ungültige Zahl eingegeben wird
        /// </summary>
        /// <param name="text">Eingabeaufforderung als Text</param>
        /// <returns></returns>
        public static string ReadBigInteger(string inputRequest)
        {
            string input;
            bool illegalNumber;
            do
            {
                Console.Write(inputRequest);
                input = Console.ReadLine();
                illegalNumber = false;
                for (int i = 0; i < input.Length; i++)
                {
                    if (!(input[i] >= '0' && input[i] <= '9'))  //Alternative !Char.IsDigit(input[i])
                    {
                        //Keine Ziffer
                        illegalNumber = true;
                        Console.WriteLine("Ungültige Zahl! Eingabe wiederholen!");
                        break; //Seltene Form, in der break ok ist
                    }
                }
            } while (illegalNumber); //Eingabe wiederholen, solange keine Zahl eingegeben wurde
            return input;
        }
            
        /// <summary>
        /// Addieren zweier positiver BigInt-Zahlen als String
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string AddBigIntegers(string a, string b)
        {
            // a und b auf gleiche Länge bringen (führende 0)
            if (a.Length < b.Length)
            {
                a = AddLeadingCharacters(a, '0', b.Length - a.Length);
            }
            else
            {
                b = AddLeadingCharacters(b, '0', a.Length - b.Length);
            }
            int sumOfCurrentDigits;
            int carry = 0;
            string result = "";
            // Stellenweise addieren und Übertrag berücksichtigen
            for (int i = a.Length - 1; i >= 0; i--)
            {
                sumOfCurrentDigits = (a[i] - '0') + (b[i] - '0') + carry;
                result = Convert.ToString(sumOfCurrentDigits % 10) + result;
                carry = sumOfCurrentDigits / 10;   // 10er Stelle -> Uebertrag
            }
            if (carry == 1)
            {
                result = "1" + result;
            }
            return result;
        }

        /// <summary>
        /// Multiplizieren einer positiven BigInt-Zahl mit einer Ziffer (int)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string MultiplyBigIntegerWithDigit(string a, int b)
        {
            string result = "";
            int carry = 0;
            int productOfCurrentDigits = 0;
            for (int i = a.Length - 1; i >= 0; i--)
            {
                productOfCurrentDigits = ((a[i] - '0') * b) + carry;
                result = Convert.ToString(productOfCurrentDigits % 10) + result;
                carry = productOfCurrentDigits / 10;   // 10er Stelle -> Uebertrag
            }
            if (carry > 0)
            {
                result = Convert.ToString(carry) + result;
            }
            return result;
        }

        /// <summary>
        /// Multiplizieren zweier positiver BigInt-Zahlen (string mal string)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string MultiplyBigIntegers(string multiplicand, string multiplicator)
        {
            string currentProduct = multiplicand;
            string result = "";
            for (int i = 0; i < multiplicator.Length; i++)
            {
                currentProduct = MultiplyBigIntegerWithDigit(multiplicand, multiplicator[i] - '0');
                result = AddBigIntegers(result + "0", currentProduct);
            }
            return result;
        }
 

        /// <summary>
        /// Ergänzen eines Strings mit führenden Zeichen
        /// </summary>
        /// <param name="s">String an den Zeichen vorne angehängt werden sollen</param>
        /// <param name="c">Dieses Zeichen wird vorne an den String gehängt </param>
        /// <param name="anz">Wieviele Zeichen sollen angehängt werden</param>
        /// <returns></returns>
        public static string AddLeadingCharacters(string s, char c, int anz)
        {
            for (int i = 1; i <= anz; i++)
            {
                s = c + s;
            }
            return s;
        }
    }



}
