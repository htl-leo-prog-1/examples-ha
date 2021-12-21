using System;
using System.Collections.Generic;
using System.Text;

namespace HexConverter
{
    public class HexToInt
    {
        /// <summary>
        /// Überprüft, ob der Buchstabe ein gültiges Hexzeichen 
        /// 0-9, A-F ist.
        /// Es sind auch Kleinbuchstaben zulässig
        /// </summary>
        /// <param name="hexChar"></param>
        /// <returns>Ist das Zeichen ein gültiges Hex-Zeichen</returns>
        public static bool IsHexChar(char hexChar)
        {
            hexChar = Char.ToUpper(hexChar);
            return (hexChar >= '0' && hexChar <= '9') ||
                   (hexChar >= 'A' && hexChar <= 'F');
        }

        /// <summary>
        /// Überprüft, ob der String ein gültiges
        /// Hexbyte darstellt (2 Stellen, 0-9 und A-F)
        /// Es sind Groß- und Kleinbuchstaben zulässig
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns>Ist der Hexstring gültig</returns>
        public static bool IsHexByteString(string hexString)
        {
            hexString = hexString.ToUpper();
            if (hexString.Length != 2)
            {
                return false;
            }
            return IsHexChar(hexString[0]) && IsHexChar(hexString[1]);
        }

        /// <summary>
        /// Das übergebene Hexzeichen wird in den jeweiligen 
        /// Dezimalwert umgerechnet.
        /// Für ungültige Hexzeichen wird -1 zurückgegeben
        /// </summary>
        /// <param name="hexChar"></param>
        /// <returns>Zahlenwert im Dezimalsystem oder -1 im Fehlerfall</returns>
        public static int HexCharToInt(char hexChar)
        {
            hexChar = Char.ToUpper(hexChar);
            if (hexChar >= 'A' && hexChar <= 'F')
            {
                return 10 + hexChar - 'A';
            }
            if (hexChar >= '0' && hexChar <= '9')
            {
                return hexChar - '0';
            }
            return -1;
        }

        /// <summary>
        /// Wandelt den Hexstring in den zugehörigen Dezimalwert um.
        /// Es können Groß- und Kleinbuchstaben verwendet werden
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns>Zahl im Dezimalsystem oder -1 im Fehlerfall</returns>
        public static int HexByteToInt(string hexString)
        {
            if (!IsHexByteString(hexString))
            {
                return -1;
            }
            return HexCharToInt(hexString[0]) * 16 + HexCharToInt(hexString[1]);
        }





        
    }
}
