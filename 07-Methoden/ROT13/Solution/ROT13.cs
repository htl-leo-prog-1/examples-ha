/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: ROT13
*--------------------------------------------------------------
*/

using System;

char EncodeChar(char fromCh)
{
    char toCh;
    // nur Kleinbuchstaben verschlüsseln
    if (fromCh >= 'a' && fromCh <= 'z')
    {
        // 13 Positionen vor oder zurück
        if (fromCh + 13 > 'z')
        {
            toCh = (char) (fromCh - 13);
        }
        else
        {
            toCh = (char) (fromCh + 13);
        }
    }
    else
    {
        toCh = fromCh;
    }

    return toCh;
}

string Decode(string plainText)
{
    return Encode(plainText);
}

string Encode(string plainText)
{
    string encode = "";

    for (int i = 0; i < plainText.Length; i++)
    {
        char fromCh = plainText[i];
        encode += EncodeChar(fromCh);
    }

    return encode;
}

Console.WriteLine("Encryption/Decryption with ROT13");
Console.Write("Please enter a text: ");
string plainText = Console.ReadLine();

string encodedText = Encode(plainText);
string plainAgainText = Decode(encodedText);

Console.WriteLine($"Plain:     {plainText}");
Console.WriteLine($"Encrypted: {encodedText}");
Console.WriteLine($"Decrypted: {plainAgainText}");