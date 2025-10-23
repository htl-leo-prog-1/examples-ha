using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSort
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "azxbaacb";
            char[] chars = s.ToArray();

            for (int left = 0; left < chars.Length - 1; left++)
            {
                for (int right = left + 1; right < chars.Length; right++)
                {
                    if (chars[right] < chars[left])
                    {
                        char temp = chars[right];
                        chars[right] = chars[left];
                        chars[left] = temp;
                    }
                }
            }
            Console.WriteLine("Sortiert: " + new string(chars));
            Console.ReadKey();
        }
    }
}
