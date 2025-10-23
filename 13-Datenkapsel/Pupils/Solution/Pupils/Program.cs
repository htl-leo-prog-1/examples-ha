using System;
using System.Globalization;
using System.IO;

namespace PupilsArray
{
    class Program
    {
        const string FileName = "Pupils.csv";

        static void Main()
        {
            var schoolClass = ReadClassFromCsv();
            Console.WriteLine("Unsortierte Ausgabe");
            WriteSchoolClassToConsole(schoolClass);
            schoolClass = SortByCatalogNumber(schoolClass);
            Console.WriteLine();
            Console.WriteLine("Nach CatalogNumber sortierte Ausgabe");
            WriteSchoolClassToConsole(schoolClass);
            Console.ReadLine();
        }

        /// <summary>
        /// Liest die Schüler aus der Datei in ein Array ein
        /// </summary>
        /// <returns>Array mit Schülern</returns>
        private static Pupil[] ReadClassFromCsv()
        {
            var lines = File.ReadAllLines(FileName, System.Text.Encoding.Default);
            var schoolClass = new Pupil[lines.Length - 1]; // wegen Headerzeile
            for (int i = 1; i < lines.Length; i++)
            {
                schoolClass[i - 1] = GetPupilFromCsvLine(lines[i]);
            }

            return schoolClass;
        }

        /// <summary>
        /// Eine Zeile wird geparst ==> Ein Schüler entsteht
        /// </summary>
        /// <param name="line">Zeile mit Feldern durch ; getrennt</param>
        /// <returns>Struktur Schüler</returns>
        static Pupil GetPupilFromCsvLine(string line)
        {
            var fields = line.Split(';');
            var pupil = new Pupil();
            
            pupil.CatalogNumber = int.Parse(fields[0]);
            
            pupil.SetLastName(fields[1]);
            pupil.FirstName = fields[2];
            pupil.SetBirthDate(DateTime.ParseExact(fields[3], "dd.MM.yyyy", CultureInfo.InvariantCulture));
            return pupil;
        }

        /// <summary>
        /// Die Schüler der Klasse werden entsprechend der ZipCode sortiert.
        /// Verwendet wird ein einfacher Bubblesort.
        /// </summary>
        /// <param name="schoolClass">Klasse</param>
        /// <returns>Sortierte Klasse nach ZipCode</returns>
        static Pupil[] SortByCatalogNumber(Pupil[] schoolClass)
        {
            bool changed;
            int rounds = 0;
            do
            {
                changed = false;
                for (int i = 0; i + 1 < (schoolClass.Length - rounds); i++)
                {
                    if (schoolClass[i].CatalogNumber > schoolClass[i + 1].CatalogNumber)
                    {
                        changed = true;
                        var tmp = schoolClass[i + 1];
                        schoolClass[i + 1] = schoolClass[i];
                        schoolClass[i] = tmp;
                    }
                }

                rounds++;
            } while (changed);

            return schoolClass;
        }

        /// <summary>
        /// Ausgabe der aktuellen PupilsArray. Soweit es geht, werden
        /// die Spaltenbreiten sinnvoll gesetzt.
        /// </summary>
        /// <param name="schoolClass"></param>
        static void WriteSchoolClassToConsole(Pupil[] schoolClass)
        {
            Console.WriteLine();
            Console.WriteLine("Nr Vorname          Nachname      Datum");
            foreach (var pupil in schoolClass)
            {
                Console.WriteLine(
                    $"{pupil.CatalogNumber,2} {pupil.FirstName,-16} {pupil.GetLastName(),-13} {pupil.GetBirthDate().ToShortDateString(),10}");
            }
        }
    }
}