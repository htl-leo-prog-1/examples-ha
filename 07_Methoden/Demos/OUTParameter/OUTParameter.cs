/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Demo Min/Max with "out" parameter
*--------------------------------------------------------------
*/

using System;

void GetMinAndMax(int[] array, out int min, out int max)
{
    min = int.MaxValue;
    max = int.MinValue;

    foreach (int val in array)
    {
        if (val > max)
        {
            max = val;
        }
        else if (val < min)
        {
            min = val;
        }
    }
}


int[] myArray = new int[100];

for (int i = 0; i < myArray.Length; i++)
{
    myArray[i] = Random.Shared.Next();
}


int myMin;
int myMax;

GetMinAndMax(myArray, out myMin, out myMax);

Console.WriteLine($"min={myMin}, max={myMax}");