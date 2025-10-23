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
            int[] correctResult = new[] {400874, 423358, 151635, 22687, 1416, 30, 0};

            int[][] tips = CreateRandomTips(COUNT_TIPS);

            Console.WriteLine("Lottosimulator");
            Console.WriteLine("==============");
            Console.WriteLine();

            int[] thrownNumbers = CreateTip();

            Console.WriteLine($"{tips.Length} Tippkolonnen");
            Console.WriteLine();

            DateTime start = DateTime.Now;
            int[] results = AnalyzeLottery(tips, thrownNumbers);
            TimeSpan duration = DateTime.Now - start;

            DisplayResults(results, correctResult);

            Console.WriteLine($"Rechenzeit: {duration.TotalMilliseconds} Millisekunden!");
        }

        private static void DisplayResults(int[] results, int[] correctResult)
        {
            for (int i = results.Length - 1; i >= 0; i--)
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

        private static int[][] CreateRandomTips(int count)
        {
            int[][] tips = new int[count][];

            for (int i = 0; i < count; i++)
            {
                tips[i] = CreateTip();
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
        static int[] AnalyzeLottery(int[][] tips, int[] thrownNumbers)
        {
            int[] results = new int[thrownNumbers.Length + 1]; // von 0er bis 6er
            // für den schnelleren Vergleich wird ein bool-Array angelegt
            // Um nicht den Index dauernd umrechnen zu müssen wird es von 0 - 45 angelegt.
            bool[] isNumberThrown = new bool[46];
            foreach (var t in thrownNumbers)
            {
                isNumberThrown[t] = true;
            }

            int countTips = tips.Length;

            for (int i = 0; i < countTips; i++)
            {
                results[CountSameNumbers(isNumberThrown, tips[i])]++;
            }

            return results;
        }

        /// <summary>
        /// Für den Tipp wird errechnet, wieviele Zahlen richtig sind.
        /// </summary>
        /// <param name="isNumberThrown">bool-Array zur schnellen Prüfung</param>
        /// <param name="tip"></param>
        /// <returns>Anzahl der richtigen Zahlen</returns>
        private static int CountSameNumbers(bool[] isNumberThrown, int[] tip)
        {
            int counter = 0;
            foreach (int val in tip)
            {
                if (isNumberThrown[val])
                {
                    counter++;
                }
            }

            return counter;
        }

        /// <summary>
        /// 6 zufällige Lottozahlen werden erzeugt.
        /// </summary>
        /// <returns>Tippkolonne</returns>
        static int[] CreateTip()
        {
            int[] numbers = new int[6];
            for (int i = 0; i < numbers.Length; i++)
            {
                int number;

                do
                {
                    number = random.Next(1, 46);
                } while (Contains(numbers, number, i - 1));

                numbers[i] = number;
            }

            return numbers;
        }

        static bool Contains(int[] numbers, int lookFor, int lastIdx)
        {
            for (int i = 0; i <= Math.Min(numbers.Length, lastIdx); i++)
            {
                if (numbers[i] == lookFor)
                {
                    return true;
                }
            }

            return false;
        }
    }
}