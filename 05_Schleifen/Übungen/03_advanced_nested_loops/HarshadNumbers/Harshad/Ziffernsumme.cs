/*--------------------------------------------------------------
 *		 	 	 HTBLA-Leonding / Class: 1AHIF
 *--------------------------------------------------------------
 * Exercise Number:  1/1/Unit 8
 * File:	 	 	 Ziffernsumme.cs
 * Author(s):	 	 Robin Gugel
 * Due Date:		 <due>
 *--------------------------------------------------------------
 * Description:
 * Liest eine zahl und gibt die Ziffernsumme der Zahl aus
 *--------------------------------------------------------------
*/
using System;

namespace Ziffernsumme
{
	class summe
	{
		static void Main()
		{
			Console.Write("Geben Sie eine Zahl ein: ");
			int number = Convert.ToInt32(Console.ReadLine());
			int ziffernsummeVonNumber = 0; 
			while (number != 0)
			{
				ziffernsummeVonNumber += number % 10;
				number /= 10;
			}
			Console.WriteLine(ziffernsummeVonNumber);
		}
	}
}