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
 * Advanced Version: it is possible to specify the offset (const)
 *--------------------------------------------------------------
 */

using System;

const int CharCount = 'Z' - 'A' + 1;
const int OffsetEncrypt = 13;
const int OffsetDecrypt = -OffsetEncrypt;

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
        // Version 1: check, if result is <= 'z' => add offset, else sub offset (=26-offset)
        toCh = fromCh + OffsetEncrypt > 'z' ? (char) (fromCh - (CharCount - OffsetEncrypt)) : (char) (fromCh + OffsetEncrypt);
    }
    else if (fromCh >= 'A' && fromCh <= 'Z')
    {
        toCh = fromCh + OffsetEncrypt > 'Z' ? (char) (fromCh - (CharCount - OffsetEncrypt)) : (char) (fromCh + OffsetEncrypt);
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
        // Version 2: use modulo operator: we have to add 26 because offset can be negative (-25..25)
        toCh = (char) ('a' + (fromCh + OffsetDecrypt - 'a' + CharCount) % CharCount);
    }
    else if (fromCh >= 'A' && fromCh <= 'Z')
    {
        toCh = (char) ('A' + (fromCh + OffsetDecrypt - 'A' + CharCount) % CharCount);
    }

    decrypted += toCh;
}

Console.WriteLine("Entschlüsselt: " + decrypted);