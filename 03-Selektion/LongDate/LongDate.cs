using System;

namespace Wochentag
{
    class Program
    {
        struct Datum
        {
            public int tag;
            public int monat;
            public int jahr;
        }

        static int Anzahlmonatstage(Datum d)
        {
            int tage = 0;
            if (d.monat == 1 || d.monat == 3 || d.monat == 5 || d.monat == 7 ||
                d.monat == 8 || d.monat == 10 || d.monat == 12)
            {
                tage = 31;
            }
            else if (d.monat == 4 || d.monat == 6 || d.monat == 9 || d.monat == 11)
            {
                tage = 30;
            }
            if (d.monat == 2)
            {
                if (d.jahr % 4 == 0 && (d.jahr % 100 != 0 || d.jahr % 400 == 0))
                    tage = 29;
                else
                    tage = 28;
            }
            return tage;
        }

        // Pruefe beim Datum, ob
        // (1)  Jahr ok  --> (0 <= d.jahr && d.jahr <= 3000)
        // (2)  Monat ok --> (1 <= d.monat && d.monat <= 12)
        // (3)  Tag ok   --> (1 <= d.tag && d.tag <= tage), bei Februar ohne Schaltjahr tage == 28 , ...
        static bool Datum_ok(Datum d)
        {
            if (0 <= d.jahr && d.jahr <= 3000)
            {
                if (1 <= d.monat && d.monat <= 12)
                {
                    if (1 <= d.tag && d.tag <= Anzahlmonatstage(d))
                        return true;
                }
            }
            return false;
        }

        // RETURN: 0 .. Sonntag, ... , 6 .. Samstag  
        // Berechne diesen Wert nach der Formel!
        // Falls Datum nicht ok  --> return (-1)
        static int Wochentag(Datum d)
        {
            if (!(Datum_ok(d)))
                return -1;
            if (d.monat <= 2)
            {
                d.jahr--;
                d.monat += 12;
            }
            return (int)((((long)(365.25 * d.jahr)) + ((long)(30.6001 * (d.monat + 1))) + (5 + d.tag)) % 7);
        }

        // String Array: { "Sonntag", "Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag"}
        // Falls nicht "(0 <= wt && wt < 7)" --->  return "???"
        static string Tagname(int wt)
        {
            string[] tages_namen = { "Sonntag", "Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag" };
            if (0 <= wt && wt < 7)
            {
                return tages_namen[wt];
            }
            else
            {
                return "???";
            }
        }
        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;
            Datum d;
            d.jahr = dt.Year;
            d.monat = dt.Month;
            d.tag = dt.Day;
            d.jahr = 1968;
            d.monat = 1;
            d.tag = 21;
            Console.WriteLine($"Dieser Tag '{d.tag}-{d.monat}-{d.jahr}' ist ein '{Tagname(Wochentag(d))}' " );
        }
    }
}
