using System;

double nettoPreis;
int    stueckZahl;
string geschenkOption;
string land;

const double GESCHENKOPTION_PREIS = 2.50;
const int    MWST_DE              = 19;
const int    MWST_AT              = 20;
const double VERSANDKOSTEN        = 5.90;
const double MINIMUM              = 29.0;

Console.WriteLine("Shopping Cart");

Console.Write("Netto-Stückpreis: ");
nettoPreis = Convert.ToDouble(Console.ReadLine());
Console.Write("Stückzahl: ");
stueckZahl = Convert.ToInt32(Console.ReadLine());
Console.Write("Geschenkoption (ja / nein)? ");
geschenkOption = Console.ReadLine();
Console.Write("Lieferung nach de oder at? ");
land = Console.ReadLine();

double gesamtPreis = nettoPreis * stueckZahl;

if (geschenkOption == "ja")
{
    gesamtPreis = gesamtPreis + (GESCHENKOPTION_PREIS * stueckZahl);
}

double mwst = 0.0;
switch (land)
{
    case "de":
        mwst = MWST_DE;
        break;
    case "at":
        mwst = MWST_AT;
        break;
    default:
        Console.WriteLine("Achtung - Mehrwertsteuersatz konnte nicht ermittelt werden. Falsche Eingabe: " + land);
        break;
}

gesamtPreis = gesamtPreis * (100 + mwst) / 100;

if (gesamtPreis < MINIMUM)
{
    gesamtPreis = gesamtPreis + VERSANDKOSTEN;
}

Console.WriteLine("Gesamtpreis: EUR {0:0.00}", gesamtPreis);
Console.WriteLine("Mwst: EUR {0:0.00}",        (gesamtPreis / (100 + mwst) * (mwst)));