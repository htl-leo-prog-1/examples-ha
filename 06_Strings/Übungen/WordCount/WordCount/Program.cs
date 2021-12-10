using System;

namespace WordCount
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			const int MAX_INPUT = 255;

			Console.WriteLine ("Word Count");
			Console.WriteLine ("==========");
			Console.WriteLine ();

			string [] inputWords = new string[MAX_INPUT];
			int i = 0;

			Console.WriteLine ("Please enter words (maximum {0} words, finish input with the word 'fertig' or 'ready')", MAX_INPUT);
			Console.WriteLine ();

			do
			{
				inputWords[i] = Console.ReadLine();
				i++;
			} while (i < MAX_INPUT && (inputWords[i-1] != "fertig" && inputWords[i-1] != "ready"));

			int totalNumberOfWords = i - 1;

			string [] wordTable = new string[totalNumberOfWords];
			int[] wordCountTable = new int[totalNumberOfWords];
			int numberOfwordsInTable = 0;

			for (i = 0; i < totalNumberOfWords; i++)
			{
				int j = 0;
				while (j < numberOfwordsInTable && wordTable [j] != inputWords [i])
				{
					j++;
				}
				if (j == numberOfwordsInTable)
				{
					wordTable [numberOfwordsInTable] = inputWords [i];
					wordCountTable [numberOfwordsInTable] = 1;
					numberOfwordsInTable++;
				} else
				{
					wordCountTable [j]++;
				}
			}

			Console.WriteLine ();
			Console.WriteLine ("Words Count Statistics");
			Console.WriteLine ();

			for (i = 0; i < numberOfwordsInTable; i++)
			{
				Console.WriteLine ("{0,-20}{1}", wordTable [i], wordCountTable [i]);
			}
		}
	}
}
