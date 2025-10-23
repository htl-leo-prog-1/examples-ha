using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Tadeot
{
    public class Program
    {
        struct InfoQuelle
        {
            public string Bezeichnung;
            public int Anzahl;
        }

        static void Main(string[] args)
        {
            // Besucherdaten einlesen
            string[] lines = File.ReadAllLines("Besucher.csv", Encoding.Default);
            // Infoquellen aus den Besucherdaten ermitteln (max. 100)
            // Zählerarray entsprechend den Infoquellen anlegen
            InfoQuelle[] infoQuellen = ExtractInfoSources(lines);
            // Infoquelle Je Besucher zählen
            CountVistorsPerInfoSource(infoQuellen, lines);
            // Sortiere die Auswertung
            SortErgebnis(infoQuellen);
            // In Statistik.txt schreiben
            WriteToFile(infoQuellen, lines.Length);
        }

        /// <summary>
        /// Ergebnis der Auswertung wird nach Häufigkeiten absteigend
        /// sortiert
        /// </summary>
        /// <param name="infoQuellen"></param>
        private static void SortErgebnis(InfoQuelle[] infoQuellen)
        {
            bool getauscht;
            int rounds = 0;
            InfoQuelle swap;
            do
            {
                getauscht = false;
                for (int i = 0; i+1 < infoQuellen.Length-rounds; i++)
                {
                    if (infoQuellen[i].Anzahl < infoQuellen[i+1].Anzahl)
                    {
                        swap = infoQuellen[i];
                        infoQuellen[i] = infoQuellen[i+1];
                        infoQuellen[i+1] = swap;
                        getauscht=true;
                    }
                }
            } while (getauscht);
        }

        /// <summary>
        /// Das endgültige Ergebnis wird in die Datei Ergebnis.txt
        /// ausgegeben. Dabei werden die absoluten Häufigkeiten
        /// in Prozente umgerechnet.
        /// </summary>
        /// <param name="infoQuellen">Infoquellen mit Häufigkeiten</param>
        /// <param name="gesamtAnzahl"></param>
        private static void WriteToFile(InfoQuelle[] infoQuellen, int gesamtAnzahl)
        {
            string[] lines = new string[infoQuellen.Length];
            for (int i = 0; i < infoQuellen.Length; i++)
            {
                lines[i] = string.Format("{0,-15} {1,5:f2}%", infoQuellen[i].Bezeichnung, (infoQuellen[i].Anzahl*100.0)/gesamtAnzahl);
            }
            File.WriteAllLines("Ergebnis.txt", lines, Encoding.Default);
        }

        /// <summary>
        /// Die Infoquellen in den Zeilen werden ermittelt und gezählt
        /// </summary>
        /// <param name="infoQuellen"></param>
        /// <param name="lines"></param>
        private static void CountVistorsPerInfoSource(InfoQuelle[] infoQuellen, string[] lines)
        {
            foreach (string line in lines)
            {
                string[] elemente = line.Split(';');
                string textInfoQuelle = elemente[9];
                AddCounterInfoQuelle(infoQuellen, textInfoQuelle);
            }
        }

        /// <summary>
        /// Für die Infoquelle einer Zeile wird der Zähler
        /// gesucht und um eins erhöht
        /// </summary>
        /// <param name="infoQuellen"></param>
        /// <param name="textInfoQuelle"></param>
        private static void AddCounterInfoQuelle(InfoQuelle[] infoQuellen, string textInfoQuelle)
        {
            int index = 0;
            while (index < infoQuellen.Length && infoQuellen[index].Bezeichnung != textInfoQuelle)
            {
                index++;
            }
            if (index < infoQuellen.Length)
            {
                infoQuellen[index].Anzahl++;
            }
        }

        /// <summary>
        /// Die Zeilen werden analysiert und die enthaltenen
        /// Infoquellen unique zurückgegeben.
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        private static InfoQuelle[] ExtractInfoSources(string[] lines)
        {
            string[] textInfoQuellen = new string[100];
            foreach (string line in lines)
            {
                string[] elemente = line.Split(';');
                InsertInfoSourceWithoutDuplicate(textInfoQuellen, elemente[9]);
            }
            int anzahl = 0;
            while (textInfoQuellen[anzahl] != null)
            {
                anzahl++;
            }
            InfoQuelle[] infoQuellen = new InfoQuelle[anzahl];
            for (int i = 0; i < infoQuellen.Length; i++)
            {
                infoQuellen[i].Bezeichnung = textInfoQuellen[i];
            }
            return infoQuellen;
        }

        /// <summary>
        /// In das Stringarray von Infoquellen wird eine weitere 
        /// sortiert eingefügt, sofern sie noch nicht existiert.
        /// Die nicht belegten Positionen im Stringarray sind
        /// alle null.
        /// </summary>
        /// <param name="textInfoQuellen">Stringarray mit den bisherigen Infoquellen</param>
        /// <param name="infoQuelle">Einzufügende Infoquelle</param>
        /// <returns>Anzahl der Infoquellen nach dem Einfügen</returns>
        public static int InsertInfoSourceWithoutDuplicate(string[] textInfoQuellen, string infoQuelle)
        {
            int index = 0;
            // Länge ermitteln
            int count = 0;
            while (textInfoQuellen[count] != null)
            {
                count++;
            }
            // Einfügeposition suchen
            while (textInfoQuellen[index] != null && 
                string.Compare(textInfoQuellen[index], infoQuelle) < 0 )
            {
                index++;
            }
            if (textInfoQuellen[index] != null && 
                string.Compare(textInfoQuellen[index], infoQuelle) == 0 )
            {  // gibt es schon
                return count;
            }
            else if (textInfoQuellen[index] == null)  // sind am Ende ==> einfach einfügen
            {
                textInfoQuellen[index] = infoQuelle;
                return index+1;
            }
            else  // mitten drinnen
            {
                // hinteren Teil verschieben
                for (int i = count; i > index; i--)
                {
                    textInfoQuellen[i] = textInfoQuellen[i - 1];
                }
                // einfügen
                textInfoQuellen[index] = infoQuelle;
                return count +1;
            }
        }
    }
}
