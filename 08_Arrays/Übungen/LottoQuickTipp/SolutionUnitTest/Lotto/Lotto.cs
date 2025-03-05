/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Lotto QuickTip
*--------------------------------------------------------------
*/

using System;

namespace Lotto
{
    public class Lotto
    {
        private static bool Contains(int[] tip, int count, int number)
        {
            for (int i = 0; i < count; i++)
            {
                if (tip[i] == number)
                {
                    return true;
                }
            }

            return false;
        }

        public static int[] QuickTip(int maxNo)
        {
            if (maxNo < 6)
            {
                return null;
            }

            int[] lottoNumbers = new int[6];

            for (int i = 0; i < lottoNumbers.Length; i++)
            {
                int drawnNumber;
                do
                {
                    drawnNumber = Random.Shared.Next(1, maxNo+1);
                } while (Contains(lottoNumbers, i, drawnNumber));

                lottoNumbers[i] = drawnNumber;
            }

            NormalizeTip(lottoNumbers);
            return lottoNumbers;
        }

        private static void NormalizeTip(int[] tip)
        {
            bool swap;
            do
            {
                swap = false;
                for (int i = 1; i < tip.Length; i++)
                {
                    if (tip[i - 1] > tip[i])
                    {
                        int tmp = tip[i - 1];
                        tip[i - 1] = tip[i];
                        tip[i]     = tmp;
                        swap      = true;
                    }
                }
            } while (swap);
        }

        public static string TipToString(int[] tip)
        {
            string output = "";
            bool   first  = true;

            foreach (int nr in tip)
            {
                if (!first)
                {
                    output += ",";
                }

                output += nr;
                first  = false;
            }

            return output;
        }
    }
}
