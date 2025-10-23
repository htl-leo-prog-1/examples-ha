using System;
using System.Threading;

namespace CashMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            const int PIN_CODE = 1234;
            const double ACCOUNT_BALANCE = 1000.0;         // Derzeitiger Kontostand
            const double OVERDRAFT_FACILITY = 100.0;       // Überziehungsrahmen
            const int MONEY_AVAILABLE = 700;               // Derzeitiger Bargeldvorrat im Bankomat


            Console.Write("PIN: ");
            int pin = Convert.ToInt32(Console.ReadLine());
            int remainingTries = 2;
            while (pin != PIN_CODE && remainingTries > 0)
            {
                string message = $"Falscher Pincode! Noch {remainingTries} Versuch";
                if (remainingTries > 1)
                {
                    message += "e";
                }
                PrintError(message + "!");
                remainingTries--;
                Console.Write("PIN: ");
                pin = Convert.ToInt32(Console.ReadLine());
            }

            if (pin != PIN_CODE)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                PrintError("Es wurde 3 mal der falsche PIN eingegeben, die Karte wird einbehalten!");
                Console.ResetColor();
            }
            else
            {
                Console.Write("Wieviel wollen Sie abheben? ");
                int amount = Convert.ToInt32(Console.ReadLine());
                if (amount > ACCOUNT_BALANCE + OVERDRAFT_FACILITY)
                {
                    PrintError("Gewünschter Geldbetrag übersteigt Ihren Überziehungsrahmen!");
                }
                else if (amount > MONEY_AVAILABLE)
                {
                    PrintError("Gewünschter Geldbetrag ist nicht vorrätig!");
                }
                else
                {

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n\nAuszahlung:                {amount,10:f2}");
                    Console.WriteLine($"Verbleibender Kontostand:  {(ACCOUNT_BALANCE - amount),10:f2}");
                    Console.ResetColor();
                }
            }

            Console.WriteLine();
            Console.WriteLine("Drücken Sie eine Taste zum Beenden ...");
            Console.ReadKey();
        }

        private static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
