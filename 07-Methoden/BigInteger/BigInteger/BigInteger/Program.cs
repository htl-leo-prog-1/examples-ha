using Figgle;
using System;

namespace BigInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintHeader();
            
            string a = BigInteger.ReadBigInteger("Geben Sie die erste Zahl ein!");

            Console.ReadKey();
            PrintFooter();
        }

        private static void PrintHeader()
        {
            Console.WriteLine(FiggleFonts.Standard.Render("BigInteger"));
            Console.WriteLine();
        }

        private static void PrintFooter()
        {
            Console.Write("\nDrücken Sie eine Taste zum Beenden ...");
            Console.ReadKey();
        }
    }
}
