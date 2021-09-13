/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1AHIF
 *--------------------------------------------------------------
 *                 / _)     (  _ / _-- _/_ _ 
 *                /(_) .   __)( /)/ ()(/(-/  
 *--------------------------------------------------------------
 * Description:
 * A simple pocket calculator which can add two doubles
 * and prints the result to the console right-aligned.
 *--------------------------------------------------------------
*/
using System;

namespace PocketCalculator
{
	class Program
	{
		static void Main()
		{
			Console.WriteLine("************************************");
			Console.WriteLine("* Calculator - Ihr Zahlenbegleiter *");
			Console.WriteLine("************************************");
			Console.WriteLine();
			
			Console.Write("Erste Zahl: ");
			string userInput = Console.ReadLine();
			double operand1 = Convert.ToDouble(userInput);
			Console.Write("Zweite Zahl: ");
			userInput = Console.ReadLine();
			double operand2 = Convert.ToDouble(userInput);
			Console.WriteLine();
			
			double sum = operand1 + operand2;
			
			Console.WriteLine("Ergebnis:");
			Console.WriteLine("=========");
			Console.WriteLine("{0,20:f4}", operand1);
			Console.WriteLine("+ {0,18:f4}", operand2);
			Console.WriteLine("--------------------");
			Console.WriteLine("{0,20:f4}", sum);
			Console.WriteLine("====================");
			
		}
	}
}