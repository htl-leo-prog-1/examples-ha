using System;

namespace SonderausgabenRechner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Jahreseinkommen: ");
            double income = Convert.ToDouble(Console.ReadLine());
            Console.Write("Sonderausgaben: ");
            double extraExpenses = Convert.ToDouble(Console.ReadLine());

            double taxReduction = (60000 - income) * (extraExpenses / 4 - 60) / 23600 + 60;

            Console.WriteLine($"Anrechenbare Sonderausgaben: {taxReduction}");
            Console.ReadLine();

        }
    }
}
