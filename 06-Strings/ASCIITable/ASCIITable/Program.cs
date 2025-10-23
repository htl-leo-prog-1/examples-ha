using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIITable
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 128; i++)
            {
                char c = Convert.ToChar(i);
                if (!Char.IsControl(c))
                {
                    Console.WriteLine("{0,2} {1} U+{2:X4}", i, c, i);
                }
            }

            Console.ReadKey();
        }
    }
}
