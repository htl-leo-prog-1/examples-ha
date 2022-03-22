using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OOP.Struct
{
    public struct Runner
    {
        public string StartNr;
        public string Name;
        public string Nation;
        public int Year;
        public string Company;
        public string Team;
        public string Time;
        public double TimeSec;
    }



    class Program
    {
        public static string INPUTDATAFILE = "BusinessRun.csv";
        public static string OUTPUTDATAFILE = "RUN-Start.csv";

        static void Main(string[] args)
        {
            // Variablendeklaration
            Runner[] races;
            Runner[] firstThree;

            // Ausgabe der Programm-Header
            PrintHeader();
            // Eingabe (E)
            races = ReadDataFromCsv(INPUTDATAFILE);
            // Verarbeitung (V)
            SortRacesByTime(races);
            firstThree = GetTheFirstThree(races);
            // Ausgabe (A)
            PrintData(firstThree);
            Console.WriteLine("Durchschnittliche Laufzeit[sek]: {0:f}", CalculateAverageTime(races));

            PrintFooter();
        }

        /// <summary>
        /// Diese Methode gibt den Programmkopf aus.
        /// </summary>
        static void PrintHeader()
        {
            Console.WriteLine("***********************************************************");
            Console.WriteLine("* Business-Run - Die zuverlässige Software für Läufer     *");
            Console.WriteLine("* von Gerhard Gehrer                                      *");
            Console.WriteLine("***********************************************************");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        /// <summary>
        /// Diese Methode gibt den Programmfuss aus.
        /// </summary>
        static void PrintFooter()
        {
            Console.WriteLine();
            Console.Write("Drücken Sie eine beliebige Taste...");
            Console.ReadKey();
        }

        /// <summary>
        ///  Diese Methode gibt die Renndaten an die Kónsole aus. 
        /// </summary>
        /// <param name="runners">Array von Renndaten</param>
        public static void PrintData(Runner[] runners)
        {
            Console.WindowWidth = 100;
            Console.WriteLine("{0, 6} {1, -25}{2, 5}{3, 10} {4, -30}{5:f}", "Nr", "Name", "JG", "Nation", "Team", "Zeit[sec]");
            for (int i = 0; i < runners.Length; i++)
            {
                Console.WriteLine("{0, 6} {1, -25}{2, 5}{3, 10} {4, -30}{5:f}", runners[i].StartNr, runners[i].Name, runners[i].Year, runners[i].Nation, runners[i].Team, runners[i].TimeSec);
            }
        }

        /// <summary>
        /// Diese Methode berechnet die durchschnittliche Rennzeit.
        /// </summary>
        /// <param name="runners">Array von Renndaten</param>
        /// <returns>Die durchschnitliche Rennzeit.</returns>
        public static double CalculateAverageTime(Runner[] runners)
        {
            double result = 0;

            for (int i = 0; i < runners.Length; i++)
            {
                result += runners[i].TimeSec;
            }
            return result / runners.Length;
        }

        /// <summary>
        /// Diese Methode liefert die ersten drei Eintraege der Laufergebnisse.
        /// </summary>
        /// <param name="runners">Die Laufergebnisse</param>
        /// <returns>Die ersten drei Laufergebnisse</returns>
        public static Runner[] GetTheFirstThree(Runner[] runners)
        {
            Runner[] result = runners.Length > 3 ? new Runner[3] : new Runner[runners.Length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = runners[i];
            }

            return result;
        }

        /// <summary>
        /// Diese Methode sortiert die Laufergebnisse in aufsteigender Folge nach der Rennzeit.
        /// </summary>
        /// <param name="runners"></param>
        public static void SortRacesByTime(Runner[] runners)
        {
            bool sort;

            do
            {
                sort = true;
                for (int i = 0; i < runners.Length - 1; i++)
                {
                    if (runners[i + 1].TimeSec < runners[i].TimeSec)
                    {
                        Runner tmp = runners[i + 1];

                        runners[i + 1] = runners[i];
                        runners[i] = tmp;
                        sort = false;
                    }
                }
            } while (sort == false);
        }

        /// <summary>
        /// Diese Methode sortiert die Laufgebnisse in aufsteigender Folge nach der Startnummer.
        /// </summary>
        /// <param name="runners"></param>
        public static void SortRunnersByStartNr(Runner[] runners)
        {
            bool sort;

            do
            {
                sort = true;
                for (int i = 0; i < runners.Length - 1; i++)
                {
                    if (runners[i + 1].StartNr.CompareTo(runners[i].StartNr) < 0)
                    {
                        Runner tmp = runners[i + 1];

                        runners[i + 1] = runners[i];
                        runners[i] = tmp;
                        sort = false;
                    }
                }
            } while (sort == false);
        }

        /// <summary>
        /// Diese Methode lest die Csv-Daten aus der angegebenen Datei und wandelt
        /// diese in ein Daten-Array um.
        /// </summary>
        /// <param name="fileName">Csv-Datei</param>
        /// <returns>Array von Runner</returns>
        public static Runner[] ReadDataFromCsv(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF7);
            Runner[] races = new Runner[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(';');

                if (data.Length >= 7)
                {
                    races[i].StartNr = data[0];
                    races[i].Name = data[1];
                    races[i].Year = Convert.ToInt32(data[2]);
                    races[i].Nation = data[3];
                    races[i].Company = data[4];
                    races[i].Team = data[5];
                    races[i].Time = data[6];
                    races[i].TimeSec = GetTimeSec(races[i].Time);
                }
            }
            return races;
        }

        /// <summary>
        /// Diese Methode schreibt die Renndaten in eine Csv-Datei.
        /// </summary>
        /// <param name="fileName">Dateiname</param>
        /// <param name="runners">Array von Renndaten</param>
        public static void WriteDataToCsv(string fileName, Runner[] runners)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

            for (int i = 0; i < runners.Length; i++)
            {
                sw.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7:f}", runners[i].StartNr, runners[i].Name, runners[i].Year, runners[i].Nation, runners[i].Company, runners[i].Team, runners[i].Time, runners[i].TimeSec);
            }
            sw.Close();
        }

        /// <summary>
        /// Rechnet die Stringzeit in Sekunden um
        /// </summary>
        /// <param name="timeString"></param>
        /// <returns>Sekunden</returns>
        public static double GetTimeSec(string timeString)
        {
                double timeSec = 0;
                    string[] data = timeString.Replace(",", ":").Split(':');
                    timeSec = Convert.ToInt32(data[0]) * 60;
                    timeSec += Convert.ToInt32(data[1]);
                    timeSec += Convert.ToDouble(data[2]) / 10;
                return timeSec;
        }

    }
}
