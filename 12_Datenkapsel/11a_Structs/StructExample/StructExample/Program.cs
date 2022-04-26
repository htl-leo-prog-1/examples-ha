using System;

namespace StructExample
{
    class MainClass
    {
        struct Student
        {
            public int id;
            public string firstName;
            public string lastName;
            public int zipCode;
        }

        public static void Main(string[] args)
        {
            const int MAX_NUMBER_OF_STUDENTS = 40;

            Console.WriteLine("Struct Example");

            Student[] students = new Student[MAX_NUMBER_OF_STUDENTS];

            students[0] = ReadStudentsData();
            Student s = students[0];
            Console.Write("Id: "); Console.WriteLine(s.id);
            Console.Write("Vorname: "); Console.WriteLine(students[0].firstName);

            Console.WriteLine("Bauer compared to Baier: " + String.Compare("Bauer", "Baier"));
            Console.WriteLine("Baier compared to Bauer: " + String.Compare("Baier", "Bauer"));

            Console.WriteLine();
            Console.WriteLine("Bauer to Baier: " + "Bauer".CompareTo("Baier"));
            Console.WriteLine("Baier to Bauer: " + "Baier".CompareTo("Bauer"));
            Console.WriteLine("Bauer to Bauer: " + "Bauer".CompareTo("Bauer"));

        }

        private static Student ReadStudentsData()
        {
            Student studentData;

            Console.Write("Katalognummer: ");
            studentData.id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Vorname: ");
            studentData.firstName = Console.ReadLine();

            Console.Write("Nachname: ");
            studentData.lastName = Console.ReadLine();

            Console.Write("PLZ: ");
            studentData.zipCode = Convert.ToInt32(Console.ReadLine());

            return studentData;
        }
    }
}
