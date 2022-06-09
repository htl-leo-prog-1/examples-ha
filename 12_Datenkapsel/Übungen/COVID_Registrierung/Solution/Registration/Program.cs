using System;

namespace Registration
{
    struct Person
    {
        public string firstname;
        public string lastname;
        public string birthdate;

        public Person(string firstname, string lastname, string birthdate)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.birthdate = birthdate;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("COVID - Registrierung");
            Console.WriteLine("=====================");
            Console.WriteLine();

            int n = 0;
            string[] lines = new string[0];

            if (File.Exists("persons.csv"))
            {
                lines = File.ReadAllLines("persons.csv");
                n = lines.Length;
            }

            Console.Write("Wie viele Personen sollen registriert werden? ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Person[] persons = new Person[number + n];

            for (int i = 0; i < n; i++)
            {
                persons[i] = PersonFromString(lines[i]);
            }

            for (int i = 0; i < number; i++)
            {
                Console.WriteLine($"Person {i + 1}:");

                Console.Write("Vorname: ");
                string firstname = Console.ReadLine();
                Console.Write("Nachname: ");
                string lastname = Console.ReadLine();
                Console.Write("Geburtsdatum: ");
                string birthdate = Console.ReadLine();

                persons[n + i] = new Person(firstname, lastname, birthdate);

                Console.WriteLine();
            }

            SavePersons(persons);
        }

        static Person PersonFromString(string line)
        {
            string[] attributes = line.Split(",");
            Person person = new Person(attributes[0], attributes[1], attributes[2]);
            return person;
        }

        static string PersonToString(Person person)
        {
            return $"{person.firstname},{person.lastname},{person.birthdate}";
        }

        static void SavePersons(Person[] persons)
        {
            string[] lines = new string[persons.Length];

            for (int i = 0; i < persons.Length; i++)
            {
                lines[i] = PersonToString(persons[i]);
            }

            File.WriteAllLines("persons.csv", lines);
        }
    }
}