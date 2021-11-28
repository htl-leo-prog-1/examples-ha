/*--------------------------------------------------------------
 *		 	 	 HTBLA-Leonding / Class: 1AHIF
 *--------------------------------------------------------------
 * Exercise Number:  17
 * File:	 	 	 HarshadNumbers2.0.cs
 * Author(s):	 	 Thomas  Kaar
 * Due Date:		 <12.11.2014>
 *--------------------------------------------------------------
 * Description:
 * Ein Programm das ausgibt ob eine Zahl eine "Hashadnumber" ist.
 *--------------------------------------------------------------
*/
using System;
namespace HarshadNumbers
{
	class HarshadNumbers
	{
		static void Main()
		{
			int zahl2 = Convert.ToInt32(Console.ReadLine());
			int zahl = zahl2;
			int sum = zahl % 10;
			while (zahl / 10 != 0)
			{
				zahl = zahl / 10;
				sum += zahl % 10;
			}
			if (zahl2 % sum == 0)
			{
				Console.WriteLine("Ja");
			}
			else 
			{
				Console.WriteLine("Nein");
			}
		}
	}
}