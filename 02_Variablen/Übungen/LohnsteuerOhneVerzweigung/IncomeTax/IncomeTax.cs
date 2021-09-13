using System;
using System.Collections.Generic;

namespace IncomeTax
{
	class Program
	{
		public static void Main(string[] args)
		{
			string textInput;
			double yearlyIncome;
			double taxableIncome;  // wie viel bleibt nach einer Steuerklasse noch zu versteuern übrig
			double incomeInArea;
			double taxInArea;
			double tax;
			// Eingabe
			Console.WriteLine("Berechnung der Lohnsteuer vor der Steuerreform");
			Console.Write("Jahreseinkommen in Euro: ");
			textInput = Console.ReadLine();
			yearlyIncome = Convert.ToDouble(textInput);
			taxableIncome = yearlyIncome;
            // Berechnung der Steuer

            incomeInArea = Math.Max(taxableIncome - 60000.0, 0);
            taxInArea = incomeInArea * 0.5;
            tax = taxInArea;
            taxableIncome = Math.Min(60000.0, taxableIncome);  // Rest zu versteuern entweder Höchstbetrag oder Gesamteinkommen

            incomeInArea = Math.Max(taxableIncome - 25000.0, 0);
            taxInArea = incomeInArea * 0.43214286;
            tax += taxInArea;
            taxableIncome = Math.Min(25000.0, taxableIncome);

            incomeInArea = Math.Max(taxableIncome - 11000.0, 0);
            taxInArea = incomeInArea * 0.365;
            tax += taxInArea;

			Console.WriteLine("Für ein Jahreseinkommen von " + yearlyIncome + " Euro müssen "+
				tax + " Euro Steuer bezahlt werden. ");
			Console.Write("Zum Beenden Eingabetaste drücken ...");
			Console.ReadLine();
		}
	}
}
