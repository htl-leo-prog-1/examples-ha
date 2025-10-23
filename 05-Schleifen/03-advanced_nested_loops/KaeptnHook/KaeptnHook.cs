using System;

namespace KaeptnHook
{
    class Program
    {
        static void Main(string[] args)
        {
            bool found = false;
            int kids, age=0, shiplen = 0;

            // Ausgabe der Firmendaten
            System.Console.WriteLine("************************************************************");
            System.Console.WriteLine("*  RätselKnack - Knackt jauch das Geheimnis von Käptn Hook *");
            System.Console.WriteLine("*  von Prof. Gerhard Gehrer                                *");
            System.Console.WriteLine("************************************************************");
            System.Console.WriteLine("");
            System.Console.WriteLine("");

            kids = 3;

            for (kids = 4; kids < 20 && !found; kids++)
            {
                age = kids + 1;
                do
                {
                    shiplen = 32118 / kids / age;
                    if (32118 % (kids * age * shiplen) == 0)
                    {
                        found = true; // Lösung gefunden - Hurra das Rätsel ist gelöst
                    }
                    else
                    {
                        age++;
                    }
                        
                } while (age < 100 && !found);

            } 

            if (found == true)
            {
                Console.WriteLine("Das Geheimnis von Käptn Hook ist:");
                Console.WriteLine("\tKäptn Hook ist {0} Jahre alt, hat {1} Kinder und sein Schiff ist {2} m lang", age, kids, shiplen);
            }
            else
            {
                Console.WriteLine("Das Geheimnis von Käptn Hook bleibt ein geheimnis.");
                Console.WriteLine("\tLeider kann ich sein geheimnis nicht lüften - Käptn Hook hat mich geschlagen!");
            }

            Console.WriteLine();
            Console.Write("Drücken Sie eine Taste...");
            Console.ReadKey();
        }
    }
}
