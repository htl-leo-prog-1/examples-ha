using System;
using System.Runtime.InteropServices;

namespace NumberExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int digit;
            int number =0;
            long doubled;
            bool isNumberTooLarge = false;
            //Console.WriteLine("int.MaxValue: "+int.MaxValue);
            Console.Write("Eingabetext:");
            input = Console.ReadLine();

            for (int i = 0; i < input.Length && !isNumberTooLarge; i++)
            {
                if ((input[i] >= '0') && (input[i] <= '9'))
                {
                    digit = input[i] - '0';
                    if (int.MaxValue - number*10 >= digit)
                    {
                        number = number * 10 + digit;
                    }
                    else
                    {
                        isNumberTooLarge = true;
                    }
                }
            }

            if (isNumberTooLarge)
            {
                Console.WriteLine("Die im Text enthaltene Zahl übersteigt den Wertebereich von int");
            }
            else
            {
                doubled = number* (long)2;
                Console.WriteLine("Die enthaltene Zahl lautet {0}. Das Doppelte der Zahl lautet {1}",
                    number, doubled);
            }
            Console.ReadLine();
        }
    }
}
