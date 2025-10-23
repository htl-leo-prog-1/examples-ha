/*--------------------------------------------------------------
 *		 	 	 HTBLA-Leonding / Class: 1AHIF
 *--------------------------------------------------------------
 * Exercise Number:  1/3/Unit 8
 * File:	 	 	 AllHarshadZahl.cs
 * Author(s):	 	 Robin Gugel
 * Due Date:		 <due>
 *--------------------------------------------------------------
 * Description:
 * Gibt alle Harshad Zahlen zwischen 2 und Max.Int32Value aus, inklusive Beschleunigung
 *--------------------------------------------------------------
*/
using System;
namespace AllHarshadZahl
{
	class zahl
	{
		static void Main()
		{
			int number = 1;
			Console.WriteLine("Harshad Zahlen: ");
			int ziffernsummeVonNumber = 1;
			while (number < Int32.MaxValue/10)
			{
				if (number % ziffernsummeVonNumber == 0)
				{
					Console.WriteLine(number);
				}
				int dividend = 10;
				while (number % dividend == 0)
				{
					ziffernsummeVonNumber -= 9;
					dividend *= 10;
				}
				ziffernsummeVonNumber++;
				number++;
			}
		}
	}
}