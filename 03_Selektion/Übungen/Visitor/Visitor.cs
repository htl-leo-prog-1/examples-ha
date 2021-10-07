using System;

Console.WriteLine("Berechnung der Ankunftszeit bei der Tante");
Console.WriteLine("=========================================");
Console.WriteLine();

/**
 * Eingabe
 **/
Console.Write("Entfernung in km: ");
string distanceInput = Console.ReadLine();
double distance      = Convert.ToDouble(distanceInput);
Console.Write("Geschwindigkeit in km/h: ");
string velocityInput = Console.ReadLine();
double velocity      = Convert.ToDouble(velocityInput);

/**
 * Verarbeitung
 **/
double time             = distance / velocity;
int    fullHours        = (int)Math.Floor(time);
double remainingMinutes = (time - fullHours) * 60;
int    fullMinutes      = (int)(Math.Floor(remainingMinutes));
double remainingSeconds = (remainingMinutes - fullMinutes) * 60;
fullHours += 10; // Abfahrt ist um 10:00

/**
 * Ausgabe
 **/
Console.WriteLine("Für die Strecke von {0:f} km benötigen Sie {1:f} Stunden.", distance,  time);
Console.WriteLine("Sie kommen um {0}:{1:00}:{2:00} an.",                       fullHours, fullMinutes, remainingSeconds);

if (fullHours < 12)
{
    Console.WriteLine("Es gibt noch ein Mittagessen!");
}
else if (fullHours < 19)
{
    Console.WriteLine("Es gibt Kaffee und Kuchen!");
}
else
{
    Console.WriteLine("Vorsicht, es könnte dunkel werden!");
}

Console.WriteLine();
Console.Write("Zum Beenden Eingabetaste drücken ...");
Console.ReadLine();