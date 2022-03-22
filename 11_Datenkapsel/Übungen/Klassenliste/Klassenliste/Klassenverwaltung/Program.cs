/***********************************************************************************************
 * Übungsnr:        18                                     
 * Programmname:    Klassenverwaltung I
 * Autor:           Michael Bucek  
 * Klasse:          1CHIF
 * Datum:           05.03.2014                               
 * ------------------------------------------------ 
 * Kurzbeschreibung:      
 * Verwaltet die Daten von Schülern einer Klasse in einem Strukturarray
 ************************************************************************************************/
using System;
using System.IO;
using System.Text;

namespace Klassenverwaltung
{
    class Program
    {

        const int MAXPUPILS = 40;
        const string FILENAME = "pupils.csv";


        /// <summary>
        /// Struktur zur Gruppierung nach Postleitzahl
        /// </summary>
        struct ZipCodeGrp
        {
            public int ZipCode;
            public int Cnt;
        }

        /// <summary>
        /// Einlesen und anlegen eines neuen Schülers
        /// </summary>
        /// <param name="pupils"></param>
        /// <param name="pupCnt"></param>
        static void ReadNewStudent(Pupil[] pupils, int pupCnt)
        {
            Console.WriteLine("Neuen Schüler eingeben:");
            pupils[pupCnt] = new Pupil();
            Console.Write("Katalognr: ");
            pupils[pupCnt].SetCatalogNumber(Convert.ToInt32(Console.ReadLine()));

            Console.Write("Vorname: ");
            pupils[pupCnt].SetFirstName(Console.ReadLine());

            Console.Write("Nachname: ");
            pupils[pupCnt].SetLastName(Console.ReadLine());

            Console.Write("Plz.: ");
            pupils[pupCnt].SetZipCode(Convert.ToInt32(Console.ReadLine()));
        }


        /// <summary>
        /// Ausgabe der Liste
        /// </summary>
        /// <param name="list"></param>
        /// <param name="cnt"></param>
        static void PrintList(Pupil[] list, int cnt)
        {
            //Überschrift
            Console.WriteLine("{0,-5:d2} {1,-20} {2,-20} {3,-8}\n", "Nr.", "Vorname", "Nachname", "Plz.");

            for (int i = 0; i < cnt; i++)
            {
                Console.WriteLine("{0,-5:d2} {1,-20} {2,-20} {3,-8}", 
                    list[i].GetCatalogNumber(), 
                    list[i].GetFirstName(), 
                    list[i].GetLastName(), 
                    list[i].GetZipCode());
            }
        }

        /// <summary>
        /// Berechnung und Ausgabe der Schüler je PLZ
        /// </summary>
        /// <param name="list"></param>
        /// <param name="cnt"></param>
        static void PrintZipcode(Pupil[] list, int cnt)
        {
            ZipCodeGrp[] zipCodes = new ZipCodeGrp[cnt];
            int zipCnt = 0;
            bool found;

            //Zählen wie viele Schüler in den jeweiligen PLZs wohnen
            for (int i = 0; i < cnt; i++)
            {
                found = false;
                for (int j = 0; j < zipCnt; j++)
                {
                    if (list[i].GetZipCode() == zipCodes[j].ZipCode)
                    {
                        zipCodes[j].Cnt++;
                        found = true;
                    }
                }
                if (!found) //Postleitzahl noch nicht in PLZ-Array
                {
                    zipCodes[zipCnt].ZipCode = list[i].GetZipCode();
                    zipCodes[zipCnt].Cnt++;
                    zipCnt++;
                }
            }

            //Ausgabe des Ergebnisses
            for (int i = 0; i < zipCnt; i++)
            {
                Console.WriteLine("In PLZ {0} wohnen {1,2} Schüler!", zipCodes[i].ZipCode, zipCodes[i].Cnt);
            }
        }

        /// <summary>
        /// Tauschen zweier Schüler
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        static void Swap(ref Pupil first, ref Pupil second)
        {
            Pupil tmp;

            //Tauschen der Variablen
            tmp = first;
            first = second;
            second = tmp;
        }

        /// <summary>
        /// Liste nach Katalognummer Sortieren
        /// </summary>
        /// <param name="list"></param>
        /// <param name="cnt"></param>
        static void SortByPupilNr(ref Pupil[] list, int cnt)
        {
            for (int i = 0; i < cnt; i++)
            {
                for (int j = i+1; j < cnt; j++)
                {
                    if (list[i].GetCatalogNumber() > list[j].GetCatalogNumber())
                    {
                        Swap(ref list[i], ref list[j]);
                    }
                }
            }
        }

