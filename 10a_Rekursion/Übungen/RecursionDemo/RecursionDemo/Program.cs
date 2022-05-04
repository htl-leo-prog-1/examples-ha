using System;

namespace RecursionDemo
{
    class Program
    {
        const int LIMIT = 4;

        static void Main(string[] args)
        {
            int nrOfCalls = CallMe(1);
            Console.WriteLine();
            Console.WriteLine("Anzahl Aufrufe: " + nrOfCalls);    

            Console.ReadKey();
        }

        static int CallMe(int counter)
        {
            Console.Write(counter + " ");
            if (counter == LIMIT)
            {
                return counter;
            }
            return CallMe(++counter);
        }
    }
}
