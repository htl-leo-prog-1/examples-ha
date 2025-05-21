/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Color Values
* 32 bit colors
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Colors and there values");
Console.WriteLine("**************");

string userInput;

do
{
    Console.Write("Please enter a number (empty to exit): ");
    userInput = Console.ReadLine();

    string hexCoding = "0123456789ABCDEF";

    if (!string.IsNullOrEmpty(userInput))
    {
        uint decValue = uint.Parse(userInput);

        string hexString = "";

        for (int i = 0; i < 8; i++)
        {
            hexString = hexCoding[(int)(decValue % 16)] + hexString;
            decValue /= 16;
        }

        Console.WriteLine($"Dec: {userInput}, Hex: #{hexString}");
    }
} while (!string.IsNullOrEmpty(userInput));