/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: xABIF
 *--------------------------------------------------------------
 *              Herbert Aitenbichler 
 *--------------------------------------------------------------
 * Description: Berechnung der Lohnsteuer (ohne Verzweigung)
 *--------------------------------------------------------------
*/

using System;

Console.WriteLine("**********************************");
Console.WriteLine("Berechnung der Lohnsteuer für 2021");
Console.WriteLine("**********************************");
Console.Write("Jahreseinkommen in Euro: ");
string textInput = Console.ReadLine();

double totalIncome = double.Parse(textInput);
double income      = totalIncome;
double tax         = 0.0;
double incomeInTaxGroup;

incomeInTaxGroup = Math.Max(income - 1000000.0, 0);
tax              = tax + incomeInTaxGroup * 0.55;
income           = Math.Min(1000000.0, income);

incomeInTaxGroup = Math.Max(income - 90000.0, 0);
tax              = tax + incomeInTaxGroup * 0.5;
income           = Math.Min(90000.0, income);

incomeInTaxGroup = Math.Max(income - 60000.0, 0);
tax              = tax + incomeInTaxGroup * 0.48;
income           = Math.Min(60000.0, income);

incomeInTaxGroup = Math.Max(income - 31000.0, 0);
tax              = tax + incomeInTaxGroup * 0.42;
income           = Math.Min(31000.0, income);

incomeInTaxGroup = Math.Max(income - 18000.0, 0);
tax              = tax + incomeInTaxGroup * 0.35;
income           = Math.Min(18000.0, income);

incomeInTaxGroup = Math.Max(income - 11000.0, 0);
tax              = tax + incomeInTaxGroup * 0.20;
income           = Math.Min(11000.0, income);

Console.WriteLine($"Im Jahr 2021 muss für ein Jahreseinkommen von {totalIncome:f2} Euro {tax:f2} Euro Steuer bezahlt werden. ");