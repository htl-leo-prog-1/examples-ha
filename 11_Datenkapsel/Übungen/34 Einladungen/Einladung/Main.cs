using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Einladung
{
	public class Einladung
	{
		/// <summary>
		/// Einzuladende Person
		/// </summary>
		private struct Freund
		{
			public string NachName;
			public string VorName;
			public string Strasse;
			public int Postleitzahl;
			public string Ort;
		}

        /// <summary>
        /// Gegeben ist die Anzahl der Sekunden. Sie haben die Aufgabe, daraus
        /// die resultierenden Stunden:Minuten:Sekunden zu ermitteln, wobei die
        /// Ausgabe als String erfolgt und Minuten und Sekunden jeweils zweistellig
        /// auszugeben sind. Ergeben sich keine Stunden, wird deren Ausgabe weggelassen.
        /// Gleiches gilt, falls das Ergebnis nicht einmal eine Minute erreicht.
        /// </summary>
        /// <param name="seconds">Gesamtsekunden 0 bis int.MaxValue</param>
        /// <returns></returns>
        public static string CalcTimeSpan(int seconds)
        {

            int minutes;
            int resultSeconds;
            int hours;
            resultSeconds = seconds % 60;
            minutes = (seconds / 60) % 60;
            hours = seconds / 3600;
            string erg;
            if (seconds < 60)  // es gibt keine Stunden und Minuten
            {
                erg = string.Format("{0:00}", resultSeconds);
            }
            else
            {
                if (hours == 0)  // es gibt keine Stunden
                {
                    erg = string.Format("{0:00}:{1:00}", minutes, resultSeconds);
                }
                else  // es gibt alles
                {
                    erg = string.Format("{0}:{1:00}:{2:00}", hours, minutes, resultSeconds);
                }
            }
            return erg;
        }

		private static void Main(string[] args)
		{
			Freund[] gesamtListe = null;	// Zu erzeugende Liste
			Console.WriteLine("Einladungsliste aus mehreren Detaillisten zusammenmischen");
			Console.WriteLine();
			Console.Write("Bitte Listennamen eingeben (leere Eingabe zum Beenden) ");
			string dateiName = Console.ReadLine(); 
			while (dateiName != "")  // Bis Benutzer eine leere Eingabe macht, Dateien einlesen und mischen
			{
				Freund[] neuListe = ReadListe(dateiName);  // Neue Liste aus Dateiinhalt erzeugen
				gesamtListe = MergeListe(gesamtListe, neuListe);  // Gesamtliste mit neuer Liste mischen
				Console.Write("Bitte Listennamen eingeben (leere Eingabe zum Beenden) ");
				dateiName = Console.ReadLine(); 
			}
			Ausgabe(gesamtListe); // Gesamtliste auf Bildschirm und auf Datei ausgeben
			Console.ReadLine();
		}

		/// <summary>
		/// Ausgabe der Einladungsliste auf den Bildschirm und in die 
		/// Datei Einladung.txt
		/// </summary>
		/// <param name="liste">Auszugebende Liste</param>
		private static void Ausgabe(Freund[] liste)
		{
            string text="";
			if (liste != null)
			{
				// Datei zum Schreiben öffnen
                Console.WindowWidth = 120;
				Console.WriteLine();
				Console.WriteLine("Name                         Adresse");
				// Listenende ist erreicht, wenn kein Nachname mehr gespeichert ist
				for (int i = 0; i < (int)liste.Length && liste[i].NachName != null; i++)
				{

					Console.WriteLine("{0,-28} {1,-30} {2} {3, -12}", liste[i].NachName+" "+liste[i].VorName, 
						liste[i].Strasse, liste[i].Postleitzahl, liste[i].Ort);
                    text += string.Format("{0}; {1}; {2}; {3}; {4}\r\n", liste[i].NachName, liste[i].VorName, 
						liste[i].Strasse, liste[i].Postleitzahl, liste[i].Ort);
				}
				Console.WriteLine();
                File.WriteAllText("Einladung.txt", text, Encoding.Default);
			}
		}

		/// <summary>
		/// Liste aus Textdatei erzeugen
		/// </summary>
		/// <param name="dateiName"></param>
		/// <returns></returns>
		static Freund[] ReadListe(string dateiName)
		{
			Freund[] neuListe=null;
			//dateiName = String.Concat(dateiName, ".txt");
            dateiName = dateiName + ".txt";
			if (File.Exists(dateiName))  // wird nichts angehängt
			{
                string[] zeilen = File.ReadAllLines(dateiName, Encoding.Default);
                neuListe = new Freund[100];  // Zielliste erzeugen
                for (int i = 0; i < zeilen.Length;i++ )
                {
                    string zeile = zeilen[i];
                    // Zeile aufsplitten und in Struktur übertragen
                    string[] teile = zeile.Split(';');
                    neuListe[i].NachName = teile[0];
                    neuListe[i].VorName = teile[1];
                    neuListe[i].Strasse = teile[2];
                    neuListe[i].Postleitzahl = Convert.ToInt32(teile[3]);
                    neuListe[i].Ort = teile[4];
                }
			}
			return neuListe;
		}

		/// <summary>
		/// Zwei Listen mischen und Ergebnisliste zurückgeben
		/// </summary>
		/// <param name="listeA"></param>
		/// <param name="listeB"></param>
		/// <returns>Gemischte Ergebnisliste</returns>
		private static Freund[] MergeListe(Freund[] gesamtListe, Freund[] neueListe)
		{
			Freund[] ergebnisListe;

			int indexgesamtListe = 0;
			int indexNeueListe = 0;
			int indexErgebnisListe = 0;
			if (gesamtListe == null)
			{
				ergebnisListe = neueListe;
			}
			else if (neueListe == null)
			{
				ergebnisListe = gesamtListe;
			}
			else
			{
				ergebnisListe = new Freund[100];
				// Listen mischen, solange beide Listen noch Elemente enthalten
				while (gesamtListe[indexgesamtListe].NachName != null 
                    && neueListe[indexNeueListe].NachName != null)
				{
                    // a,b vom Typ string, DateTime, ... ==> vergleichbar (comparable)
                    // CompareTo(a,b) ==>  0, wenn a == b
                    //                     1, wenn a > b
                    //                    -1, wenn a < b  
					if (gesamtListe[indexgesamtListe].NachName.CompareTo(neueListe[indexNeueListe].NachName) < 0)
					{
						ergebnisListe[indexErgebnisListe] = gesamtListe[indexgesamtListe];
						indexgesamtListe++;
					}
					else if (gesamtListe[indexgesamtListe].NachName.CompareTo(neueListe[indexNeueListe].NachName) > 0)
					{
						ergebnisListe[indexErgebnisListe] = neueListe[indexNeueListe];
						indexNeueListe++;
					}
					else  // Namen sind gleich ==> nur einmal übernehmen
					{
						gesamtListe[indexErgebnisListe] = gesamtListe[indexgesamtListe];
						indexgesamtListe++;
						indexNeueListe++;
					}
					indexErgebnisListe++;
				}
				// Rest der verbleibenden Listen anhängen
				while (gesamtListe[indexgesamtListe].NachName != null)
				{
					gesamtListe[indexErgebnisListe] = gesamtListe[indexgesamtListe++];
                    indexErgebnisListe++;
				}
				while (neueListe[indexNeueListe].NachName != null)
				{
					gesamtListe[indexErgebnisListe++] = neueListe[indexNeueListe++];
				}
				ergebnisListe = gesamtListe;
                
			}
			return ergebnisListe;
		}
	}

}
