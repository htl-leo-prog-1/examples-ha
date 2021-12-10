using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryAdder
{
    class Program
    {
        static void Main(string[] args)
        {
            string dual1;
            string dual2;
            bool isInputOk;
            string result = "";
            int index1;
            int index2;
            int overflow;
            int sum;

            Console.WriteLine("Binäraddierer");
            Console.WriteLine("=============");
            Console.WriteLine();
            do
            {
                Console.Write("Dualzahl 1 eingeben: ");
                dual1 = Console.ReadLine();
                isInputOk = true;
                for (int i = 0; i < dual1.Length; i++)
                {
                    if (dual1[i] != '0' && dual1[i] != '1')
                    {
                        isInputOk = false;
                        Console.Write("Nur 1 und 0 ist in Binärzahlen erlaubt, ");
                        break;
                    }
                }
            } while (!isInputOk);
            do
            {
                Console.Write("Dualzahl 2 eingeben: ");
                dual2 = Console.ReadLine();
                isInputOk = true;
                for (int i = 0; i < dual2.Length; i++)
                {
                    if (dual2[i] != '0' && dual2[i] != '1')
                    {
                        isInputOk = false;
                        Console.Write("Nur 1 und 0 ist in Binärzahlen erlaubt, ");
                        break;
                    }
                }
            } while (!isInputOk);
            // Addieren
            index1 = dual1.Length - 1;
            index2 = dual2.Length - 1;
            overflow = 0;
            while (index1 >= 0 && index2 >= 0)
            {
                sum = (dual1[index1] - '0') + (dual2[index2] - '0') + overflow;
                result = sum % 2 + result;
                if (sum > 1)
                {
                    overflow = 1;
                }
                else
                {
                    overflow = 0;
                }
                index1--;
                index2--;
            }
            while (index1 >= 0)
            {
                sum = (dual1[index1] - '0') + overflow;
                result = sum % 2 + result;
                if (sum > 1)
                {
                    overflow = 1;
                }
                else
                {
                    overflow = 0;
                }
                index1--;
            }
            while (index2 >= 0)
            {
                sum = (dual2[index2] - '0') + overflow;
                result = sum % 2 + result;
                if (sum > 1)
                {
                    overflow = 1;
                }
                else
                {
                    overflow = 0;
                }
                index2--;
            }
            if (overflow > 0)
            {
                result = "1" + result;
            }
            Console.WriteLine("{0} + {1} = {2}", dual1, dual2, result);
            Console.Write("Beenden mit der Eingabetaste ...");
            Console.ReadLine();
        }
    }
}
