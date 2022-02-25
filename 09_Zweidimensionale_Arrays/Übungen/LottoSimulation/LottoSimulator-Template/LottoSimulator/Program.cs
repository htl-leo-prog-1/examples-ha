using System;

namespace LottoSimulator
{
    class Program
    {
        static Random random = new Random(1);  // 1 damit immer gleiches Ergebnis kommt
        static int[] correctResult = { 400874, 423358, 151635, 22687, 1416, 30, 0 };
        const int COUNT_TIPS = 1_000_000;

        static void Main()
        {
            Console.WriteLine("Lottosimulator");
            Console.WriteLine("==============");
            Console.WriteLine();

            // 1.000.000 Lottotipps erzeugen                     
            int[,] lotteryTips = CreateRandomLotteryTips();
            Console.WriteLine($"{lotteryTips.GetLength(0)} Tippkolonnen wurden generiert.");
            Console.WriteLine();
            
            // Ziehung simulieren
            int[] thrownNumbers = CreateTip();

            // Treffer Zählen
            DateTime start = DateTime.Now;
            int[] results = AnalyzeLottery(lotteryTips, thrownNumbers);
            TimeSpan duration = DateTime.Now - start;

            DisplayResults(results);          
            Console.WriteLine($"Rechenzeit: {duration.TotalMilliseconds} Millisekunden!");
            Console.ReadLine();
        }

        private static void DisplayResults(int[] results)
        {
            for (int i = 6; i >= 0; i--)
            {
                Console.WriteLine("{0}er: {1}", i, results[i]);
            }
            Console.WriteLine();
            int j = 0;
            while (j < results.Length && results[j] == correctResult[j])
            {
                j++;
            }
            if (j >= results.Length)
            {
                Console.WriteLine("Das Ergebnis ist richtig!");
            }
            else
            {
                Console.WriteLine("Für 1 Mio Versuche ist das Ergebnis falsch!");
            }
        }

        private static int[,] CreateRandomLotteryTips()
        {
            //TODO Methode implementieren
            throw new NotImplementedException();
        }

        /// <summary>
        /// Die Lottoziehung wird analysiert. Dabei wird in den Tipps
        /// gezählt, wie oft die gezogenen Zahlen einen 6er, 5er usw bis 0er
        /// ergeben haben.
        /// Besonderer Wert ist auf die Laufzeiteffizienz zu legen.
        /// </summary>
        /// <param name="lottoTipps">Kolonne mit 1 Mio Tipps</param>
        /// <param name="thrownNumbers">Gezogene Zahlen == 6er</param>
        /// <returns>Array mit Verteilung der Treffer von 0 - 6</returns>
        static int[] AnalyzeLottery(int[,] lottoTipps, int[] thrownNumbers)
        {
            //TODO Methode implementieren
            throw new NotImplementedException();
        }

        /// <summary>
        /// 6 zufällige Lottozahlen werden erzeugt.
        /// </summary>
        /// <returns>Tippkolonne</returns>
        static int[] CreateTip()
        {
            //TODO Methode implementieren
            throw new NotImplementedException();
        }
    }
}
