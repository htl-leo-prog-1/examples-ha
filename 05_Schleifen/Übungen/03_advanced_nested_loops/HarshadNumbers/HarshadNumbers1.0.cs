/*--------------------------------------------------------------
 *		 	 	 HTBLA-Leonding / Class: 1AHIF
 *--------------------------------------------------------------
 * Exercise Number:  17
 * File:	 	 	 HarshadNumbers1.0.cs
 * Author(s):	 	 Thomas  Kaar
 * Due Date:		 <12.11.2014>
 *--------------------------------------------------------------
 * Description:
 * Ein Programm das die Quersumme einer Zahl errechnet.
 *--------------------------------------------------------------
*/
using System;
namespace HarshadNumbers
{
	class HarshadNumbers
	{
		static void Main()
		{
			int zahl = Convert.ToInt32(Console.ReadLine());
			int sum = zahl % 10;
			while (zahl / 10 != 0)
			{
				zahl = zahl / 10;
				sum += zahl % 10;
			}
			Console.WriteLine(sum);
		}
	}
}