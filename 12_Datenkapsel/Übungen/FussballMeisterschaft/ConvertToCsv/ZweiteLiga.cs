/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: ZweiteLiga
*--------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;

Console.WriteLine("Read ZweiteLiga.txt");


using (var sr = new StreamReader("ZweiteLiga.txt"))
{
    var line = sr.ReadLine();

    bool newGame = false;
    int runde = 0;
    int idx = 0;
    var game = new Game();
    var outLines = new List<string>()
    {
        "Round;Date;HomeTeam;GuestTeam;Score;ScoreHalfTime"
    };

    while (line != null)
    {
        if (!string.IsNullOrEmpty(line))
        {
            if (line.StartsWith("Runde "))
            {
                runde = int.Parse(line.Replace("Runde ", ""));
                //Console.WriteLine($"Runde {runde}");
                idx = 0;
            }
            else if (line.StartsWith("Spielbericht"))
            {
                if (game.Result != "-:-")
                {
                    var outLine =
                        $"{runde};{game.Date.ToString("d/M/yyyy HH:mm")};{game.HomeTeam};{game.GuestTeam};{game.Result};{game.Result2}";
                    Console.WriteLine(outLine);
                    outLines.Add(outLine);
                }

                game = new Game();
                idx = 0;
            }
            else
            {
                switch (idx)
                {
                    case 0:
                        game.Date = DateTime.ParseExact(line.Replace(" Uhr", "").Replace(",", ""), "d.MM.yyyy H:m",
                            CultureInfo.InvariantCulture);
                        break;
                    case 1:
                        game.HomeTeam = line;
                        break;
                    case 2:
                        game.Result = line;
                        break;
                    case 3:
                        game.Result2 = line;
                        break;
                    case 4:
                        game.GuestTeam = line;
                        break;
                    default:
                        throw new ArgumentException();
                }

                idx++;
            }
        }

        line = sr.ReadLine();
    }

    File.WriteAllLines("ZweiteLiga.csv", outLines);
}