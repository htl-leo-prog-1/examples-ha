using System;

namespace SearchString
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("StringSearch");
            Console.WriteLine("============");
            Console.WriteLine();
            Console.Write("Text eingeben: ");
            string text = Console.ReadLine();
            Console.Write("\nSuchtext eingeben: ");
            string suchText = Console.ReadLine();

            while (suchText != "")
            {
                int result = MyString.SearchString(text, suchText);
                if (result > -1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Suchtext '{suchText}' beginnt im Text '{text}' an der Position {result}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Suchtext '{suchText}' wurde im Text '{text}' nicht gefunden!");
                }              
                Console.ResetColor();

                Console.Write("\nSuchtext eingeben (Leer-Text für Ende): ");
                suchText = Console.ReadLine();
            }
            

        }
    }
}
