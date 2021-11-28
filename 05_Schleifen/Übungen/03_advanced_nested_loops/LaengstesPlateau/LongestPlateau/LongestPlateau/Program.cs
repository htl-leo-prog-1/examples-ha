using System;

namespace LongestPlateau
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ziffernkette einlesen
            System.Console.WriteLine("Bestimmung der laengsten Folge gleicher Ziffern");
            // Solange weitere Ziffer vorhanden ist ==> Plateauermittlung fortsetzen
            int index = 0;
            int currentPlateauDigit = 0;
            int currentPlateauLength = 0;
            int currentPlateauPosition = 0;
            int maxPlateauLength = 0;
            int maxPlateauPosition = 0;
            int maxPlateauDigit = 0;
            // Ziffer einlesen
            Console.Write("Ziffer " + (index + 1) + " eingeben [x/X für Ende]: ");
            string input = Console.ReadLine();
            bool proceed = input.ToLower() != "x";
            while (proceed)
            {

                // Gelesene Ziffer != aktueller Ziffer ==> Plateuwechsel ==> letztes Plateau bisher längstes Plateu?
                int digit = Convert.ToInt32(input);
                if (digit == currentPlateauDigit)
                {
                    // Plateau geht weiter
                    currentPlateauLength++;
                }
                else // Ziffer wechselt ==> neues Plateau beginnt
                {
                    if (currentPlateauLength > maxPlateauLength) // neues längstes Plateau entdeckt
                    {
                        maxPlateauPosition = currentPlateauPosition; // auf Beginn des Plateaus setzen
                        maxPlateauLength = currentPlateauLength;
                        maxPlateauDigit = currentPlateauDigit;
                    }
                    // neues Plateau initialisieren
                    currentPlateauDigit = digit;
                    currentPlateauLength = 1;
                    currentPlateauPosition = index;
                }
                index++; 
                Console.Write("Ziffer " + (index + 1) + " eingeben [x/X für Ende]: ");
                input = Console.ReadLine();
                proceed = input.ToLower() != "x";
            }
            if (currentPlateauLength > maxPlateauLength) // neues längstes Plateau entdeckt
            {
                maxPlateauPosition = currentPlateauPosition; // auf Beginn des Plateaus setzen
                maxPlateauLength = currentPlateauLength;
                maxPlateauDigit = currentPlateauDigit;
            }
            // Lösungsmenge ausgeben				
            if (index > 0) // die eingegebene Ziffernkette war nicht leer
            {
                System.Console.WriteLine("Das laengste Plateau verwendet die Ziffer {0}, beginnt ab {1} und hat die Laenge {2}",
                    maxPlateauDigit, maxPlateauPosition, maxPlateauLength);
            }
            else
            {
                System.Console.WriteLine("Es wurden keine Ziffern eingegeben");
            }
            Console.Write("Beenden mit Eingabetaste ...");
            Console.ReadLine();
        }
    }
}
