using System;

namespace Lohnsteuer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lohnsteuerrechner");
            Console.WriteLine("=================");

            Console.Write("Jahreseinkommen: ");
            double income = Convert.ToDouble(Console.ReadLine());

            double tax = 0.0;

            if (income > 11000 && income <= 18000)
            {
                tax = (income - 11000) * 25 / 100;
            }
            else if (income > 18000 && income <= 31000)
            {
                tax = (income - 18000) * 35 / 100 + 1750;
            }
            else if (income > 31000 && income <= 60000)
            {
                tax = (income - 31000) * 42 / 100 + 6300;
            }
            else if (income > 60000 && income <= 90000)
            {
                tax = (income - 60000) * 48 / 100 + 18480;
            }
            else if (income > 90000 && income <= 1000000)
            {
                tax = (income - 90000) * 50 / 100 + 32880;
            }
            else if (income > 1000000)
            {
                tax = (income - 1000000) * 55 / 100 + 487880;
            }
            Console.WriteLine($"Für ein Jahreseinkommen von {income:f2} Euro müssen {tax:f2} Euro Lohnsteuer bezahlt werden.");

            Console.ReadKey();
        }
    }
}
