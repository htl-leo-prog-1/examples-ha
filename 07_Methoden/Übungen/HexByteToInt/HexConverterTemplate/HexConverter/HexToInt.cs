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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Wandelt den Hexstring in den zugehörigen Dezimalwert um.
        /// Es können Groß- und Kleinbuchstaben verwendet werden
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns>Zahl im Dezimalsystem oder -1 im Fehlerfall</returns>
        public static int HexByteToInt(string hexString)
        {
            throw new NotImplementedException();
        }
        
    }
}
