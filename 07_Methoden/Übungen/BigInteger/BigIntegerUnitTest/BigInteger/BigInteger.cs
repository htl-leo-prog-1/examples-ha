/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: BigInteger
 *--------------------------------------------------------------
 */

using System;

namespace BigInteger
{
    public class BigInteger
    {
        public static bool IsValidBigInteger(string str)
        {
            bool isOK = !string.IsNullOrEmpty(str);

            for (int i = 0; i < str.Length && isOK; i++)
            {
                if (!char.IsDigit(str[i]))
                {
                    isOK = false;
                }
            }

            return isOK;
        }

        public static string ReadBigInteger(string inputRequestMessage)
        {
            string input;
            bool   isOk;

            do
            {
                Console.Write(inputRequestMessage);
                input = Console.ReadLine();
                isOk  = IsValidBigInteger(input);

                if (!isOk)
                {
                    Console.WriteLine("Illegal number!");
                }
            } while (!isOk);

            return input;
        }

        private static int GetDigit(string bigInteger, int position)
        {
            // e.g.: GetDigit("123",0) => 3
            // e.g.: GetDigit("123",1) => 2
            // e.g.: GetDigit("123",10) => 0  (return 0 if not exist) 
            int idx = bigInteger.Length - 1 - position;
            return idx >= 0 ? bigInteger[idx] - '0' : 0;
        }

        public static string AddBigIntegers(string a, string b)
        {
            int maxLength = Math.Max(a.Length, b.Length);

            int    carry  = 0;
            string result = string.Empty;

            for (int i = 0; i < maxLength; i++)
            {
                int sumOfCurrentDigits = GetDigit(a, i) + GetDigit(b, i) + carry;

                result = (sumOfCurrentDigits % 10) + result;
                carry  = sumOfCurrentDigits / 10;
            }

            if (carry > 0)
            {
                result = carry + result;
            }

            return result;
        }

        public static string MultiplyBigIntegerWithDigit(string multiplicand, int digit)
        {
            if (digit > 9 || digit <= 0)
            {
                return "0";
            }

            string result = string.Empty;
            int    carry  = 0;
            for (int i = 0; i < multiplicand.Length; i++)
            {
                int productOfCurrentDigits = GetDigit(multiplicand, i) * digit + carry;
                result = (productOfCurrentDigits % 10) + result;
                carry  = productOfCurrentDigits / 10;
            }

            if (carry > 0)
            {
                result = carry + result;
            }

            return result;
        }

        private static string MultiplyBigIntegerWith10(string bigInteger)
        {
            return bigInteger + "0";
        }

        public static string MultiplyBigIntegers(string multiplicand, string multiplier)
        {
            string result = string.Empty;
            for (int i = 0; i < multiplier.Length; i++)
            {
                string product = MultiplyBigIntegerWithDigit(multiplicand, multiplier[i] - '0');
                result = AddBigIntegers(MultiplyBigIntegerWith10(result), product);
            }

            return result;
        }
    }
}