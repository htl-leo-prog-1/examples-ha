using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string input;
            int length;
            string password = "";
            char ch;
            bool isContained;

            Console.WriteLine("Passwortgenerator");
            Console.WriteLine("=================");
            
            do
            {
                Console.Write("Länge des Passworts [1 - 26]: ");
                input = Console.ReadLine();
                length = Convert.ToInt32(input);
                if (length > 26 || length < 1)
                {
                    Console.WriteLine("Fehlerhafte Länge!");
                }
            } while (length > 26 || length < 1);

            for (int i = 0; i < length; i++)
            {
               
                do
                {
                    ch = (char)random.Next('a', 'z' + 1);
                    isContained = false;
                    for (int j = 0; j < password.Length && isContained == false; j++)
                    {
                        if (password[j] == ch)
                        {
                            isContained = true;
                        }
                    }
                } while (isContained);
                password += ch;
            }
            Console.WriteLine("Passwort: {0}",password);
            Console.ReadLine();
        }
    }
}
