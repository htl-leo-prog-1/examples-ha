using System;

namespace FindDuplicates
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dublettensuche");
            Console.WriteLine("==============\n\n");
            string[] names = ReadStrings(10);
            //string[] names = { "Hugo", "Susi", "Hugo", "Sissi", "Hugo", "Sarah", "Susi", "Theo", "Gregor", "Hannah" };
            
            PrintNames("Original-Namen", names);
            string[] duplicates = FindDuplicates(names);
            PrintNames("Duplikate", duplicates);
        }

        public static string[] FindDuplicates(string[] names)
        {
            string[] duplicates = new string[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                int count = Count(names, names[i]);
                if (count > 1)
                {
                    AddDuplicate(duplicates, names[i]);
                }
            }

            return duplicates;
        }

        public static void AddDuplicate(string[] names, string name)
        {
            if (!Contains(names, name))
            {
                Add(names, name);
            }
        }

        public static void Add(string[] names, string name)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] == null)
                {
                    names[i] = name;
                    return;
                }
            }
        }

        public static bool Contains(string[] names, string name)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] == name)
                {
                    return true;
                }
            }
            return false;
        }

        public static int Count(string[] names, string name)
        {
            int count = 0;
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] == name)
                {
                    count++;
                }
            }
            return count;
        }

        private static void PrintNames(string title, string[] names)
        {
            Console.WriteLine(title.ToUpper());
            Console.WriteLine(new String('=', title.Length));
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }
            Console.WriteLine();
        }

        private static string[] ReadStrings(int count)
        {
            string[] inputs = new string[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write($"{ i + 1,2}. Name: ");
                inputs[i] = Console.ReadLine();
            }
            return inputs;
        }
    }
}
