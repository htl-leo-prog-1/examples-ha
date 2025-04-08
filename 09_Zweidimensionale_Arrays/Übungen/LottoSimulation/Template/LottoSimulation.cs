/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: LottoSimulation
*--------------------------------------------------------------
*/

using System.ComponentModel;

namespace LottoSimulation
{
    using System;

    class Program
    {
        static Random random = new Random(1);
        const int COUNT_TIPS = 1_000_000;

        static void Main()
        {
            int[] correctResult = new [] { 400874, 423358, 151635, 22687, 1416, 30, 0 };

            int[,] tips = CreateRandomTips(COUNT_TIPS);

            Console.WriteLine("Lottosimulator");
            Console.WriteLine("==============");
            Console.WriteLine();

            int[] thrownNumbers = CreateTip();

            Console.WriteLine($"{tips.GetLength(0)} Tippkolonnen");
            Console.WriteLine();

            DateTime start = DateTime.Now;
            int[] results = AnalyzeLottery(tips, thrownNumbers);
            TimeSpan duration = DateTime.Now - start;

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
            int[,] tips = new int[count, 6];

            for (int i = 0; i < count; i++)
            {
                int[] tip = CreateTip();

                for (int j = 0; j < tip.Length; j++)
                {
                    tips[i,j] = tip[j];
                }
            }

            return tips;

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
            int[] result = new int[7];

            for (int i = 0; i < tips.GetLength(0); i++)
            {
                int tipResult = CountSameNumbers(tips, thrownNumbers, j);
                result[tipResult]++;
            }

            return result;
        }

        static int CountSameNumbers(int[,] tips, int[] thrownNumbers, int idx)
        {
            int count=0;

            return count;
        }

        /// <summary>
        /// 6 zufällige Lottozahlen werden erzeugt.
        /// </summary>
        /// <returns>Tippkolonne</returns>
        static int[] CreateTip()
        {
            int[] tip = new int[6];

            for (int i = 0; i < tip.Length; i++)
            {
                int random = Random.Shared.Next(1, 46);

                while (Contains(tip, random, i))
                {
                    random = Random.Shared.Next(1, 46);
                }

                tip[i] = random;

            }

            return tip;
        }

        private static bool Contains(int[] numbers, int value, int length)
        {
            length = Math.Min(length, numbers.Length);

            for (int i = 0; i < length; i++)
            {
                if (numbers[i] == value)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
