/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: <CLASSNAME>
 *--------------------------------------------------------------
 *              Birgit Schröder
 *--------------------------------------------------------------
 * Description:
 * This program encrypts a given text by shifting only ASCII
 * characters 13 positions to the right (the first half of 
 * the range) or to the left (the second half of the range).
 * After encrypting, the encrypted text is decrypted again.
 *--------------------------------------------------------------
*/
using System;

namespace Rot13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Einfache Verschlüsselung mit ROT13");
            Console.Write("Zu verschlüsselnden Text eingeben: ");
            string text = Console.ReadLine();
            string encrypted = "";
            for (int i = 0; i < text.Length; i++)
            {
                int c = (int)text[i];
                if ((c >= 97 && c <= 109) || (c >= 65 && c <= 77))
                {
                    encrypted += (char)(c + 13);
                }
                else if ((c >= 110 && c <= 122) || (c >= 78 && c <= 90))
                {
                    encrypted += (char)(c - 13);
                }
                else
                {
                    encrypted += (char)c;
                }
            }
            Console.WriteLine("Verschlüsselt: " + encrypted);
            string decrypted = "";

            for (int i = 0; i < encrypted.Length; i++)
            {
                int c = (int)encrypted[i];
                if ((c >= 97 && c <= 109) || (c >= 65 && c <= 77))
                {
                    decrypted += (char)(c + 13);
                }
                else if ((c >= 110 && c <= 122) || (c >= 78 && c <= 90))
                {
                    decrypted += (char)(c - 13);
                }
                else
                {
                    decrypted += (char)c;
                }
            }
            Console.WriteLine("Entschlüsselt: " + decrypted);
            Console.ReadKey();
        }
    }
}
