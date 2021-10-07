using System;

// Eingabe
Console.WriteLine("Umrechnung Celsius => Fahrenheit");
Console.WriteLine("================================");
Console.Write("Eingabe Grad Celsius: ");
double celsius = Convert.ToDouble(Console.ReadLine());

// Verarbeitung
double fahrenheit = celsius * 9.0 / 5.0 + 32;

// Ausgabe
Console.WriteLine();
Console.WriteLine("Umrechnungsergebnis:");
Console.WriteLine("--------------------");
Console.WriteLine("Celsius:    {0,8:f1}  ", celsius);
Console.WriteLine("Fahrenheit: {0,8:f1}  ", fahrenheit);

Console.WriteLine();
Console.Write("Zum Beenden Eingabetaste drücken ...");
Console.ReadKey();