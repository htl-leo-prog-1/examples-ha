/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Beschreibung:
 * Calculates charge state of a battery
 *--------------------------------------------------------------
 */

using System;

Console.WriteLine("Battery state");
Console.WriteLine("-------------");

Console.Write("Capacity (kWh)                    : ");
double capacity = double.Parse(Console.ReadLine());

Console.Write("High limit (%) [0..100]           : ");
int highLimitP = int.Parse(Console.ReadLine());

Console.Write("Low limit (%) [0..100]            : ");
int lowLimitP = int.Parse(Console.ReadLine());

Console.Write("Current charge level (%) [0..100] : ");
int chargeLevelP = int.Parse(Console.ReadLine());

Console.Write("Charge (kWh)                      : ");
double chargeKw = double.Parse(Console.ReadLine());

double chargeLevelKw = capacity * (chargeLevelP / 100.0);

if (capacity < 0.0 || capacity > 1000.0)
{
    Console.WriteLine("Illegal battery capacity!");
}
else if (highLimitP < 0 || highLimitP > 100)
{
    Console.WriteLine("High limit must be between 0 and 100!");
}
else if (lowLimitP < 0 || lowLimitP > 100)
{
    Console.WriteLine("Low limit must be between 0 and 100!");
}
else if (lowLimitP > highLimitP)
{
    Console.WriteLine("Low limit must be less than high limit");
}
else if (chargeKw <= 0)
{
    Console.WriteLine($"You have charged nothing");
}
else if ((chargeKw + chargeLevelKw) > capacity)
{
    Console.WriteLine($"You cannot charge {chargeKw}. The battery is not big enough.");
}
else
{
    double lowLimitKw = capacity * (lowLimitP / 100.0);
    double highLimitKw = capacity * (highLimitP / 100.0);
    double afterChargedKw = chargeKw + chargeLevelKw;
    int afterChargedP = (int) Math.Round(afterChargedKw / capacity * 100.0,0);

    Console.WriteLine();
    Console.WriteLine($"Capacity       {capacity,5:F1} kWh   100%");
    Console.WriteLine($"High limit     {highLimitKw,5:F1} kWh   {highLimitP,3}%");
    Console.WriteLine($"Low limit      {lowLimitKw,5:F1} kWh   {lowLimitP,3}%");
    Console.WriteLine($"Current        {chargeLevelKw,5:F1} kWh   {chargeLevelP,3}%");
    Console.WriteLine($"After charging {afterChargedKw,5:F1} kWh   {afterChargedP,3}%");

    Console.WriteLine();

    Console.Write("The battery charge level is (after charging) ");

    if (afterChargedP < lowLimitP)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("below the lower limit");
    }
    else if (afterChargedP < highLimitP)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("in the optimum range");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("above the high limit");
    }
    Console.ResetColor();
}