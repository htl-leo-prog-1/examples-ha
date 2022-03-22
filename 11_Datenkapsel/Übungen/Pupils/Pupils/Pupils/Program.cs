using System;
using System.IO;

namespace PupilsArray
{
    class Program
    {
        const string FileName = "Pupils.csv";

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        static void Main()
        {
            Pupil[] schoolClass;
            // Schülerdaten einlesen
            schoolClass = ReadClassFromCsv();
            // Schülerdaten in Originalsortierung auf Console ausgeben
            Console.WriteLine("Unsortierte Ausgabe");
            WriteSchoolClassToConsole(schoolClass);
            // Nach ZipCode sortieren
            schoolClass = SortByCatalogNumber(schoolClass);
            // und wieder ausgeben
            Console.WriteLine("\nNach CatalogNumber sortierte Ausgabe");
            WriteSchoolClassToConsole(schoolClass);
            Console.ReadLine();
        }

        /// <summary>
        /// Liest die Schüler aus der Datei in ein Array ein
        /// </summary>
        /// <returns>Array mit Schülern</returns>
        private static Pupil[] ReadClassFromCsv()
        {
            string[] lines = File.ReadAllLines(FileName, System.Text.Encoding.Default);
            Pupil[] schoolClass = new Pupil[lines.Length - 1];  // wegen Headerzeile
            // solange noch Zeilen aus der csv-Datei eingelesen werden können
            for (int i = 1; i < lines.Length; i++)  // 1 wegen Headerzeile
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
            Pupil pupil;
            string[] fields = line.Split(';');
            pupil = new Pupil();
            pupil.SetCatalogNumber(Convert.ToInt32(fields[0]));
            pupil.SetLastName(fields[1]);
            pupil.SetFirstName(fields[2]);
            pupil.SetBirthDate(fields[3]);
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
            Pupil pupil;
            int rounds = 0;
            do
            {
                changed = false;
                for (int i = 0; i + 1 < (schoolClass.Length - rounds); i++)
                {
                    if (schoolClass[i].GetCatalogNumber() > schoolClass[i + 1].GetCatalogNumber())
                    {
                        changed = true;
                        pupil = schoolClass[i + 1];
                        schoolClass[i + 1] = schoolClass[i];
                        schoolClass[i] = pupil;
                    }
                }
                rounds++;
            }
            while (changed);
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
            // Header ausgeben
            Console.WriteLine("Nr Vorname          Nachname       Plz  Ort");
            for (int i = 0; i < schoolClass.Length; i++)
            {
                Console.WindowWidth = 100;
                Console.WriteLine("{0,2} {1,-16} {2,-13} {3,10}",
                    schoolClass[i].GetCatalogNumber(), schoolClass[i].GetFirstName(), schoolClass[i].GetLastName(),
                    schoolClass[i].GetBirthDate());

            }
        }
    }
}
