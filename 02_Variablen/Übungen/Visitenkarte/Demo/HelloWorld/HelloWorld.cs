using System;

namespace HelloWorld
{
    class Program
    {
        public static void Main()
        {
			Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Hey my friend, what's your name? ");
			Console.ForegroundColor = ConsoleColor.Green;
			string name = Console.ReadLine();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Nice to see you, " + name + "!");
			
			name = "Rumpelstilzchen";
			
			Console.WriteLine();
			Console.WriteLine("Press any key to exit the program ...");
			Console.ReadKey();
        }
    }
}