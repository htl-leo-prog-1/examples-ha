using System;

namespace FindAllBits
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputQuestion = "Geben Sie eine Zahl zwischen 1 und " + UInt32.MaxValue + " ein (0 für Ende): ";
            Console.Write(inputQuestion);
            uint decimalNumber = Convert.ToUInt32(Console.ReadLine());
            while (decimalNumber > 0)
            {
                byte numberOfBit = 0;
                uint numberForBinaryConversion = decimalNumber;
                uint sumOfBitValues = 0;
                while (numberForBinaryConversion > 0)
                {
                    byte bit = (byte)(numberForBinaryConversion % 2);
                    Console.Write(" " + bit + " * 2^" + numberOfBit);
                    if (bit == 1)
                    {
                        uint bitValue = (uint)(Math.Pow(2, numberOfBit)) * bit;
                        Console.Write(" = " + bitValue);
                        sumOfBitValues += bitValue;

                    }
                    Console.WriteLine();
                    numberForBinaryConversion = numberForBinaryConversion / 2;
                    numberOfBit++;
                }
                uint numberForDecimalLetterCount = decimalNumber;
                uint decimalLetterCount = 0;
                while (numberForDecimalLetterCount > 0)
                {
                    numberForDecimalLetterCount /= 10;
                    decimalLetterCount++;
                }
                Console.Write("=====================");
                for (int i = 0; i <= decimalLetterCount; i++)
                {
                    Console.Write("=");

                }
                Console.WriteLine();
                Console.WriteLine("Dezimalzahl:          " + decimalNumber);
                Console.WriteLine("Summe aller Bitwerte: " + sumOfBitValues);
                Console.Write("=====================");
                for (int i = 0; i <= decimalLetterCount; i++)
                {
                    Console.Write("=");

                }
                Console.WriteLine(); 
                Console.Write(inputQuestion);
                decimalNumber = Convert.ToUInt32(Console.ReadLine());            
            }
        }
    }
}
