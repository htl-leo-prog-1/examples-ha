/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: EMQualification
*--------------------------------------------------------------
*/

namespace EMQualification;

using System;
using System.IO;
using System.Text;

public class Program
{
    const string FILENAME = "Games.csv";

    static void Main(string[] args)
    {
        Console.WriteLine("EM-Qualifikation 2020");
        Console.WriteLine("=====================");

        //TODO: Implement main method here: readCSV, print all, repeat: ask user and print result
    }

    public static Game[] ReadGamesFromFile(string fileName)
    {
        //TODO: implement method ReadGamesFromFile 
    }

    public static void CountGoals(Game[] games, string countryName, out int goals, out int gotGoals)
    {
        //TODO: implement method CountGoals 
    }

    public static Game[] FilterGamesByCountryName(Game[] games, string countryName)
    {
        //TODO: implement method FilterGamesByCountryName 
    }

    private static Game[] Copy(Game[] src, int count)
    {
        var dest = new Game[count];
        for (int i = 0; i < count; i++)
        {
            dest[i] = src[i];
        }

        return dest;
    }
}