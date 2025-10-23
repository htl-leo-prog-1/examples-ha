/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: Lotto QuickTipp
 *--------------------------------------------------------------
 */

using System;

namespace Lotto
{
    class Program
    {
        const         int TIPCOUNT = 10;
        private const int MaxNo    = 45;

        public static void Main()
        {
            Console.WriteLine("Lotto-Quicktipp: ");
            Console.WriteLine("****************");

            for (int i = 0; i < TIPCOUNT; i++)
            {
                int[]  tip         = Lotto.QuickTip(MaxNo);
                string tipAsString = Lotto.TipToString(tip);
                Console.WriteLine($"{i + 1,2}. Quick-Tipp: {tipAsString}");
            }
        }
    }
}