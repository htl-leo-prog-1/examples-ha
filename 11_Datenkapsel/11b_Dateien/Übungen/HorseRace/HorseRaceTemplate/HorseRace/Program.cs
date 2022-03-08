using System;
using System.IO;
using System.Text;
using System.Threading;

namespace HorseRace
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            Horse[] horses = ReadHorsesFromCSV("horses.csv");
            Horse tippHorse = GetTipp(horses);
            bool raceFinished = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Ihr Tipp mit der Startnummer {0} heisst {1} und ist {2} Jahre alt. ",
                    tippHorse.GetNumber(), tippHorse.GetName(), tippHorse.GetAge());
                Console.WriteLine();
                raceFinished = MoveHorses(horses);
            } while (!raceFinished);
            GetRaceResults(horses);
            Console.WriteLine("Ihr Tipp Startnummer {0}, Name {1}, {2} Jahre alt, erzielte Rang {3}! ",
                tippHorse.GetNumber(), tippHorse.GetName(), tippHorse.GetAge(), tippHorse.GetRank());

            Console.WriteLine("Zum Beenden bitte Taste drücken ...");
            Console.ReadKey();
        }

        /// <summary>
        /// Alle Zeilen der vorgegebenen CSV-Datei werden ausgelesen.
        /// Erzeugen eines Horse-Arrays (new Horse[..]) mit der Anzahl der
        /// eingelesenen Zeilen.
        /// Aus jeder Zeile wird ein neues Horse erzeugt, der Name und
        /// das Alter aus der Textzeile gefiltert (Split!) und dem Horse zugewiesen.
        /// Als Startnummer (Number) des Pferdes wird der um 1 erhöhte Laufindex
        /// verwendet. Das neue Pferd muss dem Horse-Array an richtiger Stelle
        /// zugewiesen werden.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Array von Pferden</returns>
        private static Horse[] ReadHorsesFromCSV(string fileName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ausgabe der Startliste auf die Konsole:
        /// Nr - Name - Alter
        /// {0,-3} {1,-10} {2}
        /// </summary>
        /// <param name="horses"></param>
        private static void PrintStartList(Horse[] horses)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Zuerst wird die Startliste ausgegeben.
        /// Dann muss der Benutzer eine Startnummer auswählen. Solange
        /// die Zahl nicht zwischen 1 und 10 (Länge des Arrays)
        /// liegt, wird die Eingabe wiederholt.
        /// </summary>
        /// <param name="horses"></param>
        /// <returns>Das Pferd mit der ausgewählten Startnummer</returns>
        private static Horse GetTipp(Horse[] horses)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ein "Durchgang" des Rennens - alle Pferde werden
        /// zufällig um eine Position weiterbewegt oder nicht.
        /// Die Wahrscheinlichkeit, dass ein Pferd eine Position
        /// weiterkommt, soll ein Drittel betragen (in 1 von 3 Fällen).
        /// Zusätzlich werden die Pferde und deren aktuelle Position auf
        /// die Konsole ausgegeben (Zeilenweise, ein Pferd pro Zeile).
        /// Wenn eines der Pferde die Zielposition 60 erreicht hat,
        /// wird true zurückgegeben (=> finished).
        /// Am Ende eines Durchgangs wird 100 ms lang pausiert.
        /// </summary>
        /// <param name="horses"></param>
        /// <returns>true, wenn mindestens ein Pferd im Ziel ist</returns>
        private static bool MoveHorses(Horse[] horses)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ausgabe des Pferdes mit Startnummer sowie
        /// der aktuellen Position eines Pferdes mit
        /// '*' und der Ziellinie ('|') auf Position 60.
        /// Wenn ein Pferd schon Position 60 erreicht hat,
        /// wird anstelle von '|' der '*' ausgegeben.
        /// </summary>
        /// <param name="horse"></param>
        private static void DrawPosition(Horse horse)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Das Pferdearray wird anhand der Pferde-Positionen
        /// absteigend sortiert, danach werden den Pferden die
        /// entsprechenden Platzierungen zugewiesen.
        /// Schließlich wird das so ermittelte Ergebnis auf die
        /// Konsole ausgegeben.
        /// </summary>
        /// <param name="horses"></param>
        private static void GetRaceResults(Horse[] horses)
        {
            SortByPosition(horses);
            AssignRanks(horses);
            PrintResults(horses);
         }

        /// <summary>
        /// Sortieren des Pferdearrays absteigend nach
        /// Position.
        /// </summary>
        /// <param name="horses"></param>
        private static void SortByPosition(Horse[] horses)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Den Pferden des Arrays wird bei 1 beginnend
        /// der entsprechende Rang zugewiesen (SetRank). 
        /// Pferde mit gleichen Positionen erhalten die 
        /// gleiche Platzierung (ex-aequo).
        /// </summary>
        /// <param name="horses"></param>
        private static void AssignRanks(Horse[] horses)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ausgabe des Rennergebnisses auf die Konsole:
        /// Rang   Nr    Name    Alter  Position
        /// {0,-5} {1,3} {2,-10} {3,-5} {4}
        /// </summary>
        /// <param name="horses"></param>
        private static void PrintResults(Horse[] horses)
        {
            throw new NotImplementedException();
        }
    }
}
