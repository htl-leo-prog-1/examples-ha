using System;

namespace LinearMotion
{
    class Program
    {
        static void Main()
        {
            int speedA;
            int speedB;
            double wayA;
            double actualDistance;
            double meetingTimeMinutes;
            int totalDistance;
            int actualMinute = 0;
            int hours;
            int minutes;
            double seconds;
            string input;
            // Eingabe
            Console.WriteLine("Begegnung zweier entgegenfahrender Fahrzeuge");
            Console.WriteLine("============================================");
            Console.WriteLine();
            Console.Write("Entfernung [Ganzzahl in km]: ");
            input = Console.ReadLine();
            totalDistance = Convert.ToInt32(input);
            Console.Write("Geschwindigkeit des Fahrzeugs A [Ganzzahl in km/h]: ");
            speedA = Convert.ToInt32(Console.ReadLine());
            Console.Write("Geschwindigkeit des Fahrzeugs B [Ganzzahl in km/h]: ");
            speedB = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            // Verarbeitung
            // Wann treffen sich die beiden Fahrzeuge
            meetingTimeMinutes = ((double)totalDistance) / (speedA + speedB) * 60;
            while (actualMinute < meetingTimeMinutes)  // noch eine ganze Minute fahren
            {
                wayA = speedA * (actualMinute / 60.0);
                var wayB = speedB * (actualMinute / 60.0);
                actualDistance = totalDistance - wayA - wayB;
                Console.WriteLine("Minute: {0, 2} Position A: {1,5:f2} Position B: {2,5:f2} Distanz: {3,5:f2}",
                    actualMinute, wayA, totalDistance - wayB, actualDistance);
                actualMinute++;
            }
            hours = (int)Math.Floor(meetingTimeMinutes / 60);
            minutes = (int)Math.Floor(meetingTimeMinutes - hours * 60);
            seconds = (meetingTimeMinutes - hours * 60 - minutes) * 60.0;
            wayA = speedA * meetingTimeMinutes / 60;
            Console.WriteLine();
            Console.WriteLine("Treffpunkt in {0,5:f2} km nach {1} Stunden, {2} Minuten und {3,5:f2} Sekunden",
                wayA, hours, minutes, seconds);
            Console.WriteLine();
            Console.Write("Weiter mit Eingabetaste ...");
            Console.ReadLine();
        }
    }
}
