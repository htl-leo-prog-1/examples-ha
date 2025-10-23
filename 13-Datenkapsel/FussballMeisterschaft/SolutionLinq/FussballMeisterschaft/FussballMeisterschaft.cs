/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: FussballMeisterschaft
*--------------------------------------------------------------
*/

using System;

using FussballMeisterschaft;

Console.WriteLine("Fussball-Meisterschaft");
Console.WriteLine("=====================");

string fileName = "Games.csv";

if (args.Length >= 1)
{
    fileName = args[0];
}

var teams = SoccerChampion.GetChampions(fileName);

SoccerChampion.PrintTeams(teams);
