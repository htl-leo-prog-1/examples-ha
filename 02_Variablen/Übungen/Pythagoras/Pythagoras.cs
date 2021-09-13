using System;

namespace Pythagoras
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Willkommen beim Pythagoras-Rechner!");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Geben Sie die Länge der Seite a ein: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Geben Sie die Länge der Seite b ein: ");
            double b = Convert.ToDouble(Console.ReadLine());

            double c = Math.Sqrt(a * a + b * b);
            double p = a * a / c;
            double q = c - p;
            double h = Math.Sqrt(p * q);
            double area = c * h / 2;

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"Seitenlänge c:            {c,10:f3}");           
            Console.WriteLine($"Hypotenusenabschnitt p:   {p,10:f3}");          
            Console.WriteLine($"Hypotenusenabschnitt q:   {q,10:f3}");           
            Console.WriteLine($"Höhe h:                   {h,10:f3}");          
            Console.WriteLine($"Flächeninhalt A:          {area,10:f3}");


            Console.ResetColor();
            Console.ReadKey();




        }
    }
}
