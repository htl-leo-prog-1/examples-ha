/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Lotto QuickTip
*--------------------------------------------------------------
*/

using System;

const int TIPCOUNT = 10;

bool Contains(int[] tip, int count, int number)
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

int[] QuickTip()
{
    Random random = new Random();

    int[] lottoNumbers = new int[6];

    for (int i = 0; i < lottoNumbers.Length; i++)
    {
        int drawnNumber;
        do
        {
            drawnNumber = random.Next(1, 46);
        } while (Contains(lottoNumbers, i, drawnNumber));

        lottoNumbers[i] = drawnNumber;
    }

    NormalizeTip(lottoNumbers);
    return lottoNumbers;
}

void NormalizeTip(int[] tip)
{
    for (int left = 0; left < tip.Length - 1; left++)
    {
        for (int right = left + 1; right < tip.Length; right++)
        {
            if (tip[left] > tip[right])
            {
                var temp = tip[left];
                tip[left]  = tip[right];
                tip[right] = temp;
            }
        }
    }
}

string TipToString(int[] tip)
{
    var output = "";
    for (var i = 0; i < tip.Length; i++)
    {
        if (i != 0)
        {
            output += ",";
        }

        output += tip[i];
    }

    return output;
}

Console.WriteLine("Lotto-Quicktip: ");
Console.WriteLine("****************");

for (int i = 0; i < TIPCOUNT; i++)
{
    var tip         = QuickTip();
    var tipAsString = TipToString(tip);
    Console.WriteLine($"{i + 1}. Quick-Tip: {tipAsString}");
}