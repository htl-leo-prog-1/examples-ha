using System;
using System.Text;
using System.IO;

namespace MTBMarathon
{
    class Program
    {

        public static string INPUTDATAFILE = "MTB-Marathon.csv";
        public static string OUTPUTDATAFILE = "MTB-Results.csv";

        static void Main(string[] args)
        {

            // Ausgabe der Programm-Header
            PrintHeader();
            // Eingabe (E)
            Biker[] bikers = ReadDataFromCsv(INPUTDATAFILE);
            
            // Verarbeitung (V)
            SortBikerByTime(bikers);
            Rank(bikers);
            PrintData(bikers);
            Biker[] firstThree = GetTheFirstThree(bikers);

            // Ausgabe (A)

            Console.WriteLine();
            Console.WriteLine("ERGEBNIS (Top 3): ");
            Console.WriteLine("================= ");
            PrintData(firstThree);
            Console.WriteLine();

            double avg = CalculateAverageTime(bikers);
            Console.WriteLine("Durchschnittliche Rennzeit: {0} (in Sekunden: {1:f})", 
                GetTimeString(avg), avg);

            WriteDataToCsv(OUTPUTDATAFILE, bikers);
            PrintFooter();
        }

        static void Rank(Biker[] bikers)
        {
            int rank = 0;
            int increment = 1;
            int time = 0;
            for (int i = 0; i < bikers.Length; i++)
            {
                if (bikers[i].GetTimeInSeconds() != time)
                {
                    rank += increment;
                    time = bikers[i].GetTimeInSeconds();
                    increment = 1;
                }
                else
                {
                    increment++;
                }
                bikers[i].SetRank(rank);
            }
        }
        /// <summary>
        /// Diese Methode gibt den Programmkopf aus.
        /// </summary>
        static void PrintHeader()
        {
            Console.WriteLine("***********************************************************");
            Console.WriteLine("* MTB-Marathon - Die zuverlässige Software für MTB-Biker  *");
            Console.WriteLine("* von <NAME>                                              *");
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
        /// <param name="races">Array von Renndaten</param>
        public static void PrintData(Biker[] bikers)
        {
            Console.WriteLine("{0, 4} {1, 2} {2, -25} {3, -10} {4, -10}", "Rang", "Nr", "Name", "Zeit", "Zeit[sec]");
            for (int i = 0; i < bikers.Length; i++)
            {
                Console.WriteLine("{0, 4} {1, 2} {2, -25} {3, -10} {4, -10}",
                    bikers[i].GetRank(), 
                    bikers[i].GetNumber(), 
                    bikers[i].GetName(), 
                    bikers[i].GetTime(), 
                    bikers[i].GetTimeInSeconds());
            }
        }

        /// <summary>
        /// Diese Methode berechnet die durchschnittliche Rennzeit.
        /// </summary>
        /// <param name="races">Array von Renndaten</param>
        /// <returns>Die durchschnitliche Rennzeit.</returns>
        public static double CalculateAverageTime(Biker[] bikers)
        {
            double result = 0;

            for (int i = 0; i < bikers.Length; i++)
            {
                result += bikers[i].GetTimeInSeconds();
            }
            return result / bikers.Length;
        }

        /// <summary>
        /// Diese Methode liefert die ersten drei Eintraege der Rennliste.
        /// </summary>
        /// <param name="races">Die Rennliste</param>
        /// <returns>Die ersten drei Rennergebnisse</returns>
        public static Biker[] GetTheFirstThree(Biker[] bikers)
        {
            Biker[] result;

            if (bikers.Length > 3)
            {
                result = new Biker[3];
            }
            else
            {
                result = new Biker[bikers.Length];
            }

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = bikers[i];
            }

            return result;
        }

