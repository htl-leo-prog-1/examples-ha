using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharIntConversions
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "a2b3";
            char c = 'a';
            int i = (int)c;
            
            Console.WriteLine("Aus " + c + " wird " + (char)(i + 13));

            Console.ReadKey();
        }
    }
}
