using System;

Console.WriteLine("Willkommen beim DvD-Verleih \'Happy Hours\'");
Console.WriteLine("=========================================");

Console.Write("Wieviele Tage beträgt die Verleihdauer? ");
int days = Convert.ToInt32(Console.ReadLine());

Console.Write("Wie hoch ist die Verleihgebühr pro Tag? ");
double dailyFee = Convert.ToDouble(Console.ReadLine());

double amount = 0.0;
if (days <= 3)
{
    amount = days * dailyFee;
}
else
{
    amount =  dailyFee * 3;
    amount += (dailyFee * 0.8) * (days - 3);
}

if (amount > 20)
{
    amount = 20;
}

Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"Für {days} Tage sind {amount:f2} Euro zu bezahlen.");

Console.ResetColor();
Console.WriteLine("\nDanke für Ihr Interesse und bis zum nächsten Mal!");