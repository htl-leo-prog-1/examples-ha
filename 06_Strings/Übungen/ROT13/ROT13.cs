/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: <CLASSNAME>
 *--------------------------------------------------------------
 *              Musterlösung - HA
 *--------------------------------------------------------------
 * Description:
 * This program encrypts a given text by shifting only ASCII
 * characters 13 positions to the right (the first half of
 * the range) or to the left (the second half of the range).
 * After encrypting, the encrypted text is decrypted again.
 *--------------------------------------------------------------
 */

using System;

Console.WriteLine("Einfache Verschlüsselung mit ROT13");
Console.Write("Zu verschlüsselnden Text eingeben: ");
string text = Console.ReadLine();
string encrypted = "";
for (int i = 0; i < text.Length; i++)
{
    char fromCh = text[i];
    char toCh = fromCh;

    if (fromCh >= 'a' && fromCh <= 'z')
    {
        toCh = fromCh + 13 > 'z' ? (char) (fromCh - 13) : (char) (fromCh + 13);
    }
    else if (fromCh >= 'A' && fromCh <= 'Z')
    {
        toCh = fromCh + 13 > 'Z' ? (char) (fromCh - 13) : (char) (fromCh + 13);
    }

    encrypted += toCh;
}

Console.WriteLine("Verschlüsselt: " + encrypted);
string decrypted = "";

for (int i = 0; i < encrypted.Length; i++)
{
    char fromCh = encrypted[i];
    char toCh = fromCh;

    if (fromCh >= 'a' && fromCh <= 'z')
    {
        toCh = (char) ('a' + ((fromCh + 13 - 'a') % 26));
    }
    else if (fromCh >= 'A' && fromCh <= 'Z')
    {
        toCh = (char) ('A' + ((fromCh + 13 - 'A') % 26));
    }

    decrypted += toCh;
}

Console.WriteLine("Entschlüsselt: " + decrypted);