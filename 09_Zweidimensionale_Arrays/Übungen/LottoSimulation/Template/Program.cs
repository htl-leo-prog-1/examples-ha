/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: LottoSimulation
*--------------------------------------------------------------
*/

namespace LottoSimulation
{
    using System;

    class Program
    {
        static Random random = new Random(1);
        const int COUNT_TIPS = 1_000_000;

        static void Main()
        {
            var correctResult = new [] { 400874, 423358, 151635, 22687, 1416, 30, 0 };

            var tips = CreateRandomTips(COUNT_TIPS);

            Console.WriteLine("Lottosimulator");
            Console.WriteLine("==============");
            Console.WriteLine();

            var thrownNumbers = CreateTip();

            Console.WriteLine($"{tips.GetLength(0)} Tippkolonnen");
            Console.WriteLine();

            var start = DateTime.Now;
            var results = AnalyzeLottery(tips, thrownNumbers);
            var duration = DateTime.Now - start;

            DisplayResults(results, correctResult);

            Console.WriteLine($"Rechenzeit: {duration.TotalMilliseconds} Millisekunden!");
        }

        private static void DisplayResults(int[] results, int[] correctResult)
        {
            for (int i = 6; i >= 0; i--)
            {
                Console.WriteLine($"{i}er: {results[i]}");
            }

            Console.WriteLine();
            int okCount = 0;
            while (okCount < results.Length && results[okCount] == correctResult[okCount])
            {
                okCount++;
            }

            if (okCount >= results.Length)
            {
                Console.WriteLine("Das Ergebnis ist richtig!");
            }
            else
            {
                Console.WriteLine("Für 1 Mio Versuche ist das Ergebnis falsch!");
            }
        }

        private static int[,] CreateRandomTips(int count)
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
        /// <param name="tips"></param>
        /// <param name="thrownNumbers"></param>
        /// <returns>Array mit Verteilung der Treffer von 0 - 6</returns>
        static int[] AnalyzeLottery(int[,] tips, int[] thrownNumbers)
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
