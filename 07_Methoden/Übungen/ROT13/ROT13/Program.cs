using System;
using System.Collections.Generic;
using System.Text;

namespace ROT13
{
    class Program
    {
        static void Main(string[] args)
        {
            string plainText;
            string cipherText;
            string ergebnisText;
            char zeichen;
            //int code;
            //zeichen = 'a';       // Zeichen 'a' ==> Codewert 97
            //code = zeichen + 3;
            //zeichen = (char)code;  // Codewert 100 ==> Zeichen 'd'


            Console.WriteLine("Einfache Verschlüsselung nach ROT13");
            Console.Write("Zu verschlüsselnden Text eingeben: ");
            plainText = Console.ReadLine();
            // Verschlüsseln
            ergebnisText = "";
            for (int i = 0; i < plainText.Length; i++)
            {
                // nur Kleinbuchstaben verschlüsseln
                if (plainText[i] >= 'a' && plainText[i] <= 'z')
                {
                    // 13 Positionen vor oder zurück
                    if (plainText[i] + 13 > 'z')
                    {
                        zeichen = (char) (plainText[i] - 13);
                    }
                    else
                    {
                        zeichen = (char) (plainText[i] + 13);
                    }
                }
                else
                {
                    zeichen = plainText[i];
                }
                ergebnisText += zeichen;
            }
            cipherText = ergebnisText;
            // Entschlüsseln
            ergebnisText = "";
            for (int i = 0; i < cipherText.Length; i++)
            {
                // nur Kleinbuchstaben verschlüsseln
                if (cipherText[i] >= 'a' && cipherText[i] <= 'z')
                {
                    // 13 Positionen vor oder zurück
                    if (cipherText[i] + 13 > 'z')
                    {
                        zeichen = (char)(cipherText[i] - 13);
                    }
                    else
                    {
                        zeichen = (char)(cipherText[i] + 13);
                    }
                }
                else
                {
                    zeichen = cipherText[i];
                }
                ergebnisText += zeichen;
            }
            // Ausgabe
            Console.WriteLine("Verschlüsselter Text: " + cipherText);
            Console.WriteLine("Entschlüsselter Text: " + ergebnisText);
            Console.Write("Beenden mit Eingabetaste ...");
            Console.ReadLine();
        }
    }
}
