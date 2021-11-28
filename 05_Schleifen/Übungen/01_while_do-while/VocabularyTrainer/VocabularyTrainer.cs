/*-----------------------------------------------------------------------------
 *				HTBLA-Leonding / Class: <your class name here>
 *-----------------------------------------------------------------------------
 * Exercise Number: #exercise_number#
 * File:			VocabularyTrainer.cs
 * Author(s):		Peter Bauer
 * Due Date:		#due#
 *-----------------------------------------------------------------------------
 * Description:
 * a game for two to learn Vocabulary
 *-----------------------------------------------------------------------------
*/

using System;

class VocabularyTrainer
{
	static void Main()
	{
		Console.WriteLine("* ----------------------------------------- *");
		Console.WriteLine("*               Vocabulary Trainer          *");
		Console.WriteLine("* ----------------------------------------- *");
		Console.WriteLine("*                 Expert Section            *");
		Console.WriteLine("* ----------------------------------------- *");
		Console.Write("Please enter an English word: ");
		string english = Console.ReadLine();
		Console.Write("Please enter the German translation of that word: ");
		string german = Console.ReadLine();
		
		//Console.Clear();
		Console.WriteLine("* ----------------------------------------- *");
		Console.WriteLine("*                Student Section            *");
		Console.WriteLine("* ----------------------------------------- *");
		string studentAnswer = "";
		
		while (studentAnswer != german)
		{
			Console.Write("Please enter the German word for " + english + ": ");
			studentAnswer = Console.ReadLine();
			if (studentAnswer == german)
			{
				Console.WriteLine("Great");
			}
			else
			{
				Console.WriteLine("Nope, please try again");
			}
		}
	}
}