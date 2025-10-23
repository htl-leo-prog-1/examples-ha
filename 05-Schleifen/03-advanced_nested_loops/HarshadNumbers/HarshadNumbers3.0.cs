/*--------------------------------------------------------------
 *		 	 	 HTBLA-Leonding / Class: 1AHIF
 *--------------------------------------------------------------
 * Exercise Number:  17
 * File:	 	 	 HarshadNumbers2.0.cs
 * Author(s):	 	 Thomas  Kaar
 * Due Date:		 <12.11.2014>
 *--------------------------------------------------------------
 * Description:
 * Ein Programm das ausgibt alle "Hashadnumbers" von 1 bis "Int32.MaxValue" ausgibt.
 *--------------------------------------------------------------
*/
using System;
namespace HarshadNumbers
{
	class HarshadNumbers
	{
		static void Main()
		{
			int zahl2 = 1;
			int zahl = zahl2;
			int sum = zahl % 10;
			while(zahl2 <= Int32.MaxValue)
			{	
				zahl = zahl2;
				sum = zahl % 10;
				while (zahl / 10 != 0)
				{
					zahl = zahl / 10;
					sum += zahl % 10;
				}
				if (zahl2 % sum == 0)
				{
					Console.Write("{0}, ", zahl2);
				}
				zahl2++;
			}
			Console.WriteLine( + " Minuten");
		}
	}
}