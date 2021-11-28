/*-----------------------------------------------------------------------------
 *				HTBLA-Leonding / Class: <your class name here>
 *-----------------------------------------------------------------------------
 * Exercise Number: #exercise_number#
 * File:			Pi.cs
 * Author(s):		Peter Bauer
 * Due Date:		#due#
 *-----------------------------------------------------------------------------
 * Description:
 * <your description here>
 *-----------------------------------------------------------------------------
*/

using System;

class PI
{
	static void Main()
	{
		const int ITERATIONS = 5;
		double piApproximation = 0;
		
		for (int i = 0; i < ITERATIONS; i++)
		{
			piApproximation += 1.0/Math.Pow(16, i) * (4.0 / (8*i + 1) - 2.0/(8*i + 4) - 1.0/(8*i + 5) - 1.0/(8*i + 6));
		}
		Console.WriteLine("Approximated Pi to " + piApproximation + " in " +
			ITERATIONS + " iterations");
	}
}