        /// <summary>
        /// Diese Methode sortiert die Rennergebnisse in aufsteigender Folge nach der Rennzeit.
        /// </summary>
        /// <param name="races"></param>
        public static void SortBikerByTime(Biker[] bikers)
        {
            bool isSorted;

            do
            {
                isSorted = true;
                for (int i = 0; i < bikers.Length - 1; i++)
                {
                    if (bikers[i + 1].GetTimeInSeconds() < bikers[i].GetTimeInSeconds())
                    {
                        Biker tmp = bikers[i + 1];

                        bikers[i + 1] = bikers[i];
                        bikers[i] = tmp;
                        isSorted = false;
                    }
                }
            } while (isSorted == false);
        }

        /// <summary>
        /// Diese Methode sortiert die Rennergebnisse in aufsteigender Folge nach der Startnummer.
        /// </summary>
        /// <param name="races"></param>
        public static void SortRacesByStartNr(Biker[] bikers)
        {
            bool isSorted;

            do
            {
                isSorted = true;
                for (int i = 0; i < bikers.Length - 1; i++)
                {
                    if (bikers[i + 1].GetNumber() < bikers[i].GetNumber())
                    {
                        Biker tmp = bikers[i + 1];

                        bikers[i + 1] = bikers[i];
                        bikers[i] = tmp;
                        isSorted = false;
                    }
                }
            } while (isSorted == false);
        }

        /// <summary>
        /// Diese Methode lest die Csv-Daten aus der angegebenen Datei und wandelt
        /// diese in ein Daten-Array um.
        /// </summary>
        /// <param name="fileName">Csv-Datei</param>
        /// <returns>Array von MTBRace</returns>
        public static Biker[] ReadDataFromCsv(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName, Encoding.Default);
            Biker[] bikers = new Biker[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(';');

                if (data.Length == 5)
                {
                    bikers[i] = new Biker();
                    bikers[i].SetNumber(Convert.ToInt32(data[0]));
                    bikers[i].SetName(data[1]);
                    bikers[i].SetYear(data[2]);
                    bikers[i].SetCountry(data[3]);
                    bikers[i].SetTime(data[4]);
                    bikers[i].SetTimeInSeconds(GetTimeSec(bikers[i].GetTime()));
                }
            }
            return bikers;
        }

        /// <summary>
        /// Diese Methode schreibt die Renndaten in eine Csv-Datei.
        /// </summary>
        /// <param name="fileName">Dateiname</param>
        /// <param name="races">Array von Renndaten</param>
        public static void WriteDataToCsv(string fileName, Biker[] bikers)
        {
            string[] lines = new string[bikers.Length];

            for (int i = 0; i < bikers.Length; i++)
            {
                lines[i] =
                    bikers[i].GetRank() + ";" +
                    bikers[i].GetNumber() + ";" +
                    bikers[i].GetName() + ";" +
                    bikers[i].GetYear() + ";" +
                    bikers[i].GetCountry() + ";" +
                    bikers[i].GetTime() + ";" +
                    bikers[i].GetTimeInSeconds();
            }
            File.WriteAllLines(fileName, lines);
        }

        /// <summary>
        /// Rechnet die Stringzeit in Sekunden um
        /// </summary>
        /// <param name="timeString"></param>
        /// <returns>Sekunden</returns>
        public static int GetTimeSec(string timeString)
        {
            int timeSec = 0;
            string[] data = timeString.Split(':');
            timeSec = Convert.ToInt32(data[0]) * 3600;
            timeSec += Convert.ToInt32(data[1]) *60;
            timeSec += Convert.ToInt32(data[2]);
            return timeSec;
        }

        /// <summary>
        /// Rechnet die Stringzeit in Sekunden um
        /// </summary>
        /// <param name="timeString"></param>
        /// <returns>Sekunden</returns>
        public static string GetTimeString(double time)
        {
            string timeString = "" + (time / 3600) + ":";
            int hours = (int) time / 3600;
            int minutes = (int) (time - hours * 3600) / 60;
            double seconds =  (time - hours * 3600 - minutes * 60);
            return String.Format("{0:d2}:{1:d2}:{2:f2}", hours, minutes, seconds);
        }

    }
}