        /// <summary>
        /// Liste nach Nachname sortieren
        /// </summary>
        /// <param name="list"></param>
        /// <param name="cnt"></param>
        static void SortByName(ref Pupil[] list, int cnt)
        {
            for (int i = 0; i < cnt; i++)
            {
                for (int j = i+1; j < cnt; j++)
                {
                    if (list[i].GetLastName().CompareTo(list[j].GetLastName()) > 0)
                    {
                        Swap(ref list[i], ref list[j]);
                    }
                }
            }
        }



        /// <summary>
        /// Schreibt Schülerdaten in csv-Datei
        /// </summary>
        /// <param name="pupils"></param>
        /// <param name="pupilCnt"></param>
        static void WritePupilsToCsv(Pupil[] pupils, int pupilCnt)
        {
            string[] lines = new string[pupilCnt];
            for (int i = 0; i < pupilCnt; i++)
            {
                lines[i] = pupils[i].GetCatalogNumber() + ";" 
                    + pupils[i].GetFirstName() + ";" 
                    + pupils[i].GetLastName() + ";" 
                    + pupils[i].GetZipCode();
            }
            File.WriteAllLines(FILENAME, lines, Encoding.Default);
        }

        /// <summary>
        /// Liest Schülerdaten aus der csv-Datei.
        /// Gibt die Anzahl der eingelesenen Schüler zurück.
        /// </summary>
        /// <param name="pupils"></param>
        /// <returns></returns>
        static int ReadPupilsFromCsv(Pupil[] pupils)
        {
            string[] lines;

            if (File.Exists(FILENAME))
            {
                lines = File.ReadAllLines("pupils.csv", Encoding.Default);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] cols = lines[i].Split(';');
                    pupils[i] = new Pupil();
                    pupils[i].SetCatalogNumber(Convert.ToInt32(cols[0]));
                    pupils[i].SetFirstName(cols[1]);
                    pupils[i].SetLastName(cols[2]);
                    pupils[i].SetZipCode(Convert.ToInt32(cols[3]));
                }
                return lines.Length;
            }
            else //Datei existiert nicht -> keine Schüler eingelesen
                return 0;
        }

        /// <summary>
        /// Menü wird ausgegeben und die Auswahl eingelesen
        /// </summary>
        /// <param name="selection"></param>
        /// <returns></returns>
        private static string GetMenuSelection(string selection)
        {
            Console.WriteLine("MENÜ:");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1: Neuen Schüler anlegen");
            Console.WriteLine("2: Liste nach Katalognummer sortieren");
            Console.WriteLine("3: Liste nach Familienname sortieren");
            Console.WriteLine("4: Ausgabe der Liste");
            Console.WriteLine("5: Schüler je Postleitzahl ausgeben");
            Console.WriteLine("6: Schüler in csv-Datei speichern\n");
            Console.WriteLine("0: ENDE");
            Console.Write("Menüpunkt auswählen: ");
            selection = Console.ReadLine();
            Console.Clear();
            return selection;
        }

        /// <summary>
        /// Main-Methode
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Pupil[] pupils = new Pupil[MAXPUPILS];   //Strukturarrays der Schüler
            string selection = "";
            int pupilCnt = 0;

            //Daten von csv-File einlesen
            pupilCnt=ReadPupilsFromCsv(pupils);
            if (pupilCnt > 0)
            {
                Console.WriteLine(pupilCnt + " Schüler eingelesen!\n");
            }
            do
            {
                selection = GetMenuSelection(selection); //Auswahl der Methode vom Benutzer

                switch (selection) //Ausführen der gewünschten Funktion
                {
                    case "1":
                        if (pupilCnt < MAXPUPILS) //Nur wenn noch nicht max. Schülerzahl erreicht wurde
                        {
                            ReadNewStudent(pupils, pupilCnt);
                            pupilCnt++;
                            Console.WriteLine("Schüler wurde angelegt!");
                        }
                        else
                        {
                            Console.WriteLine("Maximale Schüleranzahl ({0}) erreicht!");
                        }
                        break;
                    case "2":
                        SortByPupilNr(ref pupils, pupilCnt);
                        Console.WriteLine("Die Liste wurde nach der Katalognummer sortiert!");
                        break;
                    case "3":

                        SortByName(ref pupils, pupilCnt);
                        Console.WriteLine("Die Liste wurde nach dem Nachnamen sortiert!");
                        break;
                    case "4":
                        PrintList(pupils, pupilCnt);
                        break;
                    case "5":
                        PrintZipcode(pupils, pupilCnt);
                        break;
                    case "6":
                        WritePupilsToCsv(pupils, pupilCnt);
                        Console.WriteLine(pupilCnt+" Schüler  in csv-Datei \""+FILENAME+"\" geschrieben!");
                        break;
                    case "0":
                        Console.WriteLine("Auf Wiedersehen!");
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe!");
                        break;
                }
                Console.WriteLine("\n(Eingabetaste drücken!)");
                Console.ReadLine();
                Console.Clear();
            } while (selection != "0");
        }

    }
}