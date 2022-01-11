using System;

namespace Lotto
{
    class Program
    {
        static void Main(string[] args)
        {
            // Zufallszahlengenerator initialisieren
            Random random = new Random(0);

            // Random random = new Random(0);
            int[] lottoNumbers = new int[6];  // Array für die gültigen Lottozahlen
            int drawnNumber;
            bool isNumberNew;


            // Es werden 6 Lottozahlen erzeugt. Dabei wird bei jeder neuen Zahl geprüft,
            // ob es die Zahl bereits gibt
            for (int drawing = 0; drawing < lottoNumbers.Length; drawing++)
            {
                // so lange neue Zahl erzeugen, bis diese nicht mehr gefunden wurde
                do
                {
                    drawnNumber = random.Next(1, 46);  // Zufallszahl zwischen 1 und 45 erzeugen
                    isNumberNew = true;  // Annahme
                                        // Mit bisher gezogenen Zahlen vergleichen ==> bleibt zahlIstNeu ==> Zahl passt
                    for (int i = 0; i < drawing && isNumberNew; i++)
                    {
                        if (lottoNumbers[i] == drawnNumber)
                        {
                            isNumberNew = false;
                        }
                    }
                }
                while (!isNumberNew);
                // gezogene Zahl ist neu
                lottoNumbers[drawing] = drawnNumber;
            }
            Console.Write("Quicktipp: ");
            for (int i = 0; i < 6; i++)
            {
                Console.Write("{0} ", lottoNumbers[i]);
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
