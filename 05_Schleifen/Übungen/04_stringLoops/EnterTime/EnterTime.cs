/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: EnterTime
* Convert time from format hh:mm:ss
*--------------------------------------------------------------
*/

using System;

Console.WriteLine("Convert Time ");
Console.WriteLine("****************************");

string timeToConvert;

do
{
    Console.Write("Please enter time (format hh:mm:ss): ");
    timeToConvert = Console.ReadLine();

    if (timeToConvert.Length > 0)
    {
        int    colonCount = 0;
        string hourStr    = "";
        string minStr     = "";
        string secStr     = "";

        bool isValid = true;

        for (int i = 0; i < timeToConvert.Length && isValid; i++)
        {
            var ch = timeToConvert[i];
            if (ch == ':')
            {
                colonCount++;
            }
            else if (char.IsDigit(ch))
            {
                switch (colonCount)
                {
                    case 0:
                        hourStr += ch;
                        break;
                    case 1:
                        minStr += ch;
                        break;
                    case 2:
                        secStr += ch;
                        break;
                }
            }
            else
            {
                isValid = false;
            }
        }

        int hour   = 0;
        int minute = 0;
        int second = 0;

        if (!isValid || hourStr.Length != 2 || !int.TryParse(hourStr, out hour) || hour < 0 || hour > 23)
        {
            isValid = false;
        }
        else if (!isValid || minStr.Length != 2 || !int.TryParse(minStr, out minute) || minute < 0 || minute > 59)
        {
            isValid = false;
        }
        else if (!isValid || secStr.Length != 2 || !int.TryParse(secStr, out second) || second < 0 || second > 59)
        {
            isValid = false;
        }

        if (isValid)
        {
            Console.WriteLine($"{timeToConvert}: hour:{hour}, minute:{minute}, second:{second}");
        }
        else
        {
            Console.WriteLine("invalid format");
        }
    }
} while (timeToConvert.Length > 0);