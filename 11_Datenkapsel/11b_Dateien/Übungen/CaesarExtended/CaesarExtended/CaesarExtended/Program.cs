using System;

namespace CaesarExtended
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Caesar");
            Console.Write("Wollen Sie verschlüsseln oder entschlüsseln (V/E)? ");
            string action = Console.ReadLine();

            Console.Write("Geben Sie bitte den Namen der zu verschlüsselnden Datei ein: ");
            string file = Console.ReadLine();

            Console.Write("Geben Sie bitte den Namen der Schlüsseldatei ein: ");
            string key = Console.ReadLine();


        }
    }
}
