/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: CharCount
* unsigned 32bit to hex
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Convert To Hex");
Console.WriteLine("**************");

string userInput;

do
{
    Console.Write("Please enter a number (empty to exit): ");
    userInput = Console.ReadLine();

    uint decValue;
    var hexCoding = "0123456789ABCDEF";

    if (!string.IsNullOrEmpty(userInput) && uint.TryParse(userInput, out decValue))
    {
        string hexString = "";

        for (int i = 0; i < 8; i++)
        {
            if (i != 0 && (i % 2) == 0)
            {
                hexString = " " + hexString;
            }

            hexString = hexCoding[(int)(decValue % 16)] + hexString;
            decValue /= 16;
        }

        Console.WriteLine($"Dec: {userInput}, Hex: {hexString}");
    }
} while (!string.IsNullOrEmpty(userInput));