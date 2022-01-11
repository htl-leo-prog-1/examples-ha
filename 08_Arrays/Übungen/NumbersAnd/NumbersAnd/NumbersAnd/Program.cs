using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersAnd
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersA = { 1, 3, 5, 7, 9 };
            int[] numbersB = { 0, 1, 2, 3 };
            int count;
            int index = 0;
            int[] result;
            bool[] isInBoth = new bool[10];

            Console.WriteLine("Ziffern Und");
            Console.WriteLine("===========");
            Console.Write("Feld A: ");
            for (int i = 0; i < numbersA.Length; i++)
            {
                Console.Write("{0} ", numbersA[i]);
            }
            Console.WriteLine();
            Console.Write("Feld B: ");
            for (int i = 0; i < numbersB.Length; i++)
            {
                Console.Write("{0} ", numbersB[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < numbersA.Length; i++)
            {
                for (int j = 0; j < numbersB.Length; j++)
                {
                    if (numbersA[i] == numbersB[j])
                    {
                        isInBoth[numbersA[i]] = true;
                    }
                }
            }
            count = 0;
            for (int i = 0; i < isInBoth.Length; i++)
            {
                if (isInBoth[i])
                {
                    count++;
                }
            }
            result = new int[count];
            for (int i = 0; i < isInBoth.Length; i++)
            {
                if (isInBoth[i])
                {
                    result[index] = i;
                    index++;
                }
            }
            Console.WriteLine("Ergebnis enthält {0} Ziffern", result.Length);
            Console.Write("Ziffern in Feld A und Feld B: ");
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write("{0} ", result[i]);
            }
            Console.ReadLine();
        }

    }
}
