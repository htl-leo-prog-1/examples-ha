/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: xABIF
 *--------------------------------------------------------------
 *              Herbert Aitenbichler 
 *--------------------------------------------------------------
 * Description:
 * Lohnsteuer mal ganz anders (LINQ)
 *--------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Linq;

Console.WriteLine("**********************************");
Console.WriteLine("Berechnung der Lohnsteuer für ein Jahr");
Console.WriteLine("**********************************");
Console.Write("Jahreseinkommen in Euro: ");

var textInput   = Console.ReadLine();
var totalIncome = double.Parse(textInput);

Console.Write("Jahr für die Berechnung: ");
textInput  = Console.ReadLine();
var year   = int.Parse(textInput);

var income = totalIncome;
var tax = new List<(int yearFrom, int yearTo, double rate, double range)>()
    {
        new(2016, 2019, 0.25, 11000.0),
        new(2016, 2019, 0.35, 18000.0),
        new(2016, 2019, 0.42, 31000.0),
        new(2016, 2019, 0.48, 60000.0),
        new(2016, 2019, 0.50, 90000.0),
        new(2016, 2019, 0.55, 1000000.0),
        new(2020, 2999, 0.20, 11000.0),
        new(2020, 2999, 0.35, 18000.0),
        new(2020, 2999, 0.42, 31000.0),
        new(2020, 2999, 0.48, 60000.0),
        new(2020, 2999, 0.50, 90000.0),
        new(2020, 2025, 0.55, 1000000.0),
    }.Where(x => x.yearFrom <= year && x.yearTo >= year)
    .OrderByDescending(x => x.range)
    .Select(x => new { Rate = x.rate, InComeInGroupe = Math.Max(income - x.range, 0.0), Rest = (income = Math.Min(income, x.range)) })
    .Sum(x => x.InComeInGroupe * x.Rate);

Console.WriteLine($"Im Jahr {year} muss für ein Jahreseinkommen von {totalIncome:f2} Euro {tax:f2} Euro Steuer bezahlt werden. ");