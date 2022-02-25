using System;

namespace LottoSimulation
{
    class Program
    {
        static Random random = new Random(1);

        static void Main()
        {
            // 1.000.000 Lottotipps erzeugen
            const int countTipps = 1000000;
            int[] results; // wieviele 0er, 1er, 2er, ..., 6er gibt es in den Tipps
            int[] correctResult = { 400874, 423358, 151635, 22687, 1416, 30, 0 };
            int[,] lottoTipps = new int[countTipps, 6];
            int[] tip;
            int[] thrownNumbers;
            DateTime start;
            TimeSpan duration;  // in Millisekunden

            Console.WriteLine("Lottosimulator");
            Console.WriteLine("==============");
            Console.WriteLine();
            Console.WriteLine("{0} Tippkolonnen", lottoTipps.GetLength(0));
            Console.WriteLine();
            for (int tippNummer = 0; tippNummer < countTipps; tippNummer++)
            {
                tip = CreateTip();
                for (int zahlNummer = 0; zahlNummer < 6; zahlNummer++)
                {
                    lottoTipps[tippNummer, zahlNummer] = tip[zahlNummer];
                }
            }
            // Ziehung simulieren
            thrownNumbers = CreateTip();
            // Treffer Zählen
            start = DateTime.Now;
            results = AnalyzeLottery(lottoTipps, thrownNumbers);
            duration = DateTime.Now - start;
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
            Console.WriteLine("Rechenzeit: {0} Millisekunden!", duration.TotalMilliseconds);
            Console.ReadLine();
        }

        /// <summary>
        /// Die Lottoziehung wird analysiert. Dabei wird in den Tipps
        /// gezählt, wie oft die gezogenen Zahlen einen 6er, 5er usw bis 0er
        /// ergeben haben.
        /// Besonderer Wert ist auf die Laufzeiteffizienz zu legen.
        /// </summary>
        /// <param name="lottoTipps"></param>
        /// <param name="thrownNumbers"></param>
        /// <returns>Array mit Verteilung der Treffer von 0 - 6</returns>
        static int[] AnalyzeLottery(int[,] lottoTipps, int[] thrownNumbers)
        {
            int[] results = new int[7]; // von 0er bis 6er
            // für den schnelleren Vergleich wird ein bool-Array angelegt
            // Um nicht den Index dauernd umrechnen zu müssen wird es von 0 - 45 angelegt.
            bool[] isNumberThrown= new bool[46];
            for (int i = 0; i < thrownNumbers.Length; i++)
            {
                isNumberThrown[thrownNumbers[i]] = true;
            }
            int rightNumbers;
            // Treffer für alle Tipps zählen
            int countTips = lottoTipps.GetLength(0);
            for (int i = 0; i < countTips; i++)
            {
                rightNumbers = 0;
                // Jede Zahl des Tipps überprüfen, ob sie gezogen wurde
                for (int zahl = 0; zahl < 6; zahl++)
                {
                    if (isNumberThrown[lottoTipps[i, zahl]])
                    {
                        rightNumbers++;  // Wenn ja ==> Trefferanzahl erhöhen
                    }
                }
                // Für den Tipp die Trefferanzahl ermitteln und entsprechenden Zähler erhöhen
                results[rightNumbers]++;
            }
            return results;
        }

        /// <summary>
        /// Für den Tipp mit dem Index wird errechnet, wieviele Zahlen richtig sind.
        /// </summary>
        /// <param name="isNumberThrown">bool-Array zur schnellen Prüfung</param>
        /// <param name="tipp"></param>
        /// <param name="tipIndex"></param>
        /// <returns>Anzahl der richtigen Zahlen</returns>
        private static int CalculateRightNumbers(bool[] isNumberThrown, int[,] tipp, int tipIndex)
        {
            int counter = 0;
            for (int i = 0; i < 6; i++)
            {
                if (isNumberThrown[tipp[tipIndex, i]])
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
            int number;
            bool found;
            for (int i = 0; i < 6; i++)
            {
                do
                {
                    found = false; // gibt es die Zahl bereits
                    // lottoZahl = random.Next(1, 7);  // dann gibt es nur 6er
                    number = (byte)random.Next(1, 46);
                    for (int j = 0; j < i; j++)
                    {
                        if (number == numbers[j])
                        {
                            found = true;
                        }
                    }
                } while (found);
                numbers[i] = number;
            }
            return numbers;
        }
    }
}
