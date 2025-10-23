/*--------------------------------------------------------------
 *		 	 	 HTBLA-Leonding / Class: 1AHIF
 *--------------------------------------------------------------
 * Exercise Number:  1/2/Unit 8
 * File:	 	 	 HarshadZahl.cs
 * Author(s):	 	 Robin Gugel
 * Due Date:		 <due>
 *--------------------------------------------------------------
 * Description:
 * Liest eine Zahl welche von dem Nutzer eingegeben wurde und gibt aus ob die Zahl eine Harshad Zahl ist
 *--------------------------------------------------------------
*/
using System;
namespace HarshadZahl
{
	class zahl
	{
		static void Main()
		{
			Console.Write("Geben Sie eine Zahl ein: ");
			int number = Convert.ToInt32(Console.ReadLine());
			int usingNumber = number;
			int ziffernsummeVonNumber = 0; 
			while (usingNumber != 0)
			{
				ziffernsummeVonNumber += usingNumber % 10;
				usingNumber /= 10;
			}
			if (number % ziffernsummeVonNumber == 0)
			{
				Console.WriteLine(number + " ist eine Harshad Zahl");
			}
			else
			{
				Console.WriteLine(number + " ist keine Harshad Zahl");
			}
		}
	}
